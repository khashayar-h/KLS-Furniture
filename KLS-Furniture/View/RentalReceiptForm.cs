using KLS_Furniture.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KLS_Furniture.View
{
    /// <summary>
    /// View that displays the information for a rental transaction
    /// </summary>
    public partial class RentalReceiptForm : Form
    {
        private readonly BindingSource _bindingSource;

        /// <summary>
        /// Contructor for RentalReceiptForm class
        /// </summary>
        /// <param name="rentalTransactionId"> Id of the transaction represented</param>
        /// <param name="memberDisplayText">Name of the member who the rental belongs to</param>
        /// <param name="dueDate">Date the rental is due to be returned</param>
        /// <param name="items"> list of items rented during transaction</param>
        /// <param name="totalCost"> Cost of the transaction</param>
        public RentalReceiptForm(
            int rentalTransactionId,
            string memberDisplayText,
            DateTime dueDate,
            List<FurnitureRentalUserControl.RentalCartRow> items,
            decimal totalCost)
        {
            InitializeComponent();

            _bindingSource = new BindingSource();

            ConfigureGrid();

            _bindingSource.DataSource = items;

            lblTransactionId.Text = "Rental Transaction ID: " + rentalTransactionId;
            lblCustomer.Text = "Customer: " + memberDisplayText;
            lblRentalDate.Text = "Rental Date: " + DateTime.Today.ToShortDateString();
            lblDueDate.Text = "Due Date: " + dueDate.ToShortDateString();
            lblTotalCost.Text = "Total Cost: " + totalCost.ToString("C2");

            btnClose.Click += BtnClose_Click;
        }

        private void ConfigureGrid()
        {
            dgvReceiptItems.AllowUserToAddRows = false;
            dgvReceiptItems.AutoGenerateColumns = false;
            dgvReceiptItems.Columns.Clear();

            dgvReceiptItems.DataSource = _bindingSource;

            dgvReceiptItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReceiptFurnitureIdColumn",
                HeaderText = "Item ID",
                DataPropertyName = "FurnitureId",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvReceiptItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReceiptFurnitureNameColumn",
                HeaderText = "Name",
                DataPropertyName = "FurnitureName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvReceiptItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReceiptQuantityColumn",
                HeaderText = "Qty",
                DataPropertyName = "Quantity",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvReceiptItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReceiptRateColumn",
                HeaderText = "Unit Price",
                DataPropertyName = "DailyRateAtRent",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvReceiptItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReceiptLineTotalColumn",
                HeaderText = "Line Total",
                DataPropertyName = "LineTotal",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}