using KLS_Furniture.DAL;
using KLS_Furniture.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KLS_Furniture.Model.Lookups;

namespace KLS_Furniture.Controller
{
    /// <summary>
    /// Handles Member History retrieval actions
    /// </summary>
    public class MemberHistoryController
    {
        private readonly MemberHistoryDBDAL _memberHistoryDAL;

        /// <summary>
        /// Base contructor for MemberHistoryController
        /// Initializes DAL instance
        /// </summary>
        public MemberHistoryController()
        {
            this._memberHistoryDAL = new MemberHistoryDBDAL();
        }

        public List<RentalHistoryItem> GetMemberRentalHistory(int memberId)
        {
            return _memberHistoryDAL.GetMemberRentalHistory(memberId);
        }

        public List<ReturnHistoryItem> GetMemberReturnHistory(int memberId)
        {
            return _memberHistoryDAL.GetMemberReturnHistory(memberId);
        }
    }
}
