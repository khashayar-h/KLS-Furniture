using KLS_Furniture.Controller;
using KLS_Furniture.Model;
using KLS_Furniture.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLS_Furniture.UserControls
{
    public partial class MemberHistoryUserControl : UserControl
    {
        private readonly MemberManagementController _controller;
        public MemberHistoryUserControl()
        {
            InitializeComponent();
            _controller = new MemberManagementController();

            WireUpEvents();
            ClearSearchUI();
        }

        /// <summary>
        /// Wires up events from the search control and details control.
        /// </summary>
        private void WireUpEvents()
        {
            // MemberSearchUserControl events
            memberSearchUserControl1.SearchClicked += MemberSearchUserControl_SearchClicked;
            memberSearchUserControl1.ClearClicked += MemberSearchUserControl_ClearClicked;
            memberSearchUserControl1.MemberSelected += MemberSearchUserControl_MemberSelected;

            // TODO: Implement history controls
        }

        /// <summary>
        /// Handles the Search button click from MemberSearchUserControl.
        /// </summary>
        private void MemberSearchUserControl_SearchClicked(object sender, EventArgs e)
        {
            try
            {
                MemberSearchCriteria criteria = memberSearchUserControl1.BuildSearchCriteria();

                if (!criteria.HasAnyCriteria())
                {
                    memberSearchUserControl1.ShowError("Enter at least one search value.");
                    return;
                }

                List<Member> members = _controller.SearchMembers(criteria);
                memberSearchUserControl1.SetDataSource(members);

                if (members.Count == 0)
                {
                    memberSearchUserControl1.ShowMessage("No members found.");
                    return;
                }

                memberSearchUserControl1.ShowMessage($"{members.Count} member(s) found.");
            }
            catch (FormatException ex)
            {
                memberSearchUserControl1.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                memberSearchUserControl1.ShowError("Search failed: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the Clear button click from MemberSearchUserControl.
        /// </summary>
        private void MemberSearchUserControl_ClearClicked(object sender, EventArgs e)
        {
            ClearSearchUI();
        }

        /// <summary>
        /// Displays the selected member in the details panel.
        /// </summary>
        private void MemberSearchUserControl_MemberSelected(object sender, Member selectedMember)
        {
            //TODO: Implement select functionality
        }

        /// <summary>
        /// Clears search fields, grid, and details panel.
        /// </summary>
        private void ClearSearchUI()
        {
            memberSearchUserControl1.Clear();
        }
    }
}
