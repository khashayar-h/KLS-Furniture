namespace KLS_Furniture.Model.Rental
{
    /// <summary>
    /// Represents basic furniture data needed for the rental flow.
    /// </summary>
    public class RentalFurnitureLookupItem
    {
        public int FurnitureId { get; set; }
        public string Name { get; set; } = "";
        public decimal DailyRate { get; set; }
        public int QuantityAvailable { get; set; }
    }
}