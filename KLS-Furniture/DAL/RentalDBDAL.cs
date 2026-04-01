using KLS_Furniture.Model.Rental;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace KLS_Furniture.DAL
{
    /// <summary>
    /// Provides database access methods for rental transactions.
    /// </summary>
    public class RentalDBDAL
    {
        private readonly string _cs;

        /// <summary>
        /// Initializes DAL and resolves the KLSFurniture database connection string.
        /// </summary>
        public RentalDBDAL()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                _cs = "";
                return;
            }

            _cs = KLSFurnitureDBConnection.GetConnectionString();
        }

        /// <summary>
        /// Saves one rental transaction and all related rental items in a single database transaction.
        /// </summary>
        /// <param name="request">
        /// The rental request that contains the member, employee, rental dates, and selected furniture items.
        /// </param>
        /// <returns>
        /// A result object that contains the saved rental transaction id and the calculated total cost.
        /// </returns>
        public RentalSaveResult SaveRentalTransaction(RentalSaveRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.MemberId <= 0)
                throw new ArgumentException("A valid member is required.");

            if (request.EmployeeId <= 0)
                throw new ArgumentException("A valid employee is required.");

            if (request.Items == null || request.Items.Count == 0)
                throw new ArgumentException("At least one rental item is required.");

            if (!MemberExists(request.MemberId))
                throw new ArgumentException("The selected member does not exist.");

            if (!EmployeeExists(request.EmployeeId))
                throw new ArgumentException("The selected employee does not exist.");

            if (request.DueDateTime < request.RentalDateTime)
                throw new ArgumentException("Due date cannot be earlier than rental date.");

            HashSet<int> furnitureIds = new HashSet<int>();

            foreach (RentalItemInput item in request.Items)
            {
                if (item == null)
                    throw new ArgumentException("Rental item cannot be null.");

                if (item.FurnitureId <= 0)
                    throw new ArgumentException("A valid furniture item is required.");

                if (!furnitureIds.Add(item.FurnitureId))
                    throw new ArgumentException("Duplicate furniture items are not allowed in one rental transaction.");

                if (item.Quantity <= 0)
                    throw new ArgumentException("Rental item quantity must be greater than zero.");

                RentalFurnitureLookupItem furniture = GetFurnitureForRental(item.FurnitureId);
                if (furniture == null)
                    throw new ArgumentException("The selected furniture item does not exist.");

                if (item.Quantity > furniture.QuantityAvailable)
                    throw new ArgumentException("Requested quantity exceeds available furniture quantity.");
            }

            RentalSaveResult result = new RentalSaveResult
            {
                TotalCost = 0m
            };

            const string insertRentalSql = @"
                INSERT INTO dbo.rental_transactions
                    (member_id, employee_id, rental_date_time, due_date_time)
                VALUES
                    (@MemberId, @EmployeeId, @RentalDateTime, @DueDateTime);

                SELECT CAST(SCOPE_IDENTITY() AS int);";

            const string insertRentalItemSql = @"
                INSERT INTO dbo.rental_transaction_items
                    (rental_transaction_id, furniture_id, quantity, daily_rate_at_rent)
                VALUES
                    (@RentalTransactionId, @FurnitureId, @Quantity, @DailyRateAtRent);";

            const string updateFurnitureQuantitySql = @"
                UPDATE dbo.furniture
                SET quantity = quantity - @Quantity
                WHERE furniture_id = @FurnitureId
                  AND quantity >= @Quantity;";

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand rentalCmd = new SqlCommand(insertRentalSql, conn, transaction))
                            {
                                rentalCmd.Parameters.Add("@MemberId", SqlDbType.Int).Value = request.MemberId;
                                rentalCmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = request.EmployeeId;
                                rentalCmd.Parameters.Add("@RentalDateTime", SqlDbType.DateTime2).Value = request.RentalDateTime;
                                rentalCmd.Parameters.Add("@DueDateTime", SqlDbType.DateTime2).Value = request.DueDateTime;

                                result.RentalTransactionId = Convert.ToInt32(rentalCmd.ExecuteScalar());
                            }

                            foreach (RentalItemInput item in request.Items)
                            {
                                RentalFurnitureLookupItem furniture = GetFurnitureForRental(item.FurnitureId);
                                decimal dbRate = furniture.DailyRate;

                                result.TotalCost += item.Quantity * dbRate;

                                using (SqlCommand itemCmd = new SqlCommand(insertRentalItemSql, conn, transaction))
                                {
                                    itemCmd.Parameters.Add("@RentalTransactionId", SqlDbType.Int).Value = result.RentalTransactionId;
                                    itemCmd.Parameters.Add("@FurnitureId", SqlDbType.Int).Value = item.FurnitureId;
                                    itemCmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = item.Quantity;
                                    itemCmd.Parameters.Add("@DailyRateAtRent", SqlDbType.Decimal).Value = dbRate;

                                    itemCmd.ExecuteNonQuery();
                                }

                                using (SqlCommand updateQtyCmd = new SqlCommand(updateFurnitureQuantitySql, conn, transaction))
                                {
                                    updateQtyCmd.Parameters.Add("@FurnitureId", SqlDbType.Int).Value = item.FurnitureId;
                                    updateQtyCmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = item.Quantity;

                                    int rowsAffected = updateQtyCmd.ExecuteNonQuery();

                                    if (rowsAffected != 1)
                                        throw new DataException("Unable to update available furniture quantity.");
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
                throw new DataException("A database error occurred while saving the rental transaction.", ex);
            }

            return result;
        }

        /// <summary>
        /// Returns basic furniture data needed for the rental workflow.
        /// </summary>
        /// <param name="furnitureId">
        /// The furniture id to look up.
        /// </param>
        /// <returns>
        /// A lookup item containing the furniture id, name, daily rate, and available quantity.
        /// Returns null if the furniture item is not found.
        /// </returns>
        public RentalFurnitureLookupItem GetFurnitureForRental(int furnitureId)
        {
            if (furnitureId <= 0)
                throw new ArgumentException("A valid furniture id is required.");

            RentalFurnitureLookupItem furniture = null;

            const string sql = @"
                SELECT furniture_id,
                       name,
                       daily_rate,
                       quantity
                FROM dbo.furniture
                WHERE furniture_id = @FurnitureId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@FurnitureId", SqlDbType.Int).Value = furnitureId;

                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            furniture = new RentalFurnitureLookupItem
                            {
                                FurnitureId = r.GetInt32(r.GetOrdinal("furniture_id")),
                                Name = r.GetString(r.GetOrdinal("name")),
                                DailyRate = r.GetDecimal(r.GetOrdinal("daily_rate")),
                                QuantityAvailable = r.GetInt32(r.GetOrdinal("quantity"))
                            };
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataException("A database error occurred while loading furniture for rental.", ex);
            }

            return furniture;
        }

        private bool MemberExists(int memberId)
        {
            const string sql = @"
                SELECT COUNT(1)
                FROM dbo.members
                WHERE member_id = @MemberId;";

            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@MemberId", SqlDbType.Int).Value = memberId;
                conn.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
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
    }
}