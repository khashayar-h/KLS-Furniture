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
            this.colReceiptFurnitureId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiptFurnitureName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiptQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiptRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceiptLineTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTransactionId
            // 
            this.lblTransactionId.AutoSize = true;
            this.lblTransactionId.Location = new System.Drawing.Point(41, 28);
            this.lblTransactionId.Name = "lblTransactionId";
            this.lblTransactionId.Size = new System.Drawing.Size(35, 13);
            this.lblTransactionId.TabIndex = 0;
            this.lblTransactionId.Text = "label1";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(41, 65);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(35, 13);
            this.lblCustomer.TabIndex = 1;
            this.lblCustomer.Text = "label2";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(41, 105);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(35, 13);
            this.lblDueDate.TabIndex = 2;
            this.lblDueDate.Text = "label3";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(41, 143);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(35, 13);
            this.lblTotalCost.TabIndex = 3;
            this.lblTotalCost.Text = "label4";
            // 
            // dgvReceiptItems
            // 
            this.dgvReceiptItems.AllowUserToAddRows = false;
            this.dgvReceiptItems.AllowUserToDeleteRows = false;
            this.dgvReceiptItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colReceiptFurnitureId,
            this.colReceiptFurnitureName,
            this.colReceiptQty,
            this.colReceiptRate,
            this.colReceiptLineTotal});
            this.dgvReceiptItems.Location = new System.Drawing.Point(149, 28);
            this.dgvReceiptItems.Name = "dgvReceiptItems";
            this.dgvReceiptItems.ReadOnly = true;
            this.dgvReceiptItems.Size = new System.Drawing.Size(560, 150);
            this.dgvReceiptItems.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(358, 248);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "button1";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // colReceiptFurnitureId
            // 
            this.colReceiptFurnitureId.HeaderText = "Item ID";
            this.colReceiptFurnitureId.Name = "colReceiptFurnitureId";
            this.colReceiptFurnitureId.ReadOnly = true;
            // 
            // colReceiptFurnitureName
            // 
            this.colReceiptFurnitureName.HeaderText = "Name";
            this.colReceiptFurnitureName.Name = "colReceiptFurnitureName";
            this.colReceiptFurnitureName.ReadOnly = true;
            // 
            // colReceiptQty
            // 
            this.colReceiptQty.HeaderText = "Qty";
            this.colReceiptQty.Name = "colReceiptQty";
            this.colReceiptQty.ReadOnly = true;
            // 
            // colReceiptRate
            // 
            this.colReceiptRate.HeaderText = "Unit Price";
            this.colReceiptRate.Name = "colReceiptRate";
            this.colReceiptRate.ReadOnly = true;
            // 
            // colReceiptLineTotal
            // 
            this.colReceiptLineTotal.HeaderText = "Line Total";
            this.colReceiptLineTotal.Name = "colReceiptLineTotal";
            this.colReceiptLineTotal.ReadOnly = true;
            // 
            // RentalReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvReceiptItems);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblTransactionId);
            this.Name = "RentalReceiptForm";
            this.Text = "RentalReceiptForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTransactionId;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.DataGridView dgvReceiptItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiptFurnitureId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiptFurnitureName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiptQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiptRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceiptLineTotal;
        private System.Windows.Forms.Button btnClose;
    }
}