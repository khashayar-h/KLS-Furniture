using System;

namespace KLS_Furniture.Model.Return
{
    /// <summary>
    /// Calculates fine and refund amounts for return items.
    /// </summary>
    public static class ReturnCalculator
    {
        /// <summary>
        /// Calculates the fine amount for one returned item.
        /// </summary>
        public static decimal CalculateFine(DateTime dueDateTime, DateTime returnDateTime, decimal dailyRateAtRent, int quantityToReturn)
        {
            if (returnDateTime.Date <= dueDateTime.Date)
                return 0m;

            int overdueDays = (int)Math.Ceiling((returnDateTime.Date - dueDateTime.Date).TotalDays);
            if (overdueDays < 0)
                overdueDays = 0;

            return overdueDays * dailyRateAtRent * quantityToReturn;
        }

        /// <summary>
        /// Calculates the refund amount for one returned item.
        /// </summary>
        public static decimal CalculateRefund(DateTime rentalDateTime, DateTime dueDateTime, DateTime returnDateTime, decimal dailyRateAtRent, int quantityToReturn)
        {
            if (returnDateTime.Date >= dueDateTime.Date)
                return 0m;

            // Calculate total days the item was supposed to be rented
            int totalRentalDays = (int)Math.Ceiling((dueDateTime.Date - rentalDateTime.Date).TotalDays);
            if (totalRentalDays < 1)
                totalRentalDays = 1;

            // Calculate days actually used
            int daysUsed = (int)Math.Ceiling((returnDateTime.Date - rentalDateTime.Date).TotalDays);
            if (daysUsed < 1)
                daysUsed = 1;

            int unusedDays = totalRentalDays - daysUsed;
            if (unusedDays < 0)
                unusedDays = 0;

            return unusedDays * dailyRateAtRent * quantityToReturn;
        }
    }
}
