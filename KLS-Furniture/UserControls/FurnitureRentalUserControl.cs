using KLS_Furniture.Controller;
using KLS_Furniture.Model;
using KLS_Furniture.Model.Lookups;
using KLS_Furniture.Model.Rental;
using KLS_Furniture.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KLS_Furniture.UserControls
{
    public partial class FurnitureRentalUserControl : UserControl
    {
        private readonly RentalController rentalController;
        private readonly BindingSource furnitureBindingSource;
        private readonly BindingSource cartBindingSource;

        private List<RentalCartRow> cartItems;
        private RentalMemberLookupItem selectedMember;

        public FurnitureRentalUserControl()
        {
            InitializeComponent();

            rentalController = new RentalController();
            furnitureBindingSource = new BindingSource();
            cartBindingSource = new BindingSource();

            cartItems = new List<RentalCartRow>();
            selectedMember = null;

            ConfigureFurnitureResultsGrid();
            ConfigureCartGrid();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            this.Load += FurnitureRentalUserControl_Load;
            btnFindMember.Click += BtnFindMember_Click;
            btnSearch.Click += BtnSearch_Click;
            btnAddToCart.Click += BtnAddToCart_Click;
            btnUpdateQty.Click += BtnUpdateQty_Click;
            btnRemoveItem.Click += BtnRemoveItem_Click;
            btnConfirmRental.Click += BtnConfirmRental_Click;
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
                Name = "CartLineTotalColumn",
                HeaderText = "Line Total",
                DataPropertyName = "LineTotal",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        private void FurnitureRentalUserControl_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLookups();
                RefreshCartGrid();
                lblSelectedMemberValue.Text = "No member selected";
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

        private void BtnFindMember_Click(object sender, EventArgs e)
        {
            try
            {
                List<RentalMemberLookupItem> members = rentalController.GetMembersForRental();

                using (MemberPickerForm picker = new MemberPickerForm(members))
                {
                    if (picker.ShowDialog() == DialogResult.OK)
                    {
                        selectedMember = picker.SelectedMember;

                        if (selectedMember != null)
                        {
                            lblSelectedMemberValue.Text = selectedMember.DisplayText;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load members: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                RentalSaveResult result = rentalController.SaveRentalTransaction(request);

                using (RentalReceiptForm receiptForm = new RentalReceiptForm(
                    result.RentalTransactionId,
                    selectedMember.DisplayText,
                    dtpDueDate.Value.Date,
                    cartItems,
                    result.TotalCost))
                {
                    receiptForm.ShowDialog();
                }

                cartItems = new List<RentalCartRow>();
                RefreshCartGrid();
                lblSelectedMemberValue.Text = "No member selected";
                selectedMember = null;
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

        public class RentalCartRow
        {
            public int FurnitureId { get; set; }
            public string FurnitureName { get; set; }
            public int Quantity { get; set; }
            public decimal DailyRateAtRent { get; set; }
            public int QuantityAvailable { get; set; }

            public decimal LineTotal
            {
                get { return Quantity * DailyRateAtRent; }
            }
        }
    }
}