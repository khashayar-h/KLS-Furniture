using KLS_Furniture.Controller;
using KLS_Furniture.Model;
using KLS_Furniture.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KLS_Furniture.UserControls
{
    /// <summary>
    /// Main user control for member management.
    /// </summary>
    public partial class MemberManageUserControl : UserControl
    {
        private readonly MemberManagementController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberManageUserControl"/> class.
        /// </summary>
        public MemberManageUserControl()
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

            // MemberDetailsControl event
            MemberDetailsControl.MemberSaved += MemberDetailsControl_MemberSaved;
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
                    MemberDetailsControl.ResetDisplay();
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
            if (selectedMember != null)
            {
                MemberDetailsControl.DisplayMember(selectedMember);
            }
        }

        /// <summary>
        ///  Refresh datagrid with latest data from database after update or create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="savedMember"></param>
        private void MemberDetailsControl_MemberSaved(object sender, Member savedMember)
        {
            if (savedMember == null) return;

            RefreshMemberGrid();
            SelectMemberInGrid(savedMember.MemberId);
        }

        /// <summary>
        /// Rerun the current search to get updated data
        /// </summary>
        private void RefreshMemberGrid()
        {
            try
            {
                MemberSearchCriteria criteria = memberSearchUserControl1.BuildSearchCriteria();
                List<Member> members = _controller.SearchMembers(criteria);
                memberSearchUserControl1.SetDataSource(members);

                memberSearchUserControl1.ShowMessage($"{members.Count} member(s) found.");
            }
            catch (Exception ex)
            {
                memberSearchUserControl1.ShowError("Failed to refresh grid: " + ex.Message);
            }
        }

        /// <summary>
        /// Selects the specified member in the grid after add/update
        /// </summary>
        private void SelectMemberInGrid(int memberId)
        {
            // Get the grid from inside the search user control
            var grid = memberSearchUserControl1.Controls
                .OfType<DataGridView>()
                .FirstOrDefault();

            if (grid == null) return;

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.DataBoundItem is Member member && member.MemberId == memberId)
                {
                    grid.ClearSelection();
                    row.Selected = true;
                    grid.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        /// <summary>
        /// Clears search fields, grid, and details panel.
        /// </summary>
        private void ClearSearchUI()
        {
            memberSearchUserControl1.Clear();
            MemberDetailsControl.ResetDisplay();
        }
    }
}