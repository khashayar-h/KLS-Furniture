using KLS_Furniture.Model.Lookups;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KLS_Furniture.View
{
    /// <summary>
    /// Class def for Return transaction reciept view
    /// </summary>
    public partial class ReturnReceiptForm : Form
    {
        /// <summary>
        /// Contructor for ReturnReceiptForm class
        /// </summary>
        /// <param name="returnTransactionId"> Id of the return transaction</param>
        /// <param name="memberDisplayText">Member who the transaction is for</param>
        /// <param name="totalRefund"> Refund amount of the transaction</param>
        /// <param name="totalFine">Fine Amount of the transaction</param>
        /// <param name="items">List of items that were returned</param>
        public ReturnReceiptForm(
            int returnTransactionId,
            string memberDisplayText,
            decimal totalRefund,
            decimal totalFine,
            List<ReturnHistoryItem> items)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            TransactionIdLabel.Text = "Return Transaction ID: " + returnTransactionId;
            CustomerLabel.Text = "Customer: " + memberDisplayText;
            ReturnDateLabel.Text = "Return Date: " + DateTime.Today.ToShortDateString();
            RefundLabel.Text = "Total Refund: " + (totalRefund * -1).ToString("C2") ;
            FineLabel.Text = "Total Fine: " + totalFine.ToString("C2");
            TransactionTotalLabel.Text = "Transaction Total: " + (totalFine + (totalRefund * -1)).ToString("C2");

            PopulateTable(items);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PopulateTable(List<ReturnHistoryItem> items)
        {
            ReceiptDatagrid.AutoGenerateColumns = false;
            ReceiptDatagrid.Columns.Clear();
            ReceiptDatagrid.ReadOnly = true;
            ReceiptDatagrid.AllowUserToAddRows = false;
            ReceiptDatagrid.AllowUserToDeleteRows = false;
            ReceiptDatagrid.DataSource = items;

            AddColumn("Return #", "ReturnTransactionId");
            AddColumn("Rental #", "RentalTransactionId");
            AddColumn("Rental Date", "RentalDate","d");
            AddColumn("Furniture ID", "FurnitureId");
            AddColumn("Furniture Item", "FurnitureName");
            AddColumn("Qty Returned", "QuantityReturned");
            AddColumn("Fine", "FineAmount", "C2");
            AddColumn("Refund", "RefundAmount", "C2");

            ReceiptDatagrid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void AddColumn(string headerText, string dataPropertyName, string format = null)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
            {
                HeaderText = headerText,
                DataPropertyName = dataPropertyName,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            if (!string.IsNullOrWhiteSpace(format))
            {
                column.DefaultCellStyle = new DataGridViewCellStyle { Format = format };
            }

            ReceiptDatagrid.Columns.Add(column);
        }
    }
}