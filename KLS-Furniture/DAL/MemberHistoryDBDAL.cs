using KLS_Furniture.Model.Lookups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace KLS_Furniture.DAL
{
    /// <summary>
    /// Class to manage the KLSFurniture database member history functions.
    /// </summary>
    public class MemberHistoryDBDAL
    {
        private readonly string _cs;

        /// <summary>
        /// Initializes DAL and resolves the KLSFurniture database connection string.
        /// </summary>
        public MemberHistoryDBDAL()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                _cs = "";
                return;
            }

            _cs = KLSFurnitureDBConnection.GetConnectionString();
        }

        /// <summary>
        /// Returns a list of all rented items for a member.
        /// </summary>
        public List<RentalItem> GetMemberRentalHistory(int memberId)
        {
            var rentalItems = new List<RentalItem>();

            const string sql = @"
                SELECT 
                    rt.rental_transaction_id,
                    rt.rental_date_time,
                    rt.due_date_time,
                    rt.member_id,
                    rt.employee_id,
                    rti.furniture_id,
                    f.name AS furniture_name,
                    c.category_name,
                    rti.quantity,
                    rti.daily_rate_at_rent
                FROM rental_transactions rt
                INNER JOIN rental_transaction_items rti 
                    ON rt.rental_transaction_id = rti.rental_transaction_id
                INNER JOIN furniture f 
                    ON rti.furniture_id = f.furniture_id
                INNER JOIN furniture_categories c 
                    ON f.category_id = c.category_id
                WHERE rt.member_id = @MemberId
                ORDER BY rt.rental_date_time DESC, rti.furniture_id;";

            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MemberId", SqlDbType.Int).Value = memberId;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new RentalItem
                        {
                            RentalTransactionId = reader.GetInt32(reader.GetOrdinal("rental_transaction_id")),
                            RentalDate = reader.GetDateTime(reader.GetOrdinal("rental_date_time")),
                            DueDate = reader.GetDateTime(reader.GetOrdinal("due_date_time")),
                            MemberId = reader.GetInt32(reader.GetOrdinal("member_id")),
                            EmployeeId = reader.GetInt32(reader.GetOrdinal("employee_id")),
                            FurnitureId = reader.GetInt32(reader.GetOrdinal("furniture_id")),
                            FurnitureName = reader.GetString(reader.GetOrdinal("furniture_name")),
                            CategoryName = reader.GetString(reader.GetOrdinal("category_name")),
                            Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                            DailyRateAtRent = reader.GetDecimal(reader.GetOrdinal("daily_rate_at_rent"))
                        };

                        rentalItems.Add(item);
                    }
                }
            }

            return rentalItems;
        }

    }
}
