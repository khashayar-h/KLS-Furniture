using KLS_Furniture.DAL;
using KLS_Furniture.Model.Lookups;
using KLS_Furniture.Model.Return;
using System.Collections.Generic;

namespace KLS_Furniture.Controller
{
    /// <summary>
    /// Handles return UI requests and forwards them to the DAL.
    /// </summary>
    public class ReturnController
    {
        private readonly ReturnDBDAL _returnDbDal;

        public ReturnController()
        {
            _returnDbDal = new ReturnDBDAL();
        }

        public List<ReturnRentalItemLookup> GetReturnableRentalItemsForMember(int memberId)
        {
            return _returnDbDal.GetReturnableRentalItemsForMember(memberId);
        }

        public ReturnSaveResult SaveReturnTransaction(ReturnSaveRequest request)
        {
            return _returnDbDal.SaveReturnTransaction(request);
        }

        public List<ReturnHistoryItem> GetReturnReceiptItems(int returnTransactionId)
        {
            return _returnDbDal.GetReturnReceiptItems(returnTransactionId);
        }
    }
}