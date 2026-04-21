using KLS_Furniture.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;


namespace KLS_Furniture.DAL
{
    /// <summary>
    /// Provides database access methods for admin user reports.
    /// </summary>
    internal class AdminDBDAL
    {
        private readonly string _cs;

        /// <summary>
        /// Initializes DAL and resolves the KLSFurniture database connection string.
        /// </summary>
        public AdminDBDAL()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                _cs = "";
                return;
            }

            _cs = KLSFurnitureDBConnection.GetConnectionString();
        }

        /// <summary>
        /// Returns popular furniture statistics for the given date range.
        /// Only includes furniture rented in at least 2 rental transactions during the period.
        /// </summary>
        public List<PopularFurnitureReportItem> GetPopularFurnitureReport(DateTime startDate, DateTime endDate)
        {
            var report = new List<PopularFurnitureReportItem>();

            const string sql = @"
                WITH QualifiedFurniture AS (
                    SELECT 
                        rti.furniture_id,
                        COUNT(DISTINCT rt.rental_transaction_id) AS rental_transaction_count
                    FROM rental_transactions rt
                    INNER JOIN rental_transaction_items rti ON rt.rental_transaction_id = rti.rental_transaction_id
                    WHERE rt.rental_date_time >= @StartDate 
                    AND rt.rental_date_time < DATEADD(DAY, 1, @EndDate)
                    GROUP BY rti.furniture_id
                    HAVING COUNT(DISTINCT rt.rental_transaction_id) >= 2
                ),
                TotalRentals AS (
                    SELECT COUNT(DISTINCT rental_transaction_id) AS total_rentals
                    FROM rental_transactions
                    WHERE rental_date_time >= @StartDate 
                    AND rental_date_time < DATEADD(DAY, 1, @EndDate)
                ),
                AgeStats AS (
                    SELECT 
                        rti.furniture_id,
                        COUNT(CASE WHEN DATEDIFF(YEAR, m.date_of_birth, rt.rental_date_time) - 
                            CASE WHEN DATEADD(YEAR, DATEDIFF(YEAR, m.date_of_birth, rt.rental_date_time), m.date_of_birth) > rt.rental_date_time 
                            THEN 1 ELSE 0 END BETWEEN 18 AND 29 
                            THEN 1 ELSE NULL END) AS young_count,
                        COUNT(*) AS total_rentals_for_furniture
                    FROM rental_transactions rt
                    INNER JOIN rental_transaction_items rti ON rt.rental_transaction_id = rti.rental_transaction_id
                    INNER JOIN members m ON rt.member_id = m.member_id
                    WHERE rt.rental_date_time >= @StartDate 
                    AND rt.rental_date_time < DATEADD(DAY, 1, @EndDate)
                    GROUP BY rti.furniture_id
                )
                SELECT 
                    f.furniture_id,
                    category_name,
                    f.name AS furniture_name,
                    qf.rental_transaction_count,
                    tr.total_rentals AS total_rental_transactions_in_period,
                    CAST(qf.rental_transaction_count AS DECIMAL(10,4)) / NULLIF(tr.total_rentals, 0) AS percentage_of_total,
                    CAST(ag.young_count AS DECIMAL(10,4)) / NULLIF(ag.total_rentals_for_furniture, 0) AS young_percentage,
                    (1 - CAST(ag.young_count AS DECIMAL(10,4)) / NULLIF(ag.total_rentals_for_furniture, 0)) AS other_age_percentage
                FROM QualifiedFurniture qf
                INNER JOIN furniture f ON qf.furniture_id = f.furniture_id
                LEFT JOIN furniture_categories c ON f.category_id = c.category_id
                CROSS JOIN TotalRentals tr
                LEFT JOIN AgeStats ag ON qf.furniture_id = ag.furniture_id
                ORDER BY qf.rental_transaction_count DESC, qf.furniture_id DESC;";

            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate.Date);
                cmd.Parameters.AddWithValue("@EndDate", endDate.Date);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new PopularFurnitureReportItem
                        {
                            FurnitureId = reader.GetInt32(reader.GetOrdinal("furniture_id")),
                            CategoryName = reader.GetString(reader.GetOrdinal("category_name")),
                            FurnitureName = reader.GetString(reader.GetOrdinal("furniture_name")),
                            RentalTransactionCount = reader.GetInt32(reader.GetOrdinal("rental_transaction_count")),
                            TotalRentalTransactionsInPeriod = reader.GetInt32(reader.GetOrdinal("total_rental_transactions_in_period")),
                            PercentageOfTotalRentals = reader.GetDecimal(reader.GetOrdinal("percentage_of_total")),
                            YoungPercentage = reader.GetDecimal(reader.GetOrdinal("young_percentage")),
                            OtherAgePercentage = reader.GetDecimal(reader.GetOrdinal("other_age_percentage"))
                        };
                        report.Add(item);
                    }
                }
            }

            return report;
        }
    }
}
