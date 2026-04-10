using KLS_Furniture.UserControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KLS_Furniture.View
{
    public partial class RentalReceiptForm : Form
    {
        public RentalReceiptForm(
            int rentalTransactionId,
            string memberDisplayText,
            DateTime dueDate,
            List<FurnitureRentalUserControl.RentalCartRow> items,
            decimal totalCost)
        {
            InitializeComponent();

            dgvReceiptItems.AutoGenerateColumns = false;
            dgvReceiptItems.DataSource = items;

            lblTransactionId.Text = "Rental Transaction ID: " + rentalTransactionId;
            lblCustomer.Text = "Customer: " + memberDisplayText;
            lblDueDate.Text = "Due Date: " + dueDate.ToShortDateString();
            lblTotalCost.Text = "Total Cost: " + totalCost.ToString("C2");

            btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}