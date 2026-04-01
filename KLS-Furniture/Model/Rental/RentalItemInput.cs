namespace KLS_Furniture.Model.Rental
{
    /// <summary>
    /// Represents one rental item; backend save uses database rates as the source of truth.
    /// </summary>
    public class RentalItemInput
    {
        public int FurnitureId { get; set; }
        public string FurnitureName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal DailyRateAtRent { get; set; }
    }
}