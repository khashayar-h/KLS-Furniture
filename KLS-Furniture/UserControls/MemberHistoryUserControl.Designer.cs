namespace KLS_Furniture.UserControls
{
    partial class MemberHistoryUserControl
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
            this.MemberHistTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MemberHistoryLabel = new System.Windows.Forms.Label();
            this.memberSearchUserControl1 = new KLS_Furniture.UserControls.MemberSearchUserControl();
            this.HistoryTabControl = new System.Windows.Forms.TabControl();
            this.RentalTabPage = new System.Windows.Forms.TabPage();
            this.RentalDataGridView = new System.Windows.Forms.DataGridView();
            this.ReturnTabPage = new System.Windows.Forms.TabPage();
            this.ReturnDataGridView = new System.Windows.Forms.DataGridView();
            this.MemberHistTableLayoutPanel.SuspendLayout();
            this.HistoryTabControl.SuspendLayout();
            this.RentalTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RentalDataGridView)).BeginInit();
            this.ReturnTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReturnDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MemberHistTableLayoutPanel
            // 
            this.MemberHistTableLayoutPanel.ColumnCount = 1;
            this.MemberHistTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MemberHistTableLayoutPanel.Controls.Add(this.MemberHistoryLabel, 0, 0);
            this.MemberHistTableLayoutPanel.Controls.Add(this.memberSearchUserControl1, 0, 1);
            this.MemberHistTableLayoutPanel.Controls.Add(this.HistoryTabControl, 0, 3);
            this.MemberHistTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberHistTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MemberHistTableLayoutPanel.Name = "MemberHistTableLayoutPanel";
            this.MemberHistTableLayoutPanel.RowCount = 4;
            this.MemberHistTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.MemberHistTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MemberHistTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.MemberHistTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 311F));
            this.MemberHistTableLayoutPanel.Size = new System.Drawing.Size(789, 804);
            this.MemberHistTableLayoutPanel.TabIndex = 0;
            // 
            // MemberHistoryLabel
            // 
            this.MemberHistoryLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MemberHistoryLabel.AutoSize = true;
            this.MemberHistoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberHistoryLabel.Location = new System.Drawing.Point(3, 4);
            this.MemberHistoryLabel.Name = "MemberHistoryLabel";
            this.MemberHistoryLabel.Size = new System.Drawing.Size(143, 20);
            this.MemberHistoryLabel.TabIndex = 0;
            this.MemberHistoryLabel.Text = "Member History";
            // 
            // memberSearchUserControl1
            // 
            this.memberSearchUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memberSearchUserControl1.FirstNameText = "";
            this.memberSearchUserControl1.LastNameText = "";
            this.memberSearchUserControl1.Location = new System.Drawing.Point(3, 32);
            this.memberSearchUserControl1.MemberIdText = "";
            this.memberSearchUserControl1.Name = "memberSearchUserControl1";
            this.memberSearchUserControl1.PhoneText = "";
            this.MemberHistTableLayoutPanel.SetRowSpan(this.memberSearchUserControl1, 2);
            this.memberSearchUserControl1.Size = new System.Drawing.Size(783, 458);
            this.memberSearchUserControl1.TabIndex = 1;
            // 
            // HistoryTabControl
            // 
            this.HistoryTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HistoryTabControl.Controls.Add(this.RentalTabPage);
            this.HistoryTabControl.Controls.Add(this.ReturnTabPage);
            this.HistoryTabControl.Location = new System.Drawing.Point(3, 496);
            this.HistoryTabControl.Name = "HistoryTabControl";
            this.HistoryTabControl.SelectedIndex = 0;
            this.HistoryTabControl.Size = new System.Drawing.Size(783, 305);
            this.HistoryTabControl.TabIndex = 2;
            this.HistoryTabControl.SelectedIndexChanged += new System.EventHandler(this.HandleTabClick_SelectedIndexChange);
            // 
            // RentalTabPage
            // 
            this.RentalTabPage.Controls.Add(this.RentalDataGridView);
            this.RentalTabPage.Location = new System.Drawing.Point(4, 25);
            this.RentalTabPage.Name = "RentalTabPage";
            this.RentalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.RentalTabPage.Size = new System.Drawing.Size(775, 276);
            this.RentalTabPage.TabIndex = 0;
            this.RentalTabPage.Text = "Rentals";
            this.RentalTabPage.UseVisualStyleBackColor = true;
            // 
            // RentalDataGridView
            // 
            this.RentalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RentalDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RentalDataGridView.Location = new System.Drawing.Point(3, 3);
            this.RentalDataGridView.Name = "RentalDataGridView";
            this.RentalDataGridView.RowHeadersWidth = 51;
            this.RentalDataGridView.RowTemplate.Height = 24;
            this.RentalDataGridView.Size = new System.Drawing.Size(769, 270);
            this.RentalDataGridView.TabIndex = 0;
            // 
            // ReturnTabPage
            // 
            this.ReturnTabPage.Controls.Add(this.ReturnDataGridView);
            this.ReturnTabPage.Location = new System.Drawing.Point(4, 25);
            this.ReturnTabPage.Name = "ReturnTabPage";
            this.ReturnTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ReturnTabPage.Size = new System.Drawing.Size(775, 276);
            this.ReturnTabPage.TabIndex = 1;
            this.ReturnTabPage.Text = "Returns";
            this.ReturnTabPage.UseVisualStyleBackColor = true;
            // 
            // ReturnDataGridView
            // 
            this.ReturnDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReturnDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReturnDataGridView.Location = new System.Drawing.Point(3, 3);
            this.ReturnDataGridView.Name = "ReturnDataGridView";
            this.ReturnDataGridView.RowHeadersWidth = 51;
            this.ReturnDataGridView.RowTemplate.Height = 24;
            this.ReturnDataGridView.Size = new System.Drawing.Size(769, 270);
            this.ReturnDataGridView.TabIndex = 0;
            // 
            // MemberHistoryUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MemberHistTableLayoutPanel);
            this.Name = "MemberHistoryUserControl";
            this.Size = new System.Drawing.Size(789, 804);
            this.MemberHistTableLayoutPanel.ResumeLayout(false);
            this.MemberHistTableLayoutPanel.PerformLayout();
            this.HistoryTabControl.ResumeLayout(false);
            this.RentalTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RentalDataGridView)).EndInit();
            this.ReturnTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReturnDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MemberHistTableLayoutPanel;
        private System.Windows.Forms.Label MemberHistoryLabel;
        private MemberSearchUserControl memberSearchUserControl1;
        private System.Windows.Forms.TabControl HistoryTabControl;
        private System.Windows.Forms.TabPage RentalTabPage;
        private System.Windows.Forms.TabPage ReturnTabPage;
        private System.Windows.Forms.DataGridView RentalDataGridView;
        private System.Windows.Forms.DataGridView ReturnDataGridView;
    }
}
