using KLS_Furniture.Controller;
using KLS_Furniture.Model;
using KLS_Furniture.Model.Lookups;
using KLS_Furniture.Model.Rental;
using KLS_Furniture.Model.Entities;
using KLS_Furniture.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KLS_Furniture.UserControls
{
    /// <summary>
    /// Class that processes furniture rental process
    /// </summary>
    public partial class FurnitureRentalUserControl : UserControl
    {
        private readonly RentalController rentalController;
        private readonly MemberManagementController _manageController;
        private readonly BindingSource furnitureBindingSource;
        private readonly BindingSource cartBindingSource;

        private List<RentalCartRow> cartItems;
        private Member selectedMember;

        private int _daysRented = 0;

        /// <summary>
        /// Constructor for FurnitureRentalUserControl class
        /// </summary>
        public FurnitureRentalUserControl()
        {
            InitializeComponent();

            rentalController = new RentalController();
            _manageController = new MemberManagementController();
            furnitureBindingSource = new BindingSource();
            cartBindingSource = new BindingSource();

            cartItems = new List<RentalCartRow>();
            selectedMember = null;

            dtpDueDate.MinDate = DateTime.Today.AddDays(1);
            DateTime DueDateTime = dtpDueDate.Value.Date;
            _daysRented = (DueDateTime - DateTime.Today).Days;

            ConfigureFurnitureResultsGrid();
            ConfigureCartGrid();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            this.Load += FurnitureRentalUserControl_Load;
            btnSearch.Click += BtnSearch_Click;
            btnAddToCart.Click += BtnAddToCart_Click;
            btnUpdateQty.Click += BtnUpdateQty_Click;
            btnRemoveItem.Click += BtnRemoveItem_Click;
            btnConfirmRental.Click += BtnConfirmRental_Click;
            dtpDueDate.ValueChanged += dtpDueDate_ValueChanged;
            // MemberSearchUserControl events
            memberSearchUserControl1.SearchClicked += MemberSearchUserControl_SearchClicked;
            memberSearchUserControl1.ClearClicked += MemberSearchUserControl_ClearClicked;
            memberSearchUserControl1.MemberSelected += MemberSearchUserControl_MemberSelected;
        }

        /// <summary>
        /// Handles the Clear button click from MemberSearchUserControl.
        /// </summary>
        private void MemberSearchUserControl_ClearClicked(object sender, EventArgs e)
        {
            ClearSearchUI();
        }

        /// <summary>
        /// Clears search fields, grid, and datagrids.
        /// </summary>
        private void ClearSearchUI()
        {
            memberSearchUserControl1.Clear();
            selectedMember = null;
        }

        /// <summary>
        /// Displays the selected member in the details panel.
        /// </summary>
        private void MemberSearchUserControl_MemberSelected(object sender, Member selectedMember)
        {
            this.selectedMember = selectedMember;

        }

        private void ConfigureFurnitureResultsGrid()
        {
            dgvFurnitureResults.AutoGenerateColumns = false;
            dgvFurnitureResults.Columns.Clear();
            dgvFurnitureResults.DataSource = furnitureBindingSource;

            dgvFurnitureResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FurnitureIdColumn",
                HeaderText = "Furniture ID",
                DataPropertyName = "FurnitureId",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvFurnitureResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FurnitureNameColumn",
                HeaderText = "Name",
                DataPropertyName = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvFurnitureResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CategoryColumn",
                HeaderText = "Category",
                DataPropertyName = "CategoryName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvFurnitureResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StyleColumn",
                HeaderText = "Style",
                DataPropertyName = "StyleName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvFurnitureResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DailyRateColumn",
                HeaderText = "Daily Rate",
                DataPropertyName = "DailyRate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvFurnitureResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AvailableQtyColumn",
                HeaderText = "Available Qty",
                DataPropertyName = "QuantityAvailable",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        private void ConfigureCartGrid()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();
            dgvCart.DataSource = cartBindingSource;

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CartFurnitureIdColumn",
                HeaderText = "Furniture ID",
                DataPropertyName = "FurnitureId",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CartFurnitureNameColumn",
                HeaderText = "Name",
                DataPropertyName = "FurnitureName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CartQuantityColumn",
                HeaderText = "Qty",
                DataPropertyName = "Quantity",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CartDailyRateColumn",
                HeaderText = "Daily Rate",
                DataPropertyName = "DailyRateAtRent",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CartDaysRentedColumn",
                HeaderText = "Days Rented",
                DataPropertyName = "DaysRented",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CartLineTotalColumn",
                HeaderText = "Line Total",
                DataPropertyName = "LineTotal",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        private void dtpDueDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime DueDateTime = dtpDueDate.Value.Date;
            _daysRented = (DueDateTime - DateTime.Today).Days;

            foreach (var item in cartItems)
            {
                item.DaysRented = _daysRented;
            }
            RefreshCartGrid();
        }

        private void FurnitureRentalUserControl_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLookups();
                RefreshCartGrid();
                //lblSelectedMemberValue.Text = "No member selected";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rental page: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLookups()
        {
            List<IdNameLookupItem> categories = rentalController.GetCategories();
            categories.Insert(0, new IdNameLookupItem
            {
                Id = 0,
                Name = "-- All Categories --"
            });

            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
            cboCategory.SelectedIndex = 0;

            List<IdNameLookupItem> styles = rentalController.GetStyles();
            styles.Insert(0, new IdNameLookupItem
            {
                Id = 0,
                Name = "-- All Styles --"
            });

            cboStyle.DataSource = styles;
            cboStyle.DisplayMember = "Name";
            cboStyle.ValueMember = "Id";
            cboStyle.SelectedIndex = 0;

            dtpDueDate.Value = DateTime.Today.AddDays(7);
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

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int? furnitureId = null;

                if (!string.IsNullOrWhiteSpace(txtFurnitureId.Text))
                {
                    if (!int.TryParse(txtFurnitureId.Text.Trim(), out int parsedId))
                    {
                        MessageBox.Show("Furniture ID must be a valid number.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    furnitureId = parsedId;
                }

                int? categoryId = null;
                if (cboCategory.SelectedItem is IdNameLookupItem category && category.Id > 0)
                {
                    categoryId = category.Id;
                }

                int? styleId = null;
                if (cboStyle.SelectedItem is IdNameLookupItem style && style.Id > 0)
                {
                    styleId = style.Id;
                }

                List<FurnitureSearchResultItem> results =
                    rentalController.SearchFurniture(furnitureId, categoryId, styleId);

                furnitureBindingSource.DataSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFurnitureResults.CurrentRow == null)
                {
                    MessageBox.Show("Please select a furniture item first.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FurnitureSearchResultItem selectedSearchItem =
                    dgvFurnitureResults.CurrentRow.DataBoundItem as FurnitureSearchResultItem;

                if (selectedSearchItem == null)
                {
                    MessageBox.Show("Please select a valid furniture item.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                RentalFurnitureLookupItem furniture =
                    rentalController.GetFurnitureForRental(selectedSearchItem.FurnitureId);

                if (furniture == null)
                {
                    MessageBox.Show("Selected furniture item was not found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int requestedQty = (int)nudQuantity.Value;

                RentalCartRow existingItem =
                    cartItems.FirstOrDefault(x => x.FurnitureId == furniture.FurnitureId);

                if (existingItem != null)
                {
                    int newQty = existingItem.Quantity + requestedQty;

                    if (newQty > furniture.QuantityAvailable)
                    {
                        MessageBox.Show("Requested quantity exceeds available quantity.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    existingItem.Quantity = newQty;
                    existingItem.DailyRateAtRent = furniture.DailyRate;
                }
                else
                {
                    if (requestedQty > furniture.QuantityAvailable)
                    {
                        MessageBox.Show("Requested quantity exceeds available quantity.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    cartItems.Add(new RentalCartRow
                    {
                        FurnitureId = furniture.FurnitureId,
                        FurnitureName = furniture.Name,
                        Quantity = requestedQty,
                        DailyRateAtRent = furniture.DailyRate,
                        DaysRented = _daysRented,
                        QuantityAvailable = furniture.QuantityAvailable
                    });
                }

                RefreshCartGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add item: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateQty_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCart.CurrentRow == null)
                {
                    MessageBox.Show("Please select a cart item first.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                RentalCartRow selectedCartItem =
                    dgvCart.CurrentRow.DataBoundItem as RentalCartRow;

                if (selectedCartItem == null)
                {
                    MessageBox.Show("Please select a valid cart item.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                RentalFurnitureLookupItem furniture =
                    rentalController.GetFurnitureForRental(selectedCartItem.FurnitureId);

                if (furniture == null)
                {
                    MessageBox.Show("Selected furniture item no longer exists.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int newQty = (int)nudQuantity.Value;

                if (newQty > furniture.QuantityAvailable)
                {
                    MessageBox.Show("Requested quantity exceeds available quantity.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedCartItem.Quantity = newQty;
                selectedCartItem.DailyRateAtRent = furniture.DailyRate;

                RefreshCartGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not update quantity: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null)
            {
                MessageBox.Show("Please select a cart item first.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RentalCartRow selectedCartItem =
                dgvCart.CurrentRow.DataBoundItem as RentalCartRow;

            if (selectedCartItem == null)
            {
                MessageBox.Show("Please select a valid cart item.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cartItems.Remove(selectedCartItem);
            RefreshCartGrid();
        }

        private void BtnConfirmRental_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedMember == null || selectedMember.MemberId <= 0)
                {
                    MessageBox.Show("Please choose a member first.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cartItems.Count == 0)
                {
                    MessageBox.Show("Please add at least one item to the cart.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!CurrentSession.IsLoggedIn || CurrentSession.LoggedInUser == null)
                {
                    MessageBox.Show("No logged-in employee found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                RentalSaveRequest request = new RentalSaveRequest
                {
                    MemberId = selectedMember.MemberId,
                    EmployeeId = CurrentSession.LoggedInUser.EmployeeId,
                    RentalDateTime = DateTime.Now,
                    DueDateTime = dtpDueDate.Value.Date,
                    Items = cartItems.Select(x => new RentalItemInput
                    {
                        FurnitureId = x.FurnitureId,
                        FurnitureName = x.FurnitureName,
                        Quantity = x.Quantity,
                        DailyRateAtRent = x.DailyRateAtRent
                    }).ToList()
                };

                DialogResult confirmResult = MessageBox.Show(
                    "Please review the rental order before confirming.\n\n" +
                    "Member: " + selectedMember.FirstName + " " + selectedMember.LastName + "\n" +
                    "Due Date: " + dtpDueDate.Value.Date.ToShortDateString() + "\n" +
                    "Total Cost: " + lblTotalCostValue.Text + "\n\n" +
                    "Do you want to complete this rental?",
                    "Confirm Rental",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }

                RentalSaveResult result = rentalController.SaveRentalTransaction(request);

                string employeeName = CurrentSession.LoggedInUser.FirstName + " " + CurrentSession.LoggedInUser.LastName;

                using (RentalReceiptForm receiptForm = new RentalReceiptForm(
                    result.RentalTransactionId,
                    employeeName,
                    $"{selectedMember.FirstName} {selectedMember.LastName}",
                    dtpDueDate.Value.Date,
                    cartItems,
                    result.TotalCost * _daysRented))
                {
                    receiptForm.ShowDialog();
                }

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rental transaction failed: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshCartGrid()
        {
            cartBindingSource.DataSource = null;
            cartBindingSource.DataSource = cartItems.ToList();

            decimal total = cartItems.Sum(x => x.LineTotal);
            lblTotalCostValue.Text = total.ToString("C2");
        }

        private void ClearForm()
        {
            cartItems = new List<RentalCartRow>();
            memberSearchUserControl1.Clear();
            selectedMember = null;
            furnitureBindingSource.DataSource = null;
            cboCategory.SelectedIndex = 0;
            cboStyle.SelectedIndex = 0;
            txtFurnitureId.Text = string.Empty;
            dtpDueDate.Value = DateTime.Today.AddDays(7);
            DateTime DueDateTime = dtpDueDate.Value.Date;
            _daysRented = (DueDateTime - DateTime.Today).Days;
            RefreshCartGrid();

        }

        /// <summary>
        /// Class for population of Rental Cart row items
        /// </summary>
        public class RentalCartRow
        {
            public int FurnitureId { get; set; }
            public string FurnitureName { get; set; }
            public int Quantity { get; set; }
            public decimal DailyRateAtRent { get; set; }
            public int QuantityAvailable { get; set; }
            public int DaysRented { get; set; }

            public decimal LineTotal
            {
                get { return Quantity * DailyRateAtRent * DaysRented; }
            }
        }

        private void CancelRentalButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearSearchButton_Click(object sender, EventArgs e)
        {
            furnitureBindingSource.DataSource = null;
            cboCategory.SelectedIndex = 0;
            cboStyle.SelectedIndex = 0;
            txtFurnitureId.Text = string.Empty;
        }
    }
}