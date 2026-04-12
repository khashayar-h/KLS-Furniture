using KLS_Furniture.DAL;
using KLS_Furniture.Model.Rental;
using System;
using System.Windows.Forms;

namespace KLS_Furniture.DebugTools
{
    /// <summary>
    /// Temporary helper for manually testing rental save flow.
    /// </summary>
    public static class RentalDebugRunner
    {
        public static void RunRentalSaveSmokeTest()
        {
            RentalSaveRequest request = new RentalSaveRequest
            {
                MemberId = 10000,
                EmployeeId = 1,
                RentalDateTime = DateTime.Now,
                DueDateTime = DateTime.Now.AddDays(3)
            };

            request.Items.Add(new RentalItemInput
            {
                FurnitureId = 1,
                FurnitureName = "Pikachu Lounge Chair",
                Quantity = 2,
                DailyRateAtRent = 12.99m
            });

            request.Items.Add(new RentalItemInput
            {
                FurnitureId = 5,
                FurnitureName = "Charizard Gaming Desk",
                Quantity = 1,
                DailyRateAtRent = 18.99m
            });

            RentalDBDAL rentalDBDAL = new RentalDBDAL();
            RentalSaveResult result = rentalDBDAL.SaveRentalTransaction(request);

            MessageBox.Show(
                "Rental save test completed successfully.\n\n" +
                "RentalTransactionId: " + result.RentalTransactionId + "\n" +
                "TotalCost: " + result.TotalCost.ToString("0.00"),
                "Rental Debug Test",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}