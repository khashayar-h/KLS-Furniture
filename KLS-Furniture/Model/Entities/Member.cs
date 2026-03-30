using System;
using System.Collections.Generic;

namespace KLS_Furniture.Model.Entities
{
    /// <summary>
    /// Represents a member from the members table.
    /// </summary>
    public class Member
    {
        public int MemberId { get; set; }

        public string LastName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = "";

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        /// <summary>
        /// Virtual field that returns a formatted full address.
        /// </summary>
        public string FullAddress
        {
            get
            {
                var parts = new List<string>();

                if (!string.IsNullOrWhiteSpace(AddressLine1))
                    parts.Add(AddressLine1.Trim());

                if (!string.IsNullOrWhiteSpace(AddressLine2))
                    parts.Add(AddressLine2.Trim());

                if (!string.IsNullOrWhiteSpace(City))
                    parts.Add(City.Trim());

                if (!string.IsNullOrWhiteSpace(State))
                    parts.Add(State.Trim());

                if (!string.IsNullOrWhiteSpace(ZipCode))
                    parts.Add(ZipCode.Trim());

                return parts.Count > 0
                    ? string.Join(", ", parts)
                    : "No address on file";
            }
        }
    }
}