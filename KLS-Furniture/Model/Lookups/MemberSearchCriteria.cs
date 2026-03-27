using System;

namespace KLS_Furniture.Model
{
    /// <summary>
    /// Stores the optional inputs used to search for members.
    /// </summary>
    public class MemberSearchCriteria
    {
        /// <summary>
        /// Gets or sets the member ID filter.
        /// </summary>
        public int? MemberID { get; set; }

        /// <summary>
        /// Gets or sets the phone filter.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the first name filter.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name filter.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Returns true if at least one search value was entered.
        /// </summary>
        public bool HasAnyCriteria()
        {
            return this.MemberID.HasValue
                || !string.IsNullOrWhiteSpace(this.Phone)
                || !string.IsNullOrWhiteSpace(this.FirstName)
                || !string.IsNullOrWhiteSpace(this.LastName);
        }
    }
}s