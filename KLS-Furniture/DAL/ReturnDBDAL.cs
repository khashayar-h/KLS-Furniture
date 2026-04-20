using KLS_Furniture.Model.Return;
using System;
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

        private int GetRemainingReturnableQuantity(int rentalTransactionId, int furnitureId)
        {
            int rentedQuantity = GetRentedQuantity(rentalTransactionId, furnitureId);
            int alreadyReturnedQuantity = GetAlreadyReturnedQuantity(rentalTransactionId, furnitureId);

            return rentedQuantity - alreadyReturnedQuantity;
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
    }
}