using KLS_Furniture.DAL;
using KLS_Furniture.Model.Return;
using System;
using System.Windows.Forms;

namespace KLS_Furniture.DebugTools
{
    /// <summary>
    /// Temporary helper for manually testing return save flow.
    /// </summary>
    public static class ReturnDebugRunner
    {
        public static void RunReturnSmokeTest()
        {
            ReturnSaveRequest request = new ReturnSaveRequest
            {
                EmployeeId = 1,
                ReturnDateTime = new DateTime(2026, 4, 25, 10, 0, 0)
            };

            request.Items.Add(new ReturnItemInput
            {
                RentalTransactionId = 1,
                FurnitureId = 1,
                FurnitureName = "Pikachu Lounge Chair",
                QuantityToReturn = 1
            });

            request.Items.Add(new ReturnItemInput
            {
                RentalTransactionId = 2,
                FurnitureId = 3,
                FurnitureName = "Bulbasaur Bookshelf",
                QuantityToReturn = 1
            });

            ReturnDBDAL returnDBDAL = new ReturnDBDAL();
            ReturnSaveResult result = returnDBDAL.SaveReturnTransaction(request);

            MessageBox.Show(
                "Return smoke test completed successfully.\n\n" +
                "ReturnTransactionId: " + result.ReturnTransactionId + "\n" +
                "TotalFineAmount: " + result.TotalFineAmount.ToString("0.00") + "\n" +
                "TotalRefundAmount: " + result.TotalRefundAmount.ToString("0.00"),
                "Return Debug Test",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}