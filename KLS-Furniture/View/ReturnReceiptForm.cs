using KLS_Furniture.Model.Entities;
using KLS_Furniture.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KLS_Furniture.View
{
    /// <summary>
    /// View that displays the information for a return transaction
    /// </summary>
    public partial class ReturnReceiptForm : Form
    {
        /// <summary>
        /// Contructor for ReturnReceiptForm class
        /// </summary>
        /// <param name="returnTransactionId"> Id of the transaction represented</param>
        /// <param name="memberDisplayText">Name of the member who the return belongs to</param>
        /// <param name="totalRefund"> Refund amount of the transaction</param>
        /// <param name="totalFine"> Fine amount of the transaction</param>
        /// <param name="items"> list of items returned during transaction</param>
        public ReturnReceiptForm(
            int returnTransactionId
            , string memberDisplayText
            , decimal totalRefund
            , decimal totalFine
            //, List<TBD> items todo: add correct type
            )
        {
            InitializeComponent();

            TransactionIdLabel.Text = "Return Transaction ID: " + returnTransactionId;
            CustomerLabel.Text = "Customer: " + memberDisplayText;
            ReturnDateLabel.Text = "Return Date: " + DateTime.Today.ToShortDateString();
            RefundLabel.Text = "Total Refund: " + totalRefund.ToString("C2");
            FineLabel.Text = "Total Fine: " + totalFine.ToString("C2");

            //populateTable(items);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void populateTable(List<TBD> items)
        //{
        //    ReceiptDatagrid.DataSource = items;

        //    ReceiptDatagrid.AutoGenerateColumns = true;


        //    // List subject to change based on return line items
        //    ReceiptDatagrid.Columns["ReturnTransactionId"].HeaderText = "Return #";
        //    ReceiptDatagrid.Columns["ReturnDate"].HeaderText = "Rental Date";
        //    ReceiptDatagrid.Columns["EmployeeName"].HeaderText = "Employee";
        //    ReceiptDatagrid.Columns["FurnitureId"].HeaderText = "Furniture Id";
        //    ReceiptDatagrid.Columns["FurnitureName"].HeaderText = "Furniture Item";
        //    ReceiptDatagrid.Columns["CategoryName"].HeaderText = "Category";
        //    ReceiptDatagrid.Columns["Quantity"].HeaderText = "Qty";
        //    ReceiptDatagrid.Columns["FineAmount"].HeaderText = "Fine Amount";
        //    ReceiptDatagrid.Columns["RefundAmount"].HeaderText = "Refund Amount";

        //    ReceiptDatagrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        //}
    }
}
