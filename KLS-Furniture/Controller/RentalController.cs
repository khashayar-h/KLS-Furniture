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

        public RentalController()
        {
            _rentalDbDal = new RentalDBDAL();
        }

        public List<IdNameLookupItem> GetCategories()
        {
            return _rentalDbDal.GetCategories();
        }

        public List<IdNameLookupItem> GetStyles()
        {
            return _rentalDbDal.GetStyles();
        }

        public List<RentalMemberLookupItem> GetMembersForRental()
        {
            return _rentalDbDal.GetMembersForRental();
        }

        public List<FurnitureSearchResultItem> SearchFurniture(int? furnitureId, int? categoryId, int? styleId)
        {
            return _rentalDbDal.SearchFurniture(furnitureId, categoryId, styleId);
        }

        public RentalFurnitureLookupItem GetFurnitureForRental(int furnitureId)
        {
            return _rentalDbDal.GetFurnitureForRental(furnitureId);
        }

        public RentalSaveResult SaveRentalTransaction(RentalSaveRequest request)
        {
            return _rentalDbDal.SaveRentalTransaction(request);
        }
    }
}