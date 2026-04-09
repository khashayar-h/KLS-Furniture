using KLS_Furniture.Model.Lookups;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace KLS_Furniture.DAL
{
    /// <summary>
    /// Provides database access methods for employee authentication.
    /// </summary>
    public class EmployeeDBDAL
    {
        private readonly string _cs;

        /// <summary>
        /// Initializes DAL and resolves the KLSFurniture database connection string.
        /// </summary>
        public EmployeeDBDAL()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                _cs = "";
                return;
            }

            _cs = KLSFurnitureDBConnection.GetConnectionString();
        }

        /// <summary>
        /// Updates the password_hash for a given username
        /// </summary>
        public bool UpdatePassword(string username, string newPlainPassword)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(newPlainPassword))
                return false;

            string newHash = HashPasswordForComparison(newPlainPassword);

            const string sql = @"
                                UPDATE dbo.employees 
                                SET password_hash = @NewHash 
                                WHERE username = @Username;";

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@NewHash", SqlDbType.VarChar, 255).Value = newHash;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username.Trim();

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                throw new DataException("Error updating password in database.", ex);
            }
        }

        /// <summary>
        /// Authenticates an employee by username and password.
        /// </summary>
        public LoggedInUserLookupItem AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            LoggedInUserLookupItem user = null;

            const string sql = @"
                SELECT employee_id,
                       username,
                       first_name,
                       last_name,
                       is_admin,
                       password_hash
                FROM dbo.employees
                WHERE username = @Username;";

            try
            {
                using (SqlConnection conn = new SqlConnection(_cs))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = username.Trim();

                    conn.Open();

                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            string storedHash = r.GetString(r.GetOrdinal("password_hash"));
                            if (VerifyPassword(password, storedHash))
                            {
                                user = new LoggedInUserLookupItem
                                {
                                    EmployeeId = r.GetInt32(r.GetOrdinal("employee_id")),
                                    Username = r.GetString(r.GetOrdinal("username")),
                                    FirstName = r.GetString(r.GetOrdinal("first_name")),
                                    LastName = r.GetString(r.GetOrdinal("last_name")),
                                    IsAdmin = r.GetBoolean(r.GetOrdinal("is_admin"))
                                };
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataException("A database error occurred while authenticating the employee.", ex);
            }

            return user;
        }

        /// <summary>
        /// Returns the password value used for database comparison.
        /// </summary>
        private string HashPasswordForComparison(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 10);
        }

        // Verifies valid password
        private bool VerifyPassword(string textPassword, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(textPassword, hashPassword);
        }
    }
}