using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using KLS_Furniture.Model;
using KLS_Furniture.Model.Entities;

namespace KLS_Furniture.DAL
{
    /// <summary>
    /// Class to manage the KLSFurniture database member management functions.
    /// </summary>
    public class MemberManagementDBDAL
    {
        private readonly string _cs;

        /// <summary>
        /// Initializes DAL and resolves the KLSFurniture database connection string.
        /// </summary>
        public MemberManagementDBDAL()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                _cs = "";
                return;
            }

            _cs = KLSFurnitureDBConnection.GetConnectionString();
        }

        /// <summary>
        /// Adds a new member in the database and returns the member.
        /// </summary>
        public Member AddMember(Member newMember)
        {
            if (newMember == null)
                throw new ArgumentNullException(nameof(newMember));

            const string sql = @"INSERT INTO members 
                    (last_name, first_name, sex, date_of_birth, phone, 
                     address_line_1, address_line_2, city, state, zip_code)
                    OUTPUT INSERTED.member_id
                    VALUES
                    (@last_name, @first_name, @sex, @date_of_birth, @phone, 
                     @address_line_1, @address_line_2, @city, @state, @zip_code);";

            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@last_name", newMember.LastName);
                cmd.Parameters.AddWithValue("@first_name", newMember.FirstName);
                cmd.Parameters.AddWithValue("@sex", (object)newMember.Sex ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@date_of_birth", newMember.DateOfBirth);
                cmd.Parameters.AddWithValue("@phone", newMember.Phone);
                cmd.Parameters.AddWithValue("@address_line_1", (object)newMember.AddressLine1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@address_line_2", (object)newMember.AddressLine2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@city", (object)newMember.City ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@state", (object)newMember.State ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@zip_code", (object)newMember.ZipCode ?? DBNull.Value);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    newMember.MemberId = Convert.ToInt32(result);
                }

                return newMember;
            }
        }

        /// <summary>
        /// Updates an existing member in the database and returns the updated member.
        /// </summary>
        public Member UpdateMember(Member member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            if (member.MemberId <= 0)
                throw new ArgumentException("Valid MemberId is required for update.", nameof(member));

            const string sql = @"
                UPDATE members 
                SET last_name      = @last_name,
                    first_name     = @first_name,
                    sex            = @sex,
                    date_of_birth  = @date_of_birth,
                    phone          = @phone,
                    address_line_1 = @address_line_1,
                    address_line_2 = @address_line_2,
                    city           = @city,
                    state          = @state,
                    zip_code       = @zip_code
                WHERE member_id = @member_id;

                SELECT member_id, last_name, first_name, sex, date_of_birth, phone,
                       address_line_1, address_line_2, city, state, zip_code
                FROM members 
                WHERE member_id = @member_id;";

            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@member_id", member.MemberId);
                cmd.Parameters.AddWithValue("@last_name", (object)member.LastName);
                cmd.Parameters.AddWithValue("@first_name", (object)member.FirstName);
                cmd.Parameters.AddWithValue("@sex", (object)member.Sex ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@date_of_birth", member.DateOfBirth);
                cmd.Parameters.AddWithValue("@phone", (object)member.Phone);
                cmd.Parameters.AddWithValue("@address_line_1", (object)member.AddressLine1 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@address_line_2", (object)member.AddressLine2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@city", (object)member.City ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@state", (object)member.State ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@zip_code", (object)member.ZipCode ?? DBNull.Value);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Refresh the member object with latest data from DB
                        member.LastName = reader["last_name"] as string;
                        member.FirstName = reader["first_name"] as string;
                        member.Sex = reader["sex"] as string;
                        member.DateOfBirth = Convert.ToDateTime(reader["date_of_birth"]);
                        member.Phone = reader["phone"] as string;
                        member.AddressLine1 = reader["address_line_1"] as string ?? "";
                        member.AddressLine2 = reader["address_line_2"] as string ?? "";
                        member.City = reader["city"] as string ?? "";
                        member.State = reader["state"] as string;
                        member.ZipCode = reader["zip_code"] as string ?? "";
                    }
                }

                return member;
            }
        }
        /// <summary>
        /// Searches members using optional search criteria.
        /// </summary>
        /// <param name="criteria">The search criteria entered by the user.</param>
        /// <returns>A list of members matching the criteria.</returns>
        public List<Member> SearchMembers(MemberSearchCriteria criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException(nameof(criteria));

            List<Member> members = new List<Member>();

            const string sql = @"
            SELECT member_id, last_name, first_name, sex, date_of_birth, phone,
                   address_line_1, address_line_2, city, state, zip_code
            FROM members
            WHERE (@member_id IS NULL OR member_id = @member_id)
              AND (@phone = '' OR phone LIKE '%' + @phone + '%')
              AND (@first_name = '' OR first_name LIKE @first_name + '%')
              AND (@last_name = '' OR last_name LIKE @last_name + '%')
            ORDER BY last_name, first_name;";

            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@member_id", SqlDbType.Int).Value =
                    criteria.MemberID.HasValue ? (object)criteria.MemberID.Value : DBNull.Value;

                cmd.Parameters.Add("@phone", SqlDbType.VarChar, 20).Value =
                    string.IsNullOrWhiteSpace(criteria.Phone) ? string.Empty : criteria.Phone.Trim();

                cmd.Parameters.Add("@first_name", SqlDbType.VarChar, 50).Value =
                    string.IsNullOrWhiteSpace(criteria.FirstName) ? string.Empty : criteria.FirstName.Trim();

                cmd.Parameters.Add("@last_name", SqlDbType.VarChar, 50).Value =
                    string.IsNullOrWhiteSpace(criteria.LastName) ? string.Empty : criteria.LastName.Trim();

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Member member = new Member
                        {
                            MemberId = Convert.ToInt32(reader["member_id"]),
                            LastName = reader["last_name"] as string ?? "",
                            FirstName = reader["first_name"] as string ?? "",
                            Sex = reader["sex"] as string,
                            DateOfBirth = Convert.ToDateTime(reader["date_of_birth"]),
                            Phone = reader["phone"] as string ?? "",
                            AddressLine1 = reader["address_line_1"] as string ?? "",
                            AddressLine2 = reader["address_line_2"] as string ?? "",
                            City = reader["city"] as string ?? "",
                            State = reader["state"] as string ?? "",
                            ZipCode = reader["zip_code"] as string ?? ""
                        };

                        members.Add(member);
                    }
                }
            }

            return members;
        }
    }
}
