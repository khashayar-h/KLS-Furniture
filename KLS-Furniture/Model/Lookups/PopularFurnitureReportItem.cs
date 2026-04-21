using System;

namespace KLS_Furniture.Model.Entities
{
    /// <summary>
    /// Represents one row in the Popular Furniture Statistics Report.
    /// </summary>
    public class PopularFurnitureReportItem
    {
        public int FurnitureId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string FurnitureName { get; set; } = string.Empty;

        public int RentalTransactionCount { get; set; }
        public int TotalRentalTransactionsInPeriod { get; set; }

        public decimal PercentageOfTotalRentals { get; set; }

        public decimal YoungPercentage { get; set; }
        public decimal OtherAgePercentage { get; set; }

        // Format percentages
        public string PercentageOfTotalRentalsFormatted => $"{PercentageOfTotalRentals:P2}";
        public string YoungPercentageFormatted => $"{YoungPercentage:P2}";
        public string OtherAgePercentageFormatted => $"{OtherAgePercentage:P2}";
    }
}