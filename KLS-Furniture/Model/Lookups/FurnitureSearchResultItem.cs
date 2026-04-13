namespace KLS_Furniture.Model.Lookups
{
    /// <summary>
    /// Represents one furniture row in the rental search results.
    /// </summary>
    public class FurnitureSearchResultItem
    {
        public int FurnitureId { get; set; }
        public string Name { get; set; } = "";
        public string CategoryName { get; set; } = "";
        public string StyleName { get; set; } = "";
        public decimal DailyRate { get; set; }
        public int QuantityAvailable { get; set; }
    }
}