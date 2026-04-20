using KLS_Furniture.Model.Lookups;
using KLS_Furniture.Model.Return;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace KLS_Furniture.DAL
{
    /// <summary>
    /// Provides database access methods for return transactions.
    /// </summary>
    public class ReturnDBDAL
    {
        private readonly string _cs;

        /// <summary>
        /// Initializes DAL and resolves the KLSFurniture database connection string.
        /// </summary>
        public ReturnDBDAL()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                _cs = "";
                return;
            }

            _cs = KLSFurnitureDBConnection.GetConnectionString();
        }

        private sealed class PreparedReturnItem
        {
            public int RentalTransactionId { get; set; }
            public int FurnitureId { get; set; }
            public int QuantityToReturn { get; set; }
            public decimal FineAmount { get; set; }
            public decimal RefundAmount { get; set; }
        }

        private bool EmployeeExists(int employeeId)
        {
            const string sql = @"
                SELECT COUNT(1)
                FROM dbo.employees
                WHERE employee_id = @EmployeeId;";

            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = employeeId;
                conn.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private int GetRentedQuantity(int rentalTransactionId, int furnitureId)
        {
            const string sql = @"
                SELECT quantity
                FROM dbo.rental_transaction_items
                WHERE rental_transaction_id = @RentalTransactionId
                  AND furniture_id = @FurnitureId;";

            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@RentalTransactionId", SqlDbType.Int).Value = rentalTransactionId;
                cmd.Parameters.Add("@FurnitureId", SqlDbType.Int).Value = furnitureId;
                conn.Open();

                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToInt32(result);
            }
        }

        private int GetAlreadyReturnedQuantity(int rentalTransactionId, int furnitureId)
        {
            const string sql = @"
                SELECT ISNULL(SUM(quantity_returned), 0)
                FROM dbo.return_transaction_items
                WHERE rental_transaction_id = @RentalTransactionId
                  AND furniture_id = @FurnitureId;";

            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@RentalTransactionId", SqlDbType.Int).Value = rentalTransactionId;
                cmd.Parameters.Add("@FurnitureId", SqlDbType.Int).Value = furnitureId;
                conn.Open();

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private ReturnRentalItemLookup GetRentalItemForReturn(int rentalTransactionId, int furnitureId)
        {
            const string sql = @"
                SELECT
                    rt.rental_transaction_id,
                    rti.furniture_id,
                    f.name AS furniture_name,
                    rt.rental_date_time,
                    rt.due_date_time,
                    rti.daily_rate_at_rent,
                    rti.quantity
                FROM dbo.rental_transactions rt
                INNER JOIN dbo.rental_transaction_items rti
                    ON rt.rental_transaction_id = rti.rental_transaction_id
                INNER JOIN dbo.furniture f
                    ON rti.furniture_id = f.furniture_id
                WHERE rt.rental_transaction_id = @RentalTransactionId
                  AND rti.furniture_id = @FurnitureId;";

            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@RentalTransactionId", SqlDbType.Int).Value = rentalTransactionId;
                cmd.Parameters.Add("@FurnitureId", SqlDbType.Int).Value = furnitureId;

                conn.Open();

                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (!r.Read())
                        return null;

                    ReturnRentalItemLookup item = new ReturnRentalItemLookup
                    {
                        RentalTransactionId = r.GetInt32(r.GetOrdinal("rental_transaction_id")),
                        FurnitureId = r.GetInt32(r.GetOrdinal("furniture_id")),
                        FurnitureName = r.GetString(r.GetOrdinal("furniture_name")),
                        RentalDateTime = r.GetDateTime(r.GetOrdinal("rental_date_time")),
                        DueDateTime = r.GetDateTime(r.GetOrdinal("due_date_time")),
                        DailyRateAtRent = r.GetDecimal(r.GetOrdinal("daily_rate_at_rent")),
                        QuantityRented = r.GetInt32(r.GetOrdinal("quantity"))
                    };

                    item.QuantityAlreadyReturned = GetAlreadyReturnedQuantity(rentalTransactionId, furnitureId);
                    item.QuantityRemainingReturnable = item.QuantityRented - item.QuantityAlreadyReturned;

                    return item;
                }
            }
        }

        private int GetRemainingReturnableQuantity(int rentalTransactionId, int furnitureId, SqlConnection conn, SqlTransaction transaction)
        {
            const string sql = @"
                SELECT rti.quantity - ISNULL(SUM(rturn.quantity_returned), 0)
                FROM dbo.rental_transaction_items rti
                LEFT JOIN dbo.return_transaction_items rturn
                    ON rti.rental_transaction_id = rturn.rental_transaction_id
                   AND rti.furniture_id = rturn.furniture_id
                WHERE rti.rental_transaction_id = @RentalTransactionId
                  AND rti.furniture_id = @FurnitureId
                GROUP BY rti.quantity;";

            using (SqlCommand cmd = new SqlCommand(sql, conn, transaction))
            {
                cmd.Parameters.Add("@RentalTransactionId", SqlDbType.Int).Value = rentalTransactionId;
                cmd.Parameters.Add("@FurnitureId", SqlDbType.Int).Value = furnitureId;

                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToInt32(result);
            }
        }

        public ReturnSaveResult SaveReturnTransaction(ReturnSaveRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.EmployeeId <= 0)
                throw new ArgumentException("A valid employee is required.");

            if (!EmployeeExists(request.EmployeeId))
                throw new ArgumentException("The selected employee does not exist.");

            if (request.Items == null || request.Items.Count == 0)
                throw new ArgumentException("At least one return item is required.");

            if (request.ReturnDateTime == default(DateTime))
                throw new ArgumentException("A valid return date is required.");

            HashSet<string> returnKeys = new HashSet<string>();
            List<PreparedReturnItem> preparedItems = new List<PreparedReturnItem>();

            ReturnSaveResult result = new ReturnSaveResult
            {
                TotalFineAmount = 0m,
                TotalRefundAmount = 0m
            };

            foreach (ReturnItemInput item in request.Items)
            {
                if (item == null)
                    throw new ArgumentException("Return item cannot be null.");

                if (item.RentalTransactionId <= 0)
                    throw new ArgumentException("A valid rental transaction is required.");

                if (item.FurnitureId <= 0)
                    throw new ArgumentException("A valid furniture item is required.");

                if (item.QuantityToReturn <= 0)
                    throw new ArgumentException("Return quantity must be greater than zero.");

                string returnKey = item.RentalTransactionId + "|" + item.FurnitureId;
                if (!returnKeys.Add(returnKey))
                    throw new ArgumentException("Duplicate rental items are not allowed in one return transaction.");

                ReturnRentalItemLookup rentalItem = GetRentalItemForReturn(item.RentalTransactionId, item.FurnitureId);
                if (rentalItem == null)
                    throw new ArgumentException("The selected rental item does not exist.");

                if (item.QuantityToReturn > rentalItem.QuantityRemainingReturnable)
                    throw new ArgumentException("Return quantity exceeds the remaining returnable quantity.");

                decimal fineAmount = ReturnCalculator.CalculateFine(
                    rentalItem.DueDateTime,
                    request.ReturnDateTime,
                    rentalItem.DailyRateAtRent,
                    item.QuantityToReturn);

                decimal refundAmount = ReturnCalculator.CalculateRefund(
                    rentalItem.DueDateTime,
                    request.ReturnDateTime,
                    rentalItem.DailyRateAtRent,
                    item.QuantityToReturn);

                preparedItems.Add(new PreparedReturnItem
                {
                    RentalTransactionId = item.RentalTransactionId,
                    FurnitureId = item.FurnitureId,
                    QuantityToReturn = item.QuantityToReturn,
                    FineAmount = fineAmount,
                    RefundAmount = refundAmount
                });

                result.TotalFineAmount += fineAmount;
                result.TotalRefundAmount += refundAmount;
            }

            const string insertReturnSql = @"
                INSERT INTO dbo.return_transactions
                    (employee_id, return_date_time, total_fine_amount, total_refund_amount)
                VALUES
                    (@EmployeeId, @ReturnDateTime, @TotalFineAmount, @TotalRefundAmount);

                SELECT CAST(SCOPE_IDENTITY() AS int);";

            const string insertReturnItemSql = @"
                INSERT INTO dbo.return_transaction_items
                    (return_transaction_id, rental_transaction_id, furniture_id, quantity_returned, fine_amount, refund_amount)
                VALUES
                    (@ReturnTransactionId, @RentalTransactionId, @FurnitureId, @QuantityReturned, @FineAmount, @RefundAmount);";

            const string updateFurnitureQuantitySql = @"
                UPDATE dbo.furniture
                SET quantity = quantity + @QuantityReturned
                WHERE furniture_id = @FurnitureId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand returnCmd = new SqlCommand(insertReturnSql, conn, transaction))
                            {
                                returnCmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = request.EmployeeId;
                                returnCmd.Parameters.Add("@ReturnDateTime", SqlDbType.DateTime2).Value = request.ReturnDateTime;
                                returnCmd.Parameters.Add("@TotalFineAmount", SqlDbType.Decimal).Value = result.TotalFineAmount;
                                returnCmd.Parameters.Add("@TotalRefundAmount", SqlDbType.Decimal).Value = result.TotalRefundAmount;

                                result.ReturnTransactionId = Convert.ToInt32(returnCmd.ExecuteScalar());
                            }

                            foreach (PreparedReturnItem item in preparedItems)
                            {
                                int remainingQuantity = GetRemainingReturnableQuantity(
                                    item.RentalTransactionId,
                                    item.FurnitureId,
                                    conn,
                                    transaction);

                                if (item.QuantityToReturn > remainingQuantity)
                                    throw new DataException("Return quantity exceeds the remaining returnable quantity.");

                                using (SqlCommand itemCmd = new SqlCommand(insertReturnItemSql, conn, transaction))
                                {
                                    itemCmd.Parameters.Add("@ReturnTransactionId", SqlDbType.Int).Value = result.ReturnTransactionId;
                                    itemCmd.Parameters.Add("@RentalTransactionId", SqlDbType.Int).Value = item.RentalTransactionId;
                                    itemCmd.Parameters.Add("@FurnitureId", SqlDbType.Int).Value = item.FurnitureId;
                                    itemCmd.Parameters.Add("@QuantityReturned", SqlDbType.Int).Value = item.QuantityToReturn;
                                    itemCmd.Parameters.Add("@FineAmount", SqlDbType.Decimal).Value = item.FineAmount;
                                    itemCmd.Parameters.Add("@RefundAmount", SqlDbType.Decimal).Value = item.RefundAmount;

                                    itemCmd.ExecuteNonQuery();
                                }

                                using (SqlCommand updateQtyCmd = new SqlCommand(updateFurnitureQuantitySql, conn, transaction))
                                {
                                    updateQtyCmd.Parameters.Add("@FurnitureId", SqlDbType.Int).Value = item.FurnitureId;
                                    updateQtyCmd.Parameters.Add("@QuantityReturned", SqlDbType.Int).Value = item.QuantityToReturn;

                                    int rowsAffected = updateQtyCmd.ExecuteNonQuery();
                                    if (rowsAffected != 1)
                                        throw new DataException("Unable to update furniture quantity after return.");
                                }
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataException("A database error occurred while saving the return transaction.", ex);
            }

            return result;
        }
    }
}