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
                    rt.member_id,
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
                        MemberId = r.GetInt32(r.GetOrdinal("member_id")),
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

        /// <summary>
        /// Function to save a return transaction
        /// </summary>
        /// <param name="request">Details of the transaction to be saved</param>
        /// <returns>Result of the transaction save</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="DataException"></exception>
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
            int? expectedMemberId = null;

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

                if (request.ReturnDateTime < rentalItem.RentalDateTime)
                    throw new ArgumentException("Return date cannot be earlier than rental date.");

                if (!expectedMemberId.HasValue)
                    expectedMemberId = rentalItem.MemberId;
                else if (rentalItem.MemberId != expectedMemberId.Value)
                    throw new ArgumentException("All return items in one return transaction must belong to the same member.");

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

        /// <summary>
        /// Returns all rental items for a member that still have returnable quantity remaining.
        /// </summary>
        public List<ReturnRentalItemLookup> GetReturnableRentalItemsForMember(int memberId)
        {
            if (memberId <= 0)
                throw new ArgumentException("A valid member is required.");

            List<ReturnRentalItemLookup> items = new List<ReturnRentalItemLookup>();

            const string sql = @"
                SELECT
                    rt.rental_transaction_id,
                    rt.member_id,
                    rti.furniture_id,
                    f.name AS furniture_name,
                    rt.rental_date_time,
                    rt.due_date_time,
                    rti.daily_rate_at_rent,
                    rti.quantity AS quantity_rented,
                    ISNULL(SUM(rturn.quantity_returned), 0) AS quantity_already_returned,
                    rti.quantity - ISNULL(SUM(rturn.quantity_returned), 0) AS quantity_remaining_returnable
                FROM dbo.rental_transactions rt
                INNER JOIN dbo.rental_transaction_items rti
                    ON rt.rental_transaction_id = rti.rental_transaction_id
                INNER JOIN dbo.furniture f
                    ON rti.furniture_id = f.furniture_id
                LEFT JOIN dbo.return_transaction_items rturn
                    ON rti.rental_transaction_id = rturn.rental_transaction_id
                   AND rti.furniture_id = rturn.furniture_id
                WHERE rt.member_id = @MemberId
                GROUP BY
                    rt.rental_transaction_id,
                    rt.member_id,
                    rti.furniture_id,
                    f.name,
                    rt.rental_date_time,
                    rt.due_date_time,
                    rti.daily_rate_at_rent,
                    rti.quantity
                HAVING rti.quantity - ISNULL(SUM(rturn.quantity_returned), 0) > 0
                ORDER BY rt.rental_date_time DESC, rt.rental_transaction_id DESC, rti.furniture_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@MemberId", SqlDbType.Int).Value = memberId;

                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            items.Add(new ReturnRentalItemLookup
                            {
                                RentalTransactionId = r.GetInt32(r.GetOrdinal("rental_transaction_id")),
                                MemberId = r.GetInt32(r.GetOrdinal("member_id")),
                                FurnitureId = r.GetInt32(r.GetOrdinal("furniture_id")),
                                FurnitureName = r.GetString(r.GetOrdinal("furniture_name")),
                                RentalDateTime = r.GetDateTime(r.GetOrdinal("rental_date_time")),
                                DueDateTime = r.GetDateTime(r.GetOrdinal("due_date_time")),
                                DailyRateAtRent = r.GetDecimal(r.GetOrdinal("daily_rate_at_rent")),
                                QuantityRented = r.GetInt32(r.GetOrdinal("quantity_rented")),
                                QuantityAlreadyReturned = r.GetInt32(r.GetOrdinal("quantity_already_returned")),
                                QuantityRemainingReturnable = r.GetInt32(r.GetOrdinal("quantity_remaining_returnable"))
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataException("A database error occurred while loading returnable rental items.", ex);
            }

            return items;
        }

        /// <summary>
        /// Function to retrieve details on return transaction
        /// </summary>
        /// <param name="returnTransactionId">Id of the transaction</param>
        /// <returns>List of items from transaction</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="DataException"></exception>
        public List<ReturnHistoryItem> GetReturnReceiptItems(int returnTransactionId)
        {
            if (returnTransactionId <= 0)
                throw new ArgumentException("A valid return transaction is required.");

            List<ReturnHistoryItem> items = new List<ReturnHistoryItem>();

            const string sql = @"
                SELECT rt.return_transaction_id, rt.return_date_time, rti.rental_transaction_id,
                       e.first_name + ' ' + e.last_name AS employee_name,
                       rti.furniture_id, f.name AS furniture_name, c.category_name,
                       rti.quantity_returned, rti.fine_amount, rti.refund_amount
                FROM dbo.return_transactions rt
                INNER JOIN dbo.return_transaction_items rti ON rt.return_transaction_id = rti.return_transaction_id
                INNER JOIN dbo.furniture f ON rti.furniture_id = f.furniture_id
                INNER JOIN dbo.furniture_categories c ON f.category_id = c.category_id
                INNER JOIN dbo.employees e ON e.employee_id = rt.employee_id
                WHERE rt.return_transaction_id = @ReturnTransactionId
                ORDER BY rti.rental_transaction_id, rti.furniture_id;";

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@ReturnTransactionId", SqlDbType.Int).Value = returnTransactionId;
                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            items.Add(new ReturnHistoryItem
                            {
                                ReturnTransactionId = r.GetInt32(r.GetOrdinal("return_transaction_id")),
                                ReturnDate = r.GetDateTime(r.GetOrdinal("return_date_time")),
                                RentalTransactionId = r.GetInt32(r.GetOrdinal("rental_transaction_id")),
                                EmployeeName = r.GetString(r.GetOrdinal("employee_name")),
                                FurnitureId = r.GetInt32(r.GetOrdinal("furniture_id")),
                                FurnitureName = r.GetString(r.GetOrdinal("furniture_name")),
                                CategoryName = r.GetString(r.GetOrdinal("category_name")),
                                QuantityReturned = r.GetInt32(r.GetOrdinal("quantity_returned")),
                                FineAmount = r.GetDecimal(r.GetOrdinal("fine_amount")),
                                RefundAmount = r.GetDecimal(r.GetOrdinal("refund_amount"))
                            });
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataException("A database error occurred while loading the return receipt.", ex);
            }

            return items;
        }
    }
}