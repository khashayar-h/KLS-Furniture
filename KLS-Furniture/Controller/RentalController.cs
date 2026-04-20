using KLS_Furniture.DAL;
using KLS_Furniture.Model.Lookups;
using KLS_Furniture.Model.Rental;
using System.Collections.Generic;

namespace KLS_Furniture.Controller
{
    /// <summary>
    /// Handles rental UI requests and forwards them to the DAL.
    /// </summary>
    public class RentalController
    {
        private readonly RentalDBDAL _rentalDbDal;

        /// <summary>
        /// Constructor for the RentalController class
        /// </summary>
        public RentalController()
        {
            _rentalDbDal = new RentalDBDAL();
        }

        /// <summary>
        /// Funtion to retrieve all furniture categories
        /// </summary>
        /// <returns>List of furniture categories</returns>
        public List<IdNameLookupItem> GetCategories()
        {
            return _rentalDbDal.GetCategories();
        }

        /// <summary>
        /// Funtion to retrieve all furniture styles
        /// </summary>
        /// <returns>List of furniture styles</returns>
        public List<IdNameLookupItem> GetStyles()
        {
            return _rentalDbDal.GetStyles();
        }

        /// <summary>
        /// Function to pass furniture search params to DAL
        /// </summary>
        /// <param name="furnitureId">Id of an individual piece of furniture</param>
        /// <param name="categoryId"> Id of a furniture category</param>
        /// <param name="styleId">Id of a furniture style</param>
        /// <returns></returns>
        public List<FurnitureSearchResultItem> SearchFurniture(int? furnitureId, int? categoryId, int? styleId)
        {
            return _rentalDbDal.SearchFurniture(furnitureId, categoryId, styleId);
        }

        /// <summary>
        /// Function to pass selected furniture id params to DAL
        /// </summary>
        /// <param name="furnitureId">Id of an individual piece of furniture</param>
        /// <returns></returns>
        public RentalFurnitureLookupItem GetFurnitureForRental(int furnitureId)
        {
            return _rentalDbDal.GetFurnitureForRental(furnitureId);
        }

        /// <summary>
        /// Function to pass rental transaction data to DAL
        /// </summary>
        /// <param name="request">Rental transaction request data</param>
        /// <returns>Results of the rental transaction</returns>
        public RentalSaveResult SaveRentalTransaction(RentalSaveRequest request)
        {
            return _rentalDbDal.SaveRentalTransaction(request);
        }
    }
}