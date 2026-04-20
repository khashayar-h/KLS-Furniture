using System;

namespace KLS_Furniture.Model.Return
{
    /// <summary>
    /// Represents rental item data needed for the return workflow.
    /// </summary>
    public class ReturnRentalItemLookup
    {
        public int RentalTransactionId { get; set; }
        public int FurnitureId { get; set; }
        public string FurnitureName { get; set; } = "";
        public DateTime RentalDateTime { get; set; }
        public DateTime DueDateTime { get; set; }
        public decimal DailyRateAtRent { get; set; }
        public int QuantityRented { get; set; }
        public int QuantityAlreadyReturned { get; set; }
        public int QuantityRemainingReturnable { get; set; }
    }
}