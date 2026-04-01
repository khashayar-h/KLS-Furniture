namespace KLS_Furniture.Model.Rental
{
    /// <summary>
    /// Represents one item in a rental request before the transaction is saved.
    /// </summary>
    public class RentalItemInput
    {
        public int FurnitureId { get; set; }
        public string FurnitureName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal DailyRateAtRent { get; set; }
    }
}