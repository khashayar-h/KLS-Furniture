namespace KLS_Furniture.UserControls
{
    partial class FurnitureRentalUserControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.rentalTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.grpSelectedMember = new System.Windows.Forms.GroupBox();
            this.MemberDetailsLabel = new System.Windows.Forms.Label();
            this.btnFindMember = new System.Windows.Forms.Button();
            this.lblSelectedMemberValue = new System.Windows.Forms.Label();
            this.grpFurnitureSearch = new System.Windows.Forms.GroupBox();
            this.dgvFurnitureResults = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFurnitureId = new System.Windows.Forms.TextBox();
            this.lblFurnitureId = new System.Windows.Forms.Label();
            this.lblStyle = new System.Windows.Forms.Label();
            this.cboStyle = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.grpCart = new System.Windows.Forms.GroupBox();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblSelectedItemQty = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnUpdateQty = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.grpConfirm = new System.Windows.Forms.GroupBox();
            this.btnConfirmRental = new System.Windows.Forms.Button();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.lblTotalCostValue = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.rentalTableLayout.SuspendLayout();
            this.grpSelectedMember.SuspendLayout();
            this.grpFurnitureSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFurnitureResults)).BeginInit();
            this.grpCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.grpConfirm.SuspendLayout();
            this.SuspendLayout();
            // 
            // rentalTableLayout
            // 
            this.rentalTableLayout.ColumnCount = 1;
            this.rentalTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rentalTableLayout.Controls.Add(this.lblPageTitle, 0, 0);
            this.rentalTableLayout.Controls.Add(this.grpSelectedMember, 0, 1);
            this.rentalTableLayout.Controls.Add(this.grpFurnitureSearch, 0, 2);
            this.rentalTableLayout.Controls.Add(this.grpCart, 0, 3);
            this.rentalTableLayout.Controls.Add(this.grpConfirm, 0, 4);
            this.rentalTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rentalTableLayout.Location = new System.Drawing.Point(0, 0);
            this.rentalTableLayout.Name = "rentalTableLayout";
            this.rentalTableLayout.RowCount = 5;
            this.rentalTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.rentalTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.rentalTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 237F));
            this.rentalTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 217F));
            this.rentalTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.rentalTableLayout.Size = new System.Drawing.Size(592, 653);
            this.rentalTableLayout.TabIndex = 1;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPageTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.lblPageTitle.Size = new System.Drawing.Size(134, 25);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Furniture Rental";
            // 
            // grpSelectedMember
            // 
            this.grpSelectedMember.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpSelectedMember.Controls.Add(this.MemberDetailsLabel);
            this.grpSelectedMember.Controls.Add(this.btnFindMember);
            this.grpSelectedMember.Controls.Add(this.lblSelectedMemberValue);
            this.grpSelectedMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSelectedMember.Location = new System.Drawing.Point(3, 37);
            this.grpSelectedMember.Name = "grpSelectedMember";
            this.grpSelectedMember.Size = new System.Drawing.Size(586, 68);
            this.grpSelectedMember.TabIndex = 1;
            this.grpSelectedMember.TabStop = false;
            // 
            // MemberDetailsLabel
            // 
            this.MemberDetailsLabel.AutoSize = true;
            this.MemberDetailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberDetailsLabel.Location = new System.Drawing.Point(22, 0);
            this.MemberDetailsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MemberDetailsLabel.Name = "MemberDetailsLabel";
            this.MemberDetailsLabel.Size = new System.Drawing.Size(133, 17);
            this.MemberDetailsLabel.TabIndex = 2;
            this.MemberDetailsLabel.Text = "Selected Member";
            // 
            // btnFindMember
            // 
            this.btnFindMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindMember.Location = new System.Drawing.Point(462, 25);
            this.btnFindMember.Name = "btnFindMember";
            this.btnFindMember.Size = new System.Drawing.Size(92, 23);
            this.btnFindMember.TabIndex = 1;
            this.btnFindMember.Text = "Find Member";
            this.btnFindMember.UseVisualStyleBackColor = true;
            // 
            // lblSelectedMemberValue
            // 
            this.lblSelectedMemberValue.AutoSize = true;
            this.lblSelectedMemberValue.Location = new System.Drawing.Point(25, 30);
            this.lblSelectedMemberValue.Name = "lblSelectedMemberValue";
            this.lblSelectedMemberValue.Size = new System.Drawing.Size(104, 13);
            this.lblSelectedMemberValue.TabIndex = 0;
            this.lblSelectedMemberValue.Text = "No member selected";
            // 
            // grpFurnitureSearch
            // 
            this.grpFurnitureSearch.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpFurnitureSearch.Controls.Add(this.dgvFurnitureResults);
            this.grpFurnitureSearch.Controls.Add(this.label1);
            this.grpFurnitureSearch.Controls.Add(this.btnSearch);
            this.grpFurnitureSearch.Controls.Add(this.txtFurnitureId);
            this.grpFurnitureSearch.Controls.Add(this.lblFurnitureId);
            this.grpFurnitureSearch.Controls.Add(this.lblStyle);
            this.grpFurnitureSearch.Controls.Add(this.cboStyle);
            this.grpFurnitureSearch.Controls.Add(this.cboCategory);
            this.grpFurnitureSearch.Controls.Add(this.lblCategory);
            this.grpFurnitureSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFurnitureSearch.Location = new System.Drawing.Point(3, 111);
            this.grpFurnitureSearch.Name = "grpFurnitureSearch";
            this.grpFurnitureSearch.Size = new System.Drawing.Size(586, 231);
            this.grpFurnitureSearch.TabIndex = 2;
            this.grpFurnitureSearch.TabStop = false;
            // 
            // dgvFurnitureResults
            // 
            this.dgvFurnitureResults.AllowUserToAddRows = false;
            this.dgvFurnitureResults.AllowUserToDeleteRows = false;
            this.dgvFurnitureResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFurnitureResults.Location = new System.Drawing.Point(28, 71);
            this.dgvFurnitureResults.Name = "dgvFurnitureResults";
            this.dgvFurnitureResults.ReadOnly = true;
            this.dgvFurnitureResults.RowHeadersVisible = false;
            this.dgvFurnitureResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFurnitureResults.Size = new System.Drawing.Size(526, 136);
            this.dgvFurnitureResults.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Furniture Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(479, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtFurnitureId
            // 
            this.txtFurnitureId.Location = new System.Drawing.Point(428, 28);
            this.txtFurnitureId.Name = "txtFurnitureId";
            this.txtFurnitureId.Size = new System.Drawing.Size(45, 20);
            this.txtFurnitureId.TabIndex = 5;
            // 
            // lblFurnitureId
            // 
            this.lblFurnitureId.AutoSize = true;
            this.lblFurnitureId.Location = new System.Drawing.Point(360, 32);
            this.lblFurnitureId.Name = "lblFurnitureId";
            this.lblFurnitureId.Size = new System.Drawing.Size(62, 13);
            this.lblFurnitureId.TabIndex = 4;
            this.lblFurnitureId.Text = "Furniture ID";
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Location = new System.Drawing.Point(208, 32);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(30, 13);
            this.lblStyle.TabIndex = 3;
            this.lblStyle.Text = "Style";
            // 
            // cboStyle
            // 
            this.cboStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStyle.FormattingEnabled = true;
            this.cboStyle.Location = new System.Drawing.Point(244, 27);
            this.cboStyle.Name = "cboStyle";
            this.cboStyle.Size = new System.Drawing.Size(110, 21);
            this.cboStyle.TabIndex = 2;
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(85, 27);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(117, 21);
            this.cboCategory.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(25, 31);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category";
            // 
            // grpCart
            // 
            this.grpCart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpCart.Controls.Add(this.dgvCart);
            this.grpCart.Controls.Add(this.lblSelectedItemQty);
            this.grpCart.Controls.Add(this.nudQuantity);
            this.grpCart.Controls.Add(this.label2);
            this.grpCart.Controls.Add(this.btnAddToCart);
            this.grpCart.Controls.Add(this.btnUpdateQty);
            this.grpCart.Controls.Add(this.btnRemoveItem);
            this.grpCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCart.Location = new System.Drawing.Point(3, 348);
            this.grpCart.Name = "grpCart";
            this.grpCart.Size = new System.Drawing.Size(586, 211);
            this.grpCart.TabIndex = 3;
            this.grpCart.TabStop = false;
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(28, 53);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(526, 135);
            this.dgvCart.TabIndex = 5;
            // 
            // lblSelectedItemQty
            // 
            this.lblSelectedItemQty.AutoSize = true;
            this.lblSelectedItemQty.Location = new System.Drawing.Point(25, 28);
            this.lblSelectedItemQty.Name = "lblSelectedItemQty";
            this.lblSelectedItemQty.Size = new System.Drawing.Size(91, 13);
            this.lblSelectedItemQty.TabIndex = 0;
            this.lblSelectedItemQty.Text = "Selected Item Qty";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(153, 26);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 20);
            this.nudQuantity.TabIndex = 1;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Shopping Cart";
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Location = new System.Drawing.Point(290, 23);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(75, 23);
            this.btnAddToCart.TabIndex = 2;
            this.btnAddToCart.Text = "Add";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            // 
            // btnUpdateQty
            // 
            this.btnUpdateQty.Location = new System.Drawing.Point(385, 23);
            this.btnUpdateQty.Name = "btnUpdateQty";
            this.btnUpdateQty.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateQty.TabIndex = 3;
            this.btnUpdateQty.Text = "Update";
            this.btnUpdateQty.UseVisualStyleBackColor = true;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(479, 24);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveItem.TabIndex = 4;
            this.btnRemoveItem.Text = "Remove";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            // 
            // grpConfirm
            // 
            this.grpConfirm.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpConfirm.Controls.Add(this.btnConfirmRental);
            this.grpConfirm.Controls.Add(this.dtpDueDate);
            this.grpConfirm.Controls.Add(this.lblTotalCostValue);
            this.grpConfirm.Controls.Add(this.lblTotalCost);
            this.grpConfirm.Controls.Add(this.lblDueDate);
            this.grpConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConfirm.Location = new System.Drawing.Point(3, 565);
            this.grpConfirm.Name = "grpConfirm";
            this.grpConfirm.Size = new System.Drawing.Size(586, 155);
            this.grpConfirm.TabIndex = 4;
            this.grpConfirm.TabStop = false;
            // 
            // btnConfirmRental
            // 
            this.btnConfirmRental.Location = new System.Drawing.Point(453, 34);
            this.btnConfirmRental.Name = "btnConfirmRental";
            this.btnConfirmRental.Size = new System.Drawing.Size(101, 23);
            this.btnConfirmRental.TabIndex = 11;
            this.btnConfirmRental.Text = "Confirm Rental";
            this.btnConfirmRental.UseVisualStyleBackColor = true;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(89, 37);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDueDate.TabIndex = 10;
            // 
            // lblTotalCostValue
            // 
            this.lblTotalCostValue.AutoSize = true;
            this.lblTotalCostValue.Location = new System.Drawing.Point(372, 40);
            this.lblTotalCostValue.Name = "lblTotalCostValue";
            this.lblTotalCostValue.Size = new System.Drawing.Size(34, 13);
            this.lblTotalCostValue.TabIndex = 9;
            this.lblTotalCostValue.Text = "$0.00";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(311, 39);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(55, 13);
            this.lblTotalCost.TabIndex = 8;
            this.lblTotalCost.Text = "Total Cost";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(22, 39);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(53, 13);
            this.lblDueDate.TabIndex = 7;
            this.lblDueDate.Text = "Due Date";
            // 
            // FurnitureRentalUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.rentalTableLayout);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FurnitureRentalUserControl";
            this.Size = new System.Drawing.Size(592, 653);
            this.rentalTableLayout.ResumeLayout(false);
            this.rentalTableLayout.PerformLayout();
            this.grpSelectedMember.ResumeLayout(false);
            this.grpSelectedMember.PerformLayout();
            this.grpFurnitureSearch.ResumeLayout(false);
            this.grpFurnitureSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFurnitureResults)).EndInit();
            this.grpCart.ResumeLayout(false);
            this.grpCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.grpConfirm.ResumeLayout(false);
            this.grpConfirm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel rentalTableLayout;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.GroupBox grpSelectedMember;
        private System.Windows.Forms.Label MemberDetailsLabel;
        private System.Windows.Forms.Button btnFindMember;
        private System.Windows.Forms.Label lblSelectedMemberValue;
        private System.Windows.Forms.GroupBox grpFurnitureSearch;
        private System.Windows.Forms.DataGridView dgvFurnitureResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFurnitureId;
        private System.Windows.Forms.Label lblFurnitureId;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.ComboBox cboStyle;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.GroupBox grpCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblSelectedItemQty;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnUpdateQty;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.GroupBox grpConfirm;
        private System.Windows.Forms.Button btnConfirmRental;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblTotalCostValue;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblDueDate;
    }
}