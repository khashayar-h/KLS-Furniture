namespace KLS_Furniture.View
{
    partial class ReturnReceiptForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TransactionIdLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ReturnDateLabel = new System.Windows.Forms.Label();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.FineLabel = new System.Windows.Forms.Label();
            this.RefundLabel = new System.Windows.Forms.Label();
            this.ReceiptDatagrid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptDatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.TransactionIdLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CloseButton, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.ReturnDateLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CustomerLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FineLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.RefundLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ReceiptDatagrid, 0, 5);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(664, 533);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // TransactionIdLabel
            // 
            this.TransactionIdLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TransactionIdLabel.AutoSize = true;
            this.TransactionIdLabel.Location = new System.Drawing.Point(4, 17);
            this.TransactionIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TransactionIdLabel.Name = "TransactionIdLabel";
            this.TransactionIdLabel.Size = new System.Drawing.Size(94, 16);
            this.TransactionIdLabel.TabIndex = 0;
            this.TransactionIdLabel.Text = "Transaction ID";
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CloseButton.Location = new System.Drawing.Point(448, 477);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 28);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ReturnDateLabel
            // 
            this.ReturnDateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ReturnDateLabel.AutoSize = true;
            this.ReturnDateLabel.Location = new System.Drawing.Point(3, 117);
            this.ReturnDateLabel.Name = "ReturnDateLabel";
            this.ReturnDateLabel.Size = new System.Drawing.Size(78, 16);
            this.ReturnDateLabel.TabIndex = 6;
            this.ReturnDateLabel.Text = "Return Date";
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Location = new System.Drawing.Point(4, 67);
            this.CustomerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(64, 16);
            this.CustomerLabel.TabIndex = 1;
            this.CustomerLabel.Text = "Customer";
            // 
            // FineLabel
            // 
            this.FineLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FineLabel.AutoSize = true;
            this.FineLabel.Location = new System.Drawing.Point(4, 217);
            this.FineLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FineLabel.Name = "FineLabel";
            this.FineLabel.Size = new System.Drawing.Size(67, 16);
            this.FineLabel.TabIndex = 3;
            this.FineLabel.Text = "Total Fine";
            // 
            // RefundLabel
            // 
            this.RefundLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RefundLabel.AutoSize = true;
            this.RefundLabel.Location = new System.Drawing.Point(4, 167);
            this.RefundLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RefundLabel.Name = "RefundLabel";
            this.RefundLabel.Size = new System.Drawing.Size(84, 16);
            this.RefundLabel.TabIndex = 2;
            this.RefundLabel.Text = "Total Refund";
            // 
            // ReceiptDatagrid
            // 
            this.ReceiptDatagrid.AllowUserToAddRows = false;
            this.ReceiptDatagrid.AllowUserToDeleteRows = false;
            this.ReceiptDatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.ReceiptDatagrid, 2);
            this.ReceiptDatagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReceiptDatagrid.Location = new System.Drawing.Point(4, 254);
            this.ReceiptDatagrid.Margin = new System.Windows.Forms.Padding(4);
            this.ReceiptDatagrid.Name = "ReceiptDatagrid";
            this.ReceiptDatagrid.ReadOnly = true;
            this.ReceiptDatagrid.RowHeadersWidth = 51;
            this.ReceiptDatagrid.Size = new System.Drawing.Size(656, 192);
            this.ReceiptDatagrid.TabIndex = 4;
            // 
            // ReturnReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 533);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReturnReceiptForm";
            this.Text = "Return Receipt";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptDatagrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label TransactionIdLabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label ReturnDateLabel;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.Label FineLabel;
        private System.Windows.Forms.Label RefundLabel;
        private System.Windows.Forms.DataGridView ReceiptDatagrid;
    }
}