using System.Collections.Generic;

namespace KLS_Furniture.Model.Rental
{
    /// <summary>
    /// Calculates preview totals from item rates already set in the request.
    /// </summary>
    public static class RentalCalculator
    {
        /// <summary>
        /// Calculates preview total for one rental item.
        /// </summary>
        public static decimal CalculateItemTotal(RentalItemInput item)
        {
            if (item == null)
                return 0m;

            return item.Quantity * item.DailyRateAtRent;
        }

        /// <summary>
        /// Calculates preview total for all rental items.
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