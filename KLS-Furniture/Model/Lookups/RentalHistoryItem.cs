using System;

namespace KLS_Furniture.Model.Lookups
{
    /// <summary>
    /// Represents one line item from a rental transaction.
    /// </summary>
    public class RentalHistoryItem
    {
        public int RentalTransactionId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public int MemberId { get; set; }
        public string EmployeeName { get; set; }
        public int FurnitureId { get; set; }
        public string FurnitureName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal DailyRateAtRent { get; set; }

        // Calculated fields
        public int DaysRented => (int)Math.Ceiling((DueDate - RentalDate).TotalDays);
        public decimal LineTotal => Quantity * DailyRateAtRent * DaysRented;

    }
}
