namespace KLS_Furniture.View
{
    partial class RentalReceiptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTransactionId = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.dgvReceiptItems = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRentalDate = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptItems)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTransactionId
            // 
            this.lblTransactionId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTransactionId.AutoSize = true;
            this.lblTransactionId.Location = new System.Drawing.Point(4, 17);
            this.lblTransactionId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransactionId.Name = "lblTransactionId";
            this.lblTransactionId.Size = new System.Drawing.Size(94, 16);
            this.lblTransactionId.TabIndex = 0;
            this.lblTransactionId.Text = "Transaction ID";
            // 
            // lblCustomer
            // 
            this.lblCustomer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(4, 67);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(64, 16);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "Customer";
            // 
            // lblDueDate
            // 
            this.lblDueDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(4, 167);
            this.lblDueDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(64, 16);
            this.lblDueDate.TabIndex = 2;
            this.lblDueDate.Text = "Due Date";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(4, 217);
            this.lblTotalCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(68, 16);
            this.lblTotalCost.TabIndex = 3;
            this.lblTotalCost.Text = "Total Cost";
            // 
            // dgvReceiptItems
            // 
            this.dgvReceiptItems.AllowUserToAddRows = false;
            this.dgvReceiptItems.AllowUserToDeleteRows = false;
            this.dgvReceiptItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvReceiptItems, 2);
            this.dgvReceiptItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceiptItems.Location = new System.Drawing.Point(4, 254);
            this.dgvReceiptItems.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReceiptItems.Name = "dgvReceiptItems";
            this.dgvReceiptItems.ReadOnly = true;
            this.dgvReceiptItems.RowHeadersWidth = 51;
            this.dgvReceiptItems.Size = new System.Drawing.Size(804, 192);
            this.dgvReceiptItems.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Location = new System.Drawing.Point(559, 488);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblRentalDate
            // 
            this.lblRentalDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRentalDate.AutoSize = true;
            this.lblRentalDate.Location = new System.Drawing.Point(3, 117);
            this.lblRentalDate.Name = "lblRentalDate";
            this.lblRentalDate.Size = new System.Drawing.Size(78, 16);
            this.lblRentalDate.TabIndex = 6;
            this.lblRentalDate.Text = "Rental Date";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblTransactionId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblRentalDate, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCustomer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalCost, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDueDate, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgvReceiptItems, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 554);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // RentalReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 554);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RentalReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rental Receipt";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptItems)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTransactionId;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.DataGridView dgvReceiptItems;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRentalDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}