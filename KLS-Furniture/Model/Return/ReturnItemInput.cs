namespace KLS_Furniture.Model.Return
{
    /// <summary>
    /// Represents one item selected for return before the transaction is saved.
    /// </summary>
    public class ReturnItemInput
    {
        public int RentalTransactionId { get; set; }
        public int FurnitureId { get; set; }
        public string FurnitureName { get; set; } = "";
        public int QuantityToReturn { get; set; }
    }
}