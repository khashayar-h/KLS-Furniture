namespace KLS_Furniture.Model.Rental
{
    /// <summary>
    /// Represents the result of saving a rental transaction.
    /// </summary>
    public class RentalSaveResult
    {
        public int RentalTransactionId { get; set; }
        public decimal TotalCost { get; set; }
    }
}