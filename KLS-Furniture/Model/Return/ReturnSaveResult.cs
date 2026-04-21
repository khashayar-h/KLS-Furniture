namespace KLS_Furniture.Model.Return
{
    /// <summary>
    /// Represents the result of saving a return transaction.
    /// </summary>
    public class ReturnSaveResult
    {
        public int ReturnTransactionId { get; set; }
        public decimal TotalFineAmount { get; set; }
        public decimal TotalRefundAmount { get; set; }
    }
}