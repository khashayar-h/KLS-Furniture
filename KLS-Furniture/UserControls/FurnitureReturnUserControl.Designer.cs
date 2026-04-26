namespace KLS_Furniture.UserControls
{
    partial class FurnitureReturnUserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.memberSearchUserControl1 = new KLS_Furniture.UserControls.MemberSearchUserControl();
            this.lblSelectedMember = new System.Windows.Forms.Label();
            this.dgvReturnableItems = new System.Windows.Forms.DataGridView();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.lblQty = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnUpdateQuantity = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnConfirmReturn = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTotals = new System.Windows.Forms.Label();
            this.scrollPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnableItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.flowLayoutPanelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // scrollPanel
            // 
            this.scrollPanel.AutoScroll = true;
            this.scrollPanel.Controls.Add(this.tableLayoutPanel);
            this.scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel.Location = new System.Drawing.Point(0, 0);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(700, 800);
            this.scrollPanel.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.titleLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.memberSearchUserControl1, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.lblSelectedMember, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.dgvReturnableItems, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.dgvCart, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanelButtons, 0, 5);
            this.tableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(650, 830);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(3, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(644, 34);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Furniture Return";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memberSearchUserControl1
            // 
            this.memberSearchUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memberSearchUserControl1.FirstNameText = "";
            this.memberSearchUserControl1.LastNameText = "";
            this.memberSearchUserControl1.Location = new System.Drawing.Point(0, 39);
            this.memberSearchUserControl1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.memberSearchUserControl1.MemberIdText = "";
            this.memberSearchUserControl1.Name = "memberSearchUserControl1";
            this.memberSearchUserControl1.PhoneText = "";
            this.memberSearchUserControl1.Size = new System.Drawing.Size(650, 370);
            this.memberSearchUserControl1.TabIndex = 1;
            // 
            // lblSelectedMember
            // 
            this.lblSelectedMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSelectedMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectedMember.Location = new System.Drawing.Point(3, 414);
            this.lblSelectedMember.Name = "lblSelectedMember";
            this.lblSelectedMember.Size = new System.Drawing.Size(644, 34);
            this.lblSelectedMember.TabIndex = 2;
            this.lblSelectedMember.Text = "Selected Member: None";
            this.lblSelectedMember.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvReturnableItems
            // 
            this.dgvReturnableItems.AllowUserToAddRows = false;
            this.dgvReturnableItems.AllowUserToDeleteRows = false;
            this.dgvReturnableItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReturnableItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReturnableItems.Location = new System.Drawing.Point(3, 451);
            this.dgvReturnableItems.Name = "dgvReturnableItems";
            this.dgvReturnableItems.ReadOnly = true;
            this.dgvReturnableItems.Size = new System.Drawing.Size(644, 154);
            this.dgvReturnableItems.TabIndex = 3;
            // 
            // dgvCart
            // 
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.Location = new System.Drawing.Point(3, 611);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.Size = new System.Drawing.Size(644, 144);
            this.dgvCart.TabIndex = 4;
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.Controls.Add(this.lblQty);
            this.flowLayoutPanelButtons.Controls.Add(this.nudQuantity);
            this.flowLayoutPanelButtons.Controls.Add(this.btnAddItem);
            this.flowLayoutPanelButtons.Controls.Add(this.btnUpdateQuantity);
            this.flowLayoutPanelButtons.Controls.Add(this.btnRemoveItem);
            this.flowLayoutPanelButtons.Controls.Add(this.btnConfirmReturn);
            this.flowLayoutPanelButtons.Controls.Add(this.btnClear);
            this.flowLayoutPanelButtons.Controls.Add(this.lblTotals);
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(3, 761);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(644, 66);
            this.flowLayoutPanelButtons.TabIndex = 5;
            // 
            // lblQty
            // 
            this.lblQty.Location = new System.Drawing.Point(3, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(35, 28);
            this.lblQty.TabIndex = 0;
            this.lblQty.Text = "Qty:";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(44, 3);
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
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(170, 3);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "Add to Return";
            // 
            // btnUpdateQuantity
            // 
            this.btnUpdateQuantity.Location = new System.Drawing.Point(251, 3);
            this.btnUpdateQuantity.Name = "btnUpdateQuantity";
            this.btnUpdateQuantity.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateQuantity.TabIndex = 3;
            this.btnUpdateQuantity.Text = "Update Qty";
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(332, 3);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveItem.TabIndex = 4;
            this.btnRemoveItem.Text = "Remove Item";
            // 
            // btnConfirmReturn
            // 
            this.btnConfirmReturn.Location = new System.Drawing.Point(413, 3);
            this.btnConfirmReturn.Name = "btnConfirmReturn";
            this.btnConfirmReturn.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmReturn.TabIndex = 5;
            this.btnConfirmReturn.Text = "Confirm Return";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(494, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            // 
            // lblTotals
            // 
            this.lblTotals.Location = new System.Drawing.Point(3, 29);
            this.lblTotals.Name = "lblTotals";
            this.lblTotals.Size = new System.Drawing.Size(100, 23);
            this.lblTotals.TabIndex = 7;
            this.lblTotals.Text = "Fine: $0.00   Refund: $0.00";
            // 
            // FurnitureReturnUserControl
            // 
            this.Controls.Add(this.scrollPanel);
            this.Name = "FurnitureReturnUserControl";
            this.Size = new System.Drawing.Size(700, 800);
            this.scrollPanel.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnableItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel scrollPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label titleLabel;
        private KLS_Furniture.UserControls.MemberSearchUserControl memberSearchUserControl1;
        private System.Windows.Forms.Label lblSelectedMember;
        private System.Windows.Forms.DataGridView dgvReturnableItems;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnUpdateQuantity;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnConfirmReturn;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblTotals;
    }
}