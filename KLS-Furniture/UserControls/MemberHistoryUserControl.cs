using KLS_Furniture.Controller;
using KLS_Furniture.Model;
using KLS_Furniture.Model.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KLS_Furniture.UserControls
{
    /// <summary>
    /// Main user control for member history.
    /// </summary>
    public partial class MemberHistoryUserControl : UserControl
    {
        private readonly MemberManagementController _manageController;
        private readonly MemberHistoryController _historyController;
        private Member _selectedMember;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberHistoryUserControl"/> class.
        /// </summary>
        public MemberHistoryUserControl()
        {
            InitializeComponent();
            _manageController = new MemberManagementController();
            _historyController = new MemberHistoryController();

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

                List<Member> members = _manageController.SearchMembers(criteria);
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
            _selectedMember = selectedMember;

            if (HistoryTabControl.SelectedTab.Name == "RentalTabPage")
                PopulateRentalTable();
            else
                PopulateReturnTable();
        }

        /// <summary>
        /// Clears search fields, grid, and datagrids.
        /// </summary>
        private void ClearSearchUI()
        {
            memberSearchUserControl1.Clear();
            _selectedMember = null;
            RentalDataGridView.DataSource = null;
            ReturnDataGridView.DataSource = null;
        }

        /// <summary>
        /// Handles tab change to load data for the visible tab
        /// </summary>
        private void HandleTabClick_SelectedIndexChange(object sender, EventArgs e)
        {
            if (_selectedMember == null) return;

            if (HistoryTabControl.SelectedTab.Name == "RentalTabPage")
            {
                PopulateRentalTable();
            }
            else
            {
                PopulateReturnTable();
            }
        }

        /// <summary>
        /// Populates the Rental DataGridView
        /// </summary>
        private void PopulateRentalTable()
        {
            if (_selectedMember == null) return;

            try
            {
                var rentals = _historyController.GetMemberRentalHistory(_selectedMember.MemberId);
                RentalDataGridView.DataSource = rentals;

                RentalDataGridView.AutoGenerateColumns = true;

                RentalDataGridView.Columns["RentalTransactionId"].HeaderText = "Rental #";
                RentalDataGridView.Columns["RentalDate"].HeaderText = "Rental Date";
                RentalDataGridView.Columns["DueDate"].HeaderText = "Due Date";
                RentalDataGridView.Columns["MemberId"].HeaderText = "Member Id";
                RentalDataGridView.Columns["EmployeeName"].HeaderText = "Employee";
                RentalDataGridView.Columns["FurnitureId"].HeaderText = "Furniture Id";
                RentalDataGridView.Columns["FurnitureName"].HeaderText = "Furniture Item";
                RentalDataGridView.Columns["CategoryName"].HeaderText = "Category";
                RentalDataGridView.Columns["Quantity"].HeaderText = "Qty";
                RentalDataGridView.Columns["DaysRented"].HeaderText = "Days Rented";
                RentalDataGridView.Columns["DailyRateAtRent"].HeaderText = "Daily Rate";
                RentalDataGridView.Columns["LineTotal"].HeaderText = "Line Total";

                RentalDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load rental history: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Populates the Return DataGridView
        /// </summary>
        private void PopulateReturnTable()
        {
            if (_selectedMember == null) return;

            try
            {
                var returns = _historyController.GetMemberReturnHistory(_selectedMember.MemberId);
                ReturnDataGridView.DataSource = returns;

                ReturnDataGridView.Columns["ReturnTransactionId"].HeaderText = "Return #";
                ReturnDataGridView.Columns["ReturnDate"].HeaderText = "Return Date";
                ReturnDataGridView.Columns["RentalTransactionId"].HeaderText = "Orig. Rental #";
                ReturnDataGridView.Columns["RentalDate"].HeaderText = "Rental Date";
                ReturnDataGridView.Columns["EmployeeName"].HeaderText = "Employee";
                ReturnDataGridView.Columns["FurnitureId"].HeaderText = "Furniture Id";
                ReturnDataGridView.Columns["FurnitureName"].HeaderText = "Furniture Item";
                ReturnDataGridView.Columns["CategoryName"].HeaderText = "Category";
                ReturnDataGridView.Columns["QuantityReturned"].HeaderText = "Qty Returned";
                ReturnDataGridView.Columns["FineAmount"].HeaderText = "Fine";
                ReturnDataGridView.Columns["RefundAmount"].HeaderText = "Refund";
                ReturnDataGridView.Columns["NetAmount"].HeaderText = "Net Amount";

                ReturnDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load return history: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
