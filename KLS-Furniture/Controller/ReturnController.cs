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

        /// <summary>
        /// Constructor of the ReturnController class
        /// </summary>
        public ReturnController()
        {
            _returnDbDal = new ReturnDBDAL();
        }

        /// <summary>
        /// Relays member id to DAL to get items available for return
        /// </summary>
        /// <param name="memberId">Id of the member</param>
        /// <returns>List of items available for return</returns>
        public List<ReturnRentalItemLookup> GetReturnableRentalItemsForMember(int memberId)
        {
            return _returnDbDal.GetReturnableRentalItemsForMember(memberId);
        }

        /// <summary>
        /// Relays return transaction request data to DAL
        /// </summary>
        /// <param name="request">Details of the transaction to be saved</param>
        /// <returns>Result of save transaction</returns>
        public ReturnSaveResult SaveReturnTransaction(ReturnSaveRequest request)
        {
            return _returnDbDal.SaveReturnTransaction(request);
        }

        /// <summary>
        /// Relays return transaction id to DAL for receipt items
        /// </summary>
        /// <param name="returnTransactionId"></param>
        /// <returns>List of receipt items</returns>
        public List<ReturnHistoryItem> GetReturnReceiptItems(int returnTransactionId)
        {
            return _returnDbDal.GetReturnReceiptItems(returnTransactionId);
        }
    }
}