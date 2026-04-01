using System.Collections.Generic;

namespace KLS_Furniture.Model.Rental
{
    /// <summary>
    /// Provides helper methods for rental cost calculations.
    /// </summary>
    public static class RentalCalculator
    {
        /// <summary>
        /// Calculates the total cost for one rental item row.
        /// </summary>
        public static decimal CalculateItemTotal(RentalItemInput item)
        {
            if (item == null)
                return 0m;

            return item.Quantity * item.DailyRateAtRent;
        }

        /// <summary>
        /// Calculates the total cost for the full rental request.
        /// </summary>
        public static decimal CalculateRentalTotal(List<RentalItemInput> items)
        {
            decimal total = 0m;

            if (items == null)
                return total;

            foreach (RentalItemInput item in items)
            {
                total += CalculateItemTotal(item);
            }

            return total;
        }
    }
}