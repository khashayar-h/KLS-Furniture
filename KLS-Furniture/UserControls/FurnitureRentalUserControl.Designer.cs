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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpSelectedMember = new System.Windows.Forms.GroupBox();
            this.btnFindMember = new System.Windows.Forms.Button();
            this.lblSelectedMemberValue = new System.Windows.Forms.Label();
            this.grpFurnitureSearch = new System.Windows.Forms.GroupBox();
            this.dgvFurnitureResults = new System.Windows.Forms.DataGridView();
            this.colFurnitureId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFurnitureName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStyleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDailyRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantityAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFurnitureId = new System.Windows.Forms.TextBox();
            this.lblFurnitureId = new System.Windows.Forms.Label();
            this.lblStyle = new System.Windows.Forms.Label();
            this.cboStyle = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.grpShoppingCart = new System.Windows.Forms.GroupBox();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.colCartFurnitureId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCartFurnitureName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCartQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCartDailyRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCartLineTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnUpdateQty = new System.Windows.Forms.Button();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblSelectedItemQty = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblTotalCostValue = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnConfirmRental = new System.Windows.Forms.Button();
            this.grpSelectedMember.SuspendLayout();
            this.grpFurnitureSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFurnitureResults)).BeginInit();
            this.grpShoppingCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSelectedMember
            // 
            this.grpSelectedMember.Controls.Add(this.btnFindMember);
            this.grpSelectedMember.Controls.Add(this.lblSelectedMemberValue);
            this.grpSelectedMember.Location = new System.Drawing.Point(3, 33);
            this.grpSelectedMember.Name = "grpSelectedMember";
            this.grpSelectedMember.Size = new System.Drawing.Size(582, 100);
            this.grpSelectedMember.TabIndex = 0;
            this.grpSelectedMember.TabStop = false;
            this.grpSelectedMember.Text = "Selected Member";
            // 
            // btnFindMember
            // 
            this.btnFindMember.Location = new System.Drawing.Point(391, 43);
            this.btnFindMember.Name = "btnFindMember";
            this.btnFindMember.Size = new System.Drawing.Size(92, 23);
            this.btnFindMember.TabIndex = 1;
            this.btnFindMember.Text = "Find Member";
            this.btnFindMember.UseVisualStyleBackColor = true;
            // 
            // lblSelectedMemberValue
            // 
            this.lblSelectedMemberValue.AutoSize = true;
            this.lblSelectedMemberValue.Location = new System.Drawing.Point(47, 48);
            this.lblSelectedMemberValue.Name = "lblSelectedMemberValue";
            this.lblSelectedMemberValue.Size = new System.Drawing.Size(104, 13);
            this.lblSelectedMemberValue.TabIndex = 0;
            this.lblSelectedMemberValue.Text = "No member selected";
            // 
            // grpFurnitureSearch
            // 
            this.grpFurnitureSearch.Controls.Add(this.dgvFurnitureResults);
            this.grpFurnitureSearch.Controls.Add(this.btnSearch);
            this.grpFurnitureSearch.Controls.Add(this.txtFurnitureId);
            this.grpFurnitureSearch.Controls.Add(this.lblFurnitureId);
            this.grpFurnitureSearch.Controls.Add(this.lblStyle);
            this.grpFurnitureSearch.Controls.Add(this.cboStyle);
            this.grpFurnitureSearch.Controls.Add(this.cboCategory);
            this.grpFurnitureSearch.Controls.Add(this.lblCategory);
            this.grpFurnitureSearch.Location = new System.Drawing.Point(3, 164);
            this.grpFurnitureSearch.Name = "grpFurnitureSearch";
            this.grpFurnitureSearch.Size = new System.Drawing.Size(582, 201);
            this.grpFurnitureSearch.TabIndex = 0;
            this.grpFurnitureSearch.TabStop = false;
            this.grpFurnitureSearch.Text = "Furniture Search";
            // 
            // dgvFurnitureResults
            // 
            this.dgvFurnitureResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFurnitureResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFurnitureId,
            this.colFurnitureName,
            this.colCategoryName,
            this.colStyleName,
            this.colDailyRate,
            this.colQuantityAvailable});
            this.dgvFurnitureResults.Location = new System.Drawing.Point(19, 78);
            this.dgvFurnitureResults.Name = "dgvFurnitureResults";
            this.dgvFurnitureResults.ReadOnly = true;
            this.dgvFurnitureResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFurnitureResults.Size = new System.Drawing.Size(545, 106);
            this.dgvFurnitureResults.TabIndex = 7;
            // 
            // colFurnitureId
            // 
            this.colFurnitureId.HeaderText = "Furniture ID";
            this.colFurnitureId.Name = "colFurnitureId";
            this.colFurnitureId.ReadOnly = true;
            // 
            // colFurnitureName
            // 
            this.colFurnitureName.HeaderText = "Name";
            this.colFurnitureName.Name = "colFurnitureName";
            this.colFurnitureName.ReadOnly = true;
            // 
            // colCategoryName
            // 
            this.colCategoryName.HeaderText = "Category";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.ReadOnly = true;
            // 
            // colStyleName
            // 
            this.colStyleName.HeaderText = "Style";
            this.colStyleName.Name = "colStyleName";
            this.colStyleName.ReadOnly = true;
            // 
            // colDailyRate
            // 
            this.colDailyRate.HeaderText = "Daily Rate";
            this.colDailyRate.Name = "colDailyRate";
            this.colDailyRate.ReadOnly = true;
            // 
            // colQuantityAvailable
            // 
            this.colQuantityAvailable.HeaderText = "Available Qty";
            this.colQuantityAvailable.Name = "colQuantityAvailable";
            this.colQuantityAvailable.ReadOnly = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(489, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtFurnitureId
            // 
            this.txtFurnitureId.Location = new System.Drawing.Point(425, 29);
            this.txtFurnitureId.Name = "txtFurnitureId";
            this.txtFurnitureId.Size = new System.Drawing.Size(58, 20);
            this.txtFurnitureId.TabIndex = 5;
            // 
            // lblFurnitureId
            // 
            this.lblFurnitureId.AutoSize = true;
            this.lblFurnitureId.Location = new System.Drawing.Point(357, 36);
            this.lblFurnitureId.Name = "lblFurnitureId";
            this.lblFurnitureId.Size = new System.Drawing.Size(62, 13);
            this.lblFurnitureId.TabIndex = 4;
            this.lblFurnitureId.Text = "Furniture ID";
            // 
            // lblStyle
            // 
            this.lblStyle.AutoSize = true;
            this.lblStyle.Location = new System.Drawing.Point(194, 33);
            this.lblStyle.Name = "lblStyle";
            this.lblStyle.Size = new System.Drawing.Size(30, 13);
            this.lblStyle.TabIndex = 3;
            this.lblStyle.Text = "Style";
            // 
            // cboStyle
            // 
            this.cboStyle.FormattingEnabled = true;
            this.cboStyle.Location = new System.Drawing.Point(230, 28);
            this.cboStyle.Name = "cboStyle";
            this.cboStyle.Size = new System.Drawing.Size(121, 21);
            this.cboStyle.TabIndex = 2;
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(67, 28);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(121, 21);
            this.cboCategory.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(12, 31);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(49, 13);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category";
            // 
            // grpShoppingCart
            // 
            this.grpShoppingCart.Controls.Add(this.dgvCart);
            this.grpShoppingCart.Controls.Add(this.btnRemoveItem);
            this.grpShoppingCart.Controls.Add(this.btnUpdateQty);
            this.grpShoppingCart.Controls.Add(this.btnAddToCart);
            this.grpShoppingCart.Controls.Add(this.nudQuantity);
            this.grpShoppingCart.Controls.Add(this.lblSelectedItemQty);
            this.grpShoppingCart.Location = new System.Drawing.Point(3, 395);
            this.grpShoppingCart.Name = "grpShoppingCart";
            this.grpShoppingCart.Size = new System.Drawing.Size(582, 200);
            this.grpShoppingCart.TabIndex = 1;
            this.grpShoppingCart.TabStop = false;
            this.grpShoppingCart.Text = "Shopping Cart";
            // 
            // dgvCart
            // 
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCartFurnitureId,
            this.colCartFurnitureName,
            this.colCartQty,
            this.colCartDailyRate,
            this.colCartLineTotal});
            this.dgvCart.Location = new System.Drawing.Point(38, 76);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.Size = new System.Drawing.Size(526, 93);
            this.dgvCart.TabIndex = 5;
            // 
            // colCartFurnitureId
            // 
            this.colCartFurnitureId.HeaderText = "Furniture ID";
            this.colCartFurnitureId.Name = "colCartFurnitureId";
            this.colCartFurnitureId.ReadOnly = true;
            // 
            // colCartFurnitureName
            // 
            this.colCartFurnitureName.HeaderText = "Name";
            this.colCartFurnitureName.Name = "colCartFurnitureName";
            this.colCartFurnitureName.ReadOnly = true;
            // 
            // colCartQty
            // 
            this.colCartQty.HeaderText = "Qty";
            this.colCartQty.Name = "colCartQty";
            this.colCartQty.ReadOnly = true;
            // 
            // colCartDailyRate
            // 
            this.colCartDailyRate.HeaderText = "Daily Rate";
            this.colCartDailyRate.Name = "colCartDailyRate";
            this.colCartDailyRate.ReadOnly = true;
            // 
            // colCartLineTotal
            // 
            this.colCartLineTotal.HeaderText = "Line Total";
            this.colCartLineTotal.Name = "colCartLineTotal";
            this.colCartLineTotal.ReadOnly = true;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(441, 32);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveItem.TabIndex = 4;
            this.btnRemoveItem.Text = "Remove";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            // 
            // btnUpdateQty
            // 
            this.btnUpdateQty.Location = new System.Drawing.Point(360, 32);
            this.btnUpdateQty.Name = "btnUpdateQty";
            this.btnUpdateQty.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateQty.TabIndex = 3;
            this.btnUpdateQty.Text = "Update";
            this.btnUpdateQty.UseVisualStyleBackColor = true;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Location = new System.Drawing.Point(276, 32);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(75, 23);
            this.btnAddToCart.TabIndex = 2;
            this.btnAddToCart.Text = "Add";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(141, 35);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 20);
            this.nudQuantity.TabIndex = 1;
            // 
            // lblSelectedItemQty
            // 
            this.lblSelectedItemQty.AutoSize = true;
            this.lblSelectedItemQty.Location = new System.Drawing.Point(35, 37);
            this.lblSelectedItemQty.Name = "lblSelectedItemQty";
            this.lblSelectedItemQty.Size = new System.Drawing.Size(91, 13);
            this.lblSelectedItemQty.TabIndex = 0;
            this.lblSelectedItemQty.Text = "Selected Item Qty";
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(38, 616);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(53, 13);
            this.lblDueDate.TabIndex = 2;
            this.lblDueDate.Text = "Due Date";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(334, 616);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(55, 13);
            this.lblTotalCost.TabIndex = 3;
            this.lblTotalCost.Text = "Total Cost";
            // 
            // lblTotalCostValue
            // 
            this.lblTotalCostValue.AutoSize = true;
            this.lblTotalCostValue.Location = new System.Drawing.Point(395, 616);
            this.lblTotalCostValue.Name = "lblTotalCostValue";
            this.lblTotalCostValue.Size = new System.Drawing.Size(37, 13);
            this.lblTotalCostValue.TabIndex = 4;
            this.lblTotalCostValue.Text = " $0.00";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(112, 609);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDueDate.TabIndex = 5;
            // 
            // btnConfirmRental
            // 
            this.btnConfirmRental.Location = new System.Drawing.Point(466, 606);
            this.btnConfirmRental.Name = "btnConfirmRental";
            this.btnConfirmRental.Size = new System.Drawing.Size(101, 23);
            this.btnConfirmRental.TabIndex = 6;
            this.btnConfirmRental.Text = "Confirm Rental";
            this.btnConfirmRental.UseVisualStyleBackColor = true;
            // 
            // FurnitureRentalUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnConfirmRental);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.lblTotalCostValue);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.grpFurnitureSearch);
            this.Controls.Add(this.grpShoppingCart);
            this.Controls.Add(this.grpSelectedMember);
            this.Name = "FurnitureRentalUserControl";
            this.Size = new System.Drawing.Size(592, 653);
            this.grpSelectedMember.ResumeLayout(false);
            this.grpSelectedMember.PerformLayout();
            this.grpFurnitureSearch.ResumeLayout(false);
            this.grpFurnitureSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFurnitureResults)).EndInit();
            this.grpShoppingCart.ResumeLayout(false);
            this.grpShoppingCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSelectedMember;
        private System.Windows.Forms.GroupBox grpFurnitureSearch;
        private System.Windows.Forms.GroupBox grpShoppingCart;
        private System.Windows.Forms.Button btnFindMember;
        private System.Windows.Forms.Label lblSelectedMemberValue;
        private System.Windows.Forms.Label lblFurnitureId;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.ComboBox cboStyle;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.DataGridView dgvFurnitureResults;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFurnitureId;
        private System.Windows.Forms.Label lblSelectedItemQty;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnUpdateQty;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblTotalCostValue;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button btnConfirmRental;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFurnitureId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFurnitureName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStyleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDailyRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantityAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCartFurnitureId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCartFurnitureName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCartQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCartDailyRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCartLineTotal;
    }
}
