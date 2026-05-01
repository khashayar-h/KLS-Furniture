using KLS_Furniture.Controller;
using KLS_Furniture.Model;
using KLS_Furniture.Model.Entities;
using KLS_Furniture.Model.Lookups;
using KLS_Furniture.Model.Return;
using KLS_Furniture.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KLS_Furniture.UserControls
{
    /// <summary>
    /// Class that handles return transaction functionality
    /// </summary>
    public partial class FurnitureReturnUserControl : UserControl
    {
        private readonly MemberManagementController _memberController = new MemberManagementController();
        private readonly ReturnController _returnController = new ReturnController();
        private readonly BindingSource _rentalItemsSource = new BindingSource();
        private readonly BindingSource _cartSource = new BindingSource();
        private readonly List<ReturnCartRow> _cartItems = new List<ReturnCartRow>();

        private Member _selectedMember;

        /// <summary>
        /// Constructor of FurnitureReturnUserControl class
        /// </summary>
        public FurnitureReturnUserControl()
        {
            InitializeComponent();
            WireEvents();
            ConfigureReturnableGrid();
            ConfigureCartGrid();
            RefreshCart();
        }

        private void WireEvents()
        {
            memberSearchUserControl1.SearchClicked += MemberSearchUserControl_SearchClicked;
            memberSearchUserControl1.ClearClicked += (s, e) => ClearAll();
            memberSearchUserControl1.MemberSelected += MemberSearchUserControl_MemberSelected;

            btnAddItem.Click += BtnAddItem_Click;
            btnUpdateQuantity.Click += BtnUpdateQuantity_Click;
            btnRemoveItem.Click += BtnRemoveItem_Click;
            btnConfirmReturn.Click += BtnConfirmReturn_Click;
            btnClear.Click += (s, e) => ClearAll();
        }

        private void ConfigureReturnableGrid()
        {
            dgvReturnableItems.AutoGenerateColumns = false;
            dgvReturnableItems.Columns.Clear();
            dgvReturnableItems.DataSource = _rentalItemsSource;

            AddTextColumn(dgvReturnableItems, "Rental #", "RentalTransactionId");
            AddTextColumn(dgvReturnableItems, "Furniture ID", "FurnitureId");
            AddTextColumn(dgvReturnableItems, "Name", "FurnitureName");
            AddTextColumn(dgvReturnableItems, "Rented", "QuantityRented");
            AddTextColumn(dgvReturnableItems, "Already Returned", "QuantityAlreadyReturned");
            AddTextColumn(dgvReturnableItems, "Remaining", "QuantityRemainingReturnable");
            AddTextColumn(dgvReturnableItems, "Due Date", "DueDateTime", "d");
            AddTextColumn(dgvReturnableItems, "Daily Rate", "DailyRateAtRent", "C2");
        }

        private void ConfigureCartGrid()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();
            dgvCart.DataSource = _cartSource;

            AddTextColumn(dgvCart, "Rental #", "RentalTransactionId");
            AddTextColumn(dgvCart, "Furniture ID", "FurnitureId");
            AddTextColumn(dgvCart, "Name", "FurnitureName");
            AddTextColumn(dgvCart, "Qty Return", "QuantityToReturn");
            AddTextColumn(dgvCart, "Fine", "FineAmount", "C2");
            AddTextColumn(dgvCart, "Refund", "RefundAmount", "C2");
        }

        private void AddTextColumn(DataGridView grid, string header, string property, string format = null)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
            {
                HeaderText = header,
                DataPropertyName = property,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            if (!string.IsNullOrWhiteSpace(format))
            {
                column.DefaultCellStyle = new DataGridViewCellStyle { Format = format };
            }

            grid.Columns.Add(column);
        }

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

                List<Member> members = _memberController.SearchMembers(criteria);
                memberSearchUserControl1.SetDataSource(members);
                memberSearchUserControl1.ShowMessage(members.Count + " member(s) found.");
            }
            catch (Exception ex)
            {
                memberSearchUserControl1.ShowError("Search failed: " + ex.Message);
            }
        }

        private void MemberSearchUserControl_MemberSelected(object sender, Member member)
        {
            _selectedMember = member;
            lblSelectedMember.Text = "Selected Member: " + member.FirstName + " " + member.LastName + " (#" + member.MemberId + ")";

            _cartItems.Clear();
            LoadReturnableItems();
            RefreshCart();
        }

        private void LoadReturnableItems()
        {
            if (_selectedMember == null)
            {
                _rentalItemsSource.DataSource = null;
                return;
            }

            _rentalItemsSource.DataSource = _returnController.GetReturnableRentalItemsForMember(_selectedMember.MemberId);
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            ReturnRentalItemLookup selected = dgvReturnableItems.CurrentRow?.DataBoundItem as ReturnRentalItemLookup;

            if (selected == null)
            {
                MessageBox.Show("Select a rental item to return first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qty = (int)nudQuantity.Value;

            ReturnCartRow existing = _cartItems.FirstOrDefault(x =>
                x.RentalTransactionId == selected.RentalTransactionId &&
                x.FurnitureId == selected.FurnitureId);

            int newTotalQty = qty + (existing?.QuantityToReturn ?? 0);

            if (newTotalQty > selected.QuantityRemainingReturnable)
            {
                MessageBox.Show("Return quantity exceeds remaining returnable quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existing == null)
            {
                _cartItems.Add(new ReturnCartRow(selected, qty));
            }
            else
            {
                existing.QuantityToReturn = newTotalQty;
            }

            RefreshCart();
        }

        private void BtnUpdateQuantity_Click(object sender, EventArgs e)
        {
            ReturnCartRow selected = dgvCart.CurrentRow?.DataBoundItem as ReturnCartRow;

            if (selected == null)
            {
                MessageBox.Show("Select a return cart item first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qty = (int)nudQuantity.Value;

            if (qty > selected.QuantityRemainingReturnable)
            {
                MessageBox.Show("Return quantity exceeds remaining returnable quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selected.QuantityToReturn = qty;
            RefreshCart();
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            ReturnCartRow selected = dgvCart.CurrentRow?.DataBoundItem as ReturnCartRow;

            if (selected == null)
            {
                MessageBox.Show("Select a return cart item first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _cartItems.Remove(selected);
            RefreshCart();
        }

        private void BtnConfirmReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedMember == null)
                {
                    MessageBox.Show("Please choose a member first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_cartItems.Count == 0)
                {
                    MessageBox.Show("Please add at least one item to return.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!CurrentSession.IsLoggedIn || CurrentSession.LoggedInUser == null)
                {
                    MessageBox.Show("No logged-in employee found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal totalFine = _cartItems.Sum(x => x.FineAmount);
                decimal totalRefund = _cartItems.Sum(x => x.RefundAmount) *-1;

                DialogResult confirm = MessageBox.Show(
                    "Finalize this return?\n\nItems: " + _cartItems.Count +
                    "\nTotal Fine: " + totalFine.ToString("C2") +
                    "\nTotal Refund: " + totalRefund.ToString("C2") +
                    "\nTotal Balance: " + (totalFine + totalRefund).ToString("C2"),
                    "Confirm Return",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                {
                    return;
                }

                ReturnSaveRequest request = new ReturnSaveRequest
                {
                    EmployeeId = CurrentSession.LoggedInUser.EmployeeId,
                    ReturnDateTime = DateTime.Now,
                    Items = _cartItems.Select(x => new ReturnItemInput
                    {
                        RentalTransactionId = x.RentalTransactionId,
                        FurnitureId = x.FurnitureId,
                        FurnitureName = x.FurnitureName,
                        QuantityToReturn = x.QuantityToReturn
                    }).ToList()
                };

                ReturnSaveResult result = _returnController.SaveReturnTransaction(request);
                List<ReturnHistoryItem> receiptItems = _returnController.GetReturnReceiptItems(result.ReturnTransactionId);

                string employeeName = CurrentSession.LoggedInUser.FirstName + " " + CurrentSession.LoggedInUser.LastName;
                using (ReturnReceiptForm receipt = new ReturnReceiptForm(
                    result.ReturnTransactionId,
                    employeeName,
                    _selectedMember.FirstName + " " + _selectedMember.LastName,
                    result.TotalRefundAmount,
                    result.TotalFineAmount,
                    receiptItems))
                {
                    receipt.ShowDialog();
                }

                _cartItems.Clear();
                LoadReturnableItems();
                RefreshCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Return transaction failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCart()
        {
            foreach (ReturnCartRow item in _cartItems)
            {
                item.Recalculate(DateTime.Now);
            }

            _cartSource.DataSource = null;
            _cartSource.DataSource = _cartItems.ToList();

            decimal fineTotal = _cartItems.Sum(x => x.FineAmount);
            decimal refundTotal = _cartItems.Sum(x => x.RefundAmount) * -1;

            lblTotals.Text = "Fine: " + fineTotal.ToString("C2") +
                             "   Refund: " + refundTotal.ToString("C2") +
                             "   Total: " + (fineTotal + refundTotal).ToString("C2");
        }

        private void ClearAll()
        {
            _selectedMember = null;
            lblSelectedMember.Text = "Selected Member: None";

            memberSearchUserControl1.Clear();

            _rentalItemsSource.DataSource = null;
            _cartItems.Clear();

            RefreshCart();
        }

        private class ReturnCartRow
        {
            private readonly DateTime _rentalDateTime;
            private readonly DateTime _dueDateTime;
            private readonly decimal _dailyRateAtRent;

            /// <summary>
            /// Constructor of ReturnCartRow class
            /// </summary>
            /// <param name="item"> item being returned</param>
            /// <param name="quantity">quantity of return</param>
            public ReturnCartRow(ReturnRentalItemLookup item, int quantity)
            {
                RentalTransactionId = item.RentalTransactionId;
                FurnitureId = item.FurnitureId;
                FurnitureName = item.FurnitureName;
                QuantityRemainingReturnable = item.QuantityRemainingReturnable;

                _rentalDateTime = item.RentalDateTime;
                _dueDateTime = item.DueDateTime;
                _dailyRateAtRent = item.DailyRateAtRent;

                QuantityToReturn = quantity;
                Recalculate(DateTime.Now);
            }

            /// <summary>
            /// Getter/Setter functions for ReturnCartRow item fields
            /// </summary>
            public int RentalTransactionId { get; set; }
            public int FurnitureId { get; set; }
            public string FurnitureName { get; set; }
            public int QuantityToReturn { get; set; }
            public int QuantityRemainingReturnable { get; set; }
            public decimal FineAmount { get; private set; }
            public decimal RefundAmount { get; private set; }

            /// <summary>
            /// Function to calculate refund and fine amounts
            /// </summary>
            /// <param name="returnDateTime">Date of return</param>
            public void Recalculate(DateTime returnDateTime)
            {
                FineAmount = ReturnCalculator.CalculateFine(_dueDateTime, returnDateTime, _dailyRateAtRent, QuantityToReturn);
                RefundAmount = ReturnCalculator.CalculateRefund(_rentalDateTime, _dueDateTime, returnDateTime, _dailyRateAtRent, QuantityToReturn);
            }
        }
    }
}
