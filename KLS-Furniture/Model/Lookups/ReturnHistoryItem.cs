using System;

namespace KLS_Furniture.Model.Lookups
{
    /// <summary>
    /// Represents one line item from a return transaction.
    /// </summary>
    public class ReturnHistoryItem
    {
        public int ReturnTransactionId { get; set; }
        public DateTime ReturnDate { get; set; }
        public int RentalTransactionId { get; set; }
        public int EmployeeId { get; set; }
        public int FurnitureId { get; set; }
        public string FurnitureName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public int QuantityReturned { get; set; }
        public decimal FineAmount { get; set; }
        public decimal RefundAmount { get; set; }

        // Calculated fields
        public decimal NetAmount => RefundAmount - FineAmount;

    }
}