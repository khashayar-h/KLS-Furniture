using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KLS_Furniture.DAL;
using KLS_Furniture.Model;

namespace KLS_Furniture.Controller
{
    /// <summary>
    /// Handles Member Management actions: Add, Edit, Retrieve, and Search
    /// </summary>
    public class MemberManagementController
    {
        private readonly MemberManagementDBDAL _memberMangagementDAL;

        /// <summary>
        /// Base contructor for MemberManagementController
        /// Initializes DAL instance
        /// </summary>
        public MemberManagementController()
        {
            this._memberMangagementDAL = new MemberManagementDBDAL();
        }

        /// <summary>
        /// Adds a new member via DAL
        /// </summary>
        public Member AddMember(Member newMember) 
        {
            if (newMember == null)
                throw new ArgumentNullException(nameof(newMember));
            
            return _memberMangagementDAL.AddMember(newMember);
        }

        /// <summary>
        /// Updates an existing member via DAL
        /// </summary>
        public Member UpdateMember(Member updateMember)
        {
            if (updateMember == null)
                throw new ArgumentNullException(nameof(updateMember));

            if (updateMember.MemberId < 0)
                throw new ArgumentException("Valid MemberId is required for update.", nameof(updateMember));

            return _memberMangagementDAL.UpdateMember(updateMember);
        }

        /// <summary>
        /// Searches for members based on the entered criteria.
        /// </summary>
        /// <param name="criteria">The optional member search criteria.</param>
        /// <returns>A list of members matching the criteria.</returns>
        public List<Member> SearchMembers(MemberSearchCriteria criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException(nameof(criteria));

            return _memberMangagementDAL.SearchMembers(criteria);
        }
    }
}
