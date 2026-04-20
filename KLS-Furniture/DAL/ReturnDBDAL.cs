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
    }
}