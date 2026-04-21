using KLS_Furniture.DAL;
using KLS_Furniture.Model.Entities;
using System;
using System.Collections.Generic;


namespace KLS_Furniture.Controller
{
    /// <summary>
    /// Admin Controller for reporting data access
    /// </summary>
    internal class AdminController
    {
        private readonly AdminDBDAL adminDBDAL;

        /// <summary>
        /// Initializes a new instance of the AdminController class.
        /// </summary>
        public AdminController()
        {
            this.adminDBDAL = new AdminDBDAL();
        }

        /// <summary>
        /// Call to DAL funtion to get most popular furniture during given time period
        /// </summary>
        /// <param name="startDate">Start date for report</param>
        /// <param name="endDate">End date for report</param>
        /// <returns>List of Popular Furniture Report Item</returns>
        public List<PopularFurnitureReportItem> GetPopularFurnitureReport(DateTime startDate, DateTime endDate)
        {
            return adminDBDAL.GetPopularFurnitureReport(startDate, endDate);
        }
    }
}
