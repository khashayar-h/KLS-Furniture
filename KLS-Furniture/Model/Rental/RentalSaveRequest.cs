using System;
using System.Collections.Generic;

namespace KLS_Furniture.Model.Rental
{
    /// <summary>
    /// Represents the data needed to save one rental transaction.
    /// </summary>
    public class RentalSaveRequest
    {
        public int MemberId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime RentalDateTime { get; set; }
        public DateTime DueDateTime { get; set; }
        public List<RentalItemInput> Items { get; set; } = new List<RentalItemInput>();
    }
}