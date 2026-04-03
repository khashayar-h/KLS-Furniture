namespace KLS_Furniture.UserControls
{
    partial class MemberManageUserControl
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
            this.components = new System.ComponentModel.Container();
            this.MemberMangeTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MemberManageLabel = new System.Windows.Forms.Label();
            this.SearchCriteriaGroupBox = new System.Windows.Forms.GroupBox();
            this.ClearSearchButton = new System.Windows.Forms.Button();
            this.SearchMemberButton = new System.Windows.Forms.Button();
            this.LastNameSearchTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameSearchTextBox = new System.Windows.Forms.TextBox();
            this.PhoneSearchTextBox = new System.Windows.Forms.TextBox();
            this.MemberIdSearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchMessageLabel = new System.Windows.Forms.Label();
            this.LastNameSearchLabel = new System.Windows.Forms.Label();
            this.FirstNameSearchLabel = new System.Windows.Forms.Label();
            this.PhoneSearchLabel = new System.Windows.Forms.Label();
            this.MemberIdSearchLabel = new System.Windows.Forms.Label();
            this.SearchResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.MembersDataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MemberDetailsControl = new KLS_Furniture.UserControls.MemberDetailsUserControl();
            this.MemberMangeTableLayoutPanel.SuspendLayout();
            this.SearchCriteriaGroupBox.SuspendLayout();
            this.SearchResultsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MembersDataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MemberMangeTableLayoutPanel
            // 
            this.MemberMangeTableLayoutPanel.ColumnCount = 1;
            this.MemberMangeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MemberMangeTableLayoutPanel.Controls.Add(this.MemberManageLabel, 0, 0);
            this.MemberMangeTableLayoutPanel.Controls.Add(this.MemberDetailsControl, 0, 3);
            this.MemberMangeTableLayoutPanel.Controls.Add(this.SearchCriteriaGroupBox, 0, 1);
            this.MemberMangeTableLayoutPanel.Controls.Add(this.SearchResultsGroupBox, 0, 2);
            this.MemberMangeTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberMangeTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MemberMangeTableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MemberMangeTableLayoutPanel.Name = "MemberMangeTableLayoutPanel";
            this.MemberMangeTableLayoutPanel.RowCount = 4;
            this.MemberMangeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.MemberMangeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.00636F));
            this.MemberMangeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.11447F));
            this.MemberMangeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.72019F));
            this.MemberMangeTableLayoutPanel.Size = new System.Drawing.Size(789, 804);
            this.MemberMangeTableLayoutPanel.TabIndex = 0;
            // 
            // MemberManageLabel
            // 
            this.MemberManageLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MemberManageLabel.AutoSize = true;
            this.MemberManageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberManageLabel.Location = new System.Drawing.Point(3, 4);
            this.MemberManageLabel.Name = "MemberManageLabel";
            this.MemberManageLabel.Size = new System.Drawing.Size(188, 20);
            this.MemberManageLabel.TabIndex = 0;
            this.MemberManageLabel.Text = "Member Management";
            this.MemberManageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchCriteriaGroupBox
            // 
            this.SearchCriteriaGroupBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SearchCriteriaGroupBox.Controls.Add(this.ClearSearchButton);
            this.SearchCriteriaGroupBox.Controls.Add(this.SearchMemberButton);
            this.SearchCriteriaGroupBox.Controls.Add(this.LastNameSearchTextBox);
            this.SearchCriteriaGroupBox.Controls.Add(this.FirstNameSearchTextBox);
            this.SearchCriteriaGroupBox.Controls.Add(this.PhoneSearchTextBox);
            this.SearchCriteriaGroupBox.Controls.Add(this.MemberIdSearchTextBox);
            this.SearchCriteriaGroupBox.Controls.Add(this.SearchMessageLabel);
            this.SearchCriteriaGroupBox.Controls.Add(this.LastNameSearchLabel);
            this.SearchCriteriaGroupBox.Controls.Add(this.FirstNameSearchLabel);
            this.SearchCriteriaGroupBox.Controls.Add(this.PhoneSearchLabel);
            this.SearchCriteriaGroupBox.Controls.Add(this.MemberIdSearchLabel);
            this.SearchCriteriaGroupBox.Location = new System.Drawing.Point(3, 32);
            this.SearchCriteriaGroupBox.Name = "SearchCriteriaGroupBox";
            this.SearchCriteriaGroupBox.Size = new System.Drawing.Size(783, 180);
            this.SearchCriteriaGroupBox.TabIndex = 0;
            this.SearchCriteriaGroupBox.TabStop = false;
            // 
            // ClearSearchButton
            // 
            this.ClearSearchButton.Location = new System.Drawing.Point(675, 136);
            this.ClearSearchButton.Name = "ClearSearchButton";
            this.ClearSearchButton.Size = new System.Drawing.Size(67, 31);
            this.ClearSearchButton.TabIndex = 10;
            this.ClearSearchButton.Text = "Clear";
            this.ClearSearchButton.UseVisualStyleBackColor = true;
            // 
            // SearchMemberButton
            // 
            this.SearchMemberButton.Location = new System.Drawing.Point(587, 136);
            this.SearchMemberButton.Name = "SearchMemberButton";
            this.SearchMemberButton.Size = new System.Drawing.Size(67, 31);
            this.SearchMemberButton.TabIndex = 9;
            this.SearchMemberButton.Text = "Search";
            this.SearchMemberButton.UseVisualStyleBackColor = true;
            // 
            // LastNameSearchTextBox
            // 
            this.LastNameSearchTextBox.Location = new System.Drawing.Point(392, 111);
            this.LastNameSearchTextBox.Name = "LastNameSearchTextBox";
            this.LastNameSearchTextBox.Size = new System.Drawing.Size(151, 22);
            this.LastNameSearchTextBox.TabIndex = 8;
            // 
            // FirstNameSearchTextBox
            // 
            this.FirstNameSearchTextBox.Location = new System.Drawing.Point(392, 45);
            this.FirstNameSearchTextBox.Name = "FirstNameSearchTextBox";
            this.FirstNameSearchTextBox.Size = new System.Drawing.Size(151, 22);
            this.FirstNameSearchTextBox.TabIndex = 7;
            // 
            // PhoneSearchTextBox
            // 
            this.PhoneSearchTextBox.Location = new System.Drawing.Point(129, 109);
            this.PhoneSearchTextBox.Name = "PhoneSearchTextBox";
            this.PhoneSearchTextBox.Size = new System.Drawing.Size(151, 22);
            this.PhoneSearchTextBox.TabIndex = 6;
            // 
            // MemberIdSearchTextBox
            // 
            this.MemberIdSearchTextBox.Location = new System.Drawing.Point(129, 44);
            this.MemberIdSearchTextBox.Name = "MemberIdSearchTextBox";
            this.MemberIdSearchTextBox.Size = new System.Drawing.Size(151, 22);
            this.MemberIdSearchTextBox.TabIndex = 5;
            // 
            // SearchMessageLabel
            // 
            this.SearchMessageLabel.AutoSize = true;
            this.SearchMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.SearchMessageLabel.Location = new System.Drawing.Point(21, 150);
            this.SearchMessageLabel.Name = "SearchMessageLabel";
            this.SearchMessageLabel.Size = new System.Drawing.Size(0, 16);
            this.SearchMessageLabel.TabIndex = 4;
            // 
            // LastNameSearchLabel
            // 
            this.LastNameSearchLabel.AutoSize = true;
            this.LastNameSearchLabel.Location = new System.Drawing.Point(304, 111);
            this.LastNameSearchLabel.Name = "LastNameSearchLabel";
            this.LastNameSearchLabel.Size = new System.Drawing.Size(72, 16);
            this.LastNameSearchLabel.TabIndex = 3;
            this.LastNameSearchLabel.Text = "Last Name";
            // 
            // FirstNameSearchLabel
            // 
            this.FirstNameSearchLabel.AutoSize = true;
            this.FirstNameSearchLabel.Location = new System.Drawing.Point(304, 45);
            this.FirstNameSearchLabel.Name = "FirstNameSearchLabel";
            this.FirstNameSearchLabel.Size = new System.Drawing.Size(72, 16);
            this.FirstNameSearchLabel.TabIndex = 2;
            this.FirstNameSearchLabel.Text = "First Name";
            // 
            // PhoneSearchLabel
            // 
            this.PhoneSearchLabel.AutoSize = true;
            this.PhoneSearchLabel.Location = new System.Drawing.Point(21, 111);
            this.PhoneSearchLabel.Name = "PhoneSearchLabel";
            this.PhoneSearchLabel.Size = new System.Drawing.Size(46, 16);
            this.PhoneSearchLabel.TabIndex = 1;
            this.PhoneSearchLabel.Text = "Phone";
            // 
            // MemberIdSearchLabel
            // 
            this.MemberIdSearchLabel.AutoSize = true;
            this.MemberIdSearchLabel.Location = new System.Drawing.Point(21, 45);
            this.MemberIdSearchLabel.Name = "MemberIdSearchLabel";
            this.MemberIdSearchLabel.Size = new System.Drawing.Size(73, 16);
            this.MemberIdSearchLabel.TabIndex = 0;
            this.MemberIdSearchLabel.Text = "Member ID";
            // 
            // SearchResultsGroupBox
            // 
            this.SearchResultsGroupBox.Controls.Add(this.MembersDataGridView);
            this.SearchResultsGroupBox.Location = new System.Drawing.Point(4, 219);
            this.SearchResultsGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchResultsGroupBox.Name = "SearchResultsGroupBox";
            this.SearchResultsGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchResultsGroupBox.Size = new System.Drawing.Size(781, 241);
            this.SearchResultsGroupBox.TabIndex = 2;
            this.SearchResultsGroupBox.TabStop = false;
            // 
            // MembersDataGridView
            // 
            this.MembersDataGridView.AllowUserToAddRows = false;
            this.MembersDataGridView.AllowUserToDeleteRows = false;
            this.MembersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MembersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MembersDataGridView.Location = new System.Drawing.Point(0, 11);
            this.MembersDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MembersDataGridView.MultiSelect = false;
            this.MembersDataGridView.Name = "MembersDataGridView";
            this.MembersDataGridView.ReadOnly = true;
            this.MembersDataGridView.RowHeadersWidth = 82;
            this.MembersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MembersDataGridView.Size = new System.Drawing.Size(781, 267);
            this.MembersDataGridView.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zzToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 28);
            // 
            // zzToolStripMenuItem
            // 
            this.zzToolStripMenuItem.Name = "zzToolStripMenuItem";
            this.zzToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.zzToolStripMenuItem.Text = "zz";
            // 
            // MemberDetailsControl
            // 
            this.MemberDetailsControl.AutoSize = true;
            this.MemberDetailsControl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MemberDetailsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberDetailsControl.Location = new System.Drawing.Point(4, 469);
            this.MemberDetailsControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MemberDetailsControl.Name = "MemberDetailsControl";
            this.MemberDetailsControl.Size = new System.Drawing.Size(781, 330);
            this.MemberDetailsControl.TabIndex = 1;
            // 
            // MemberManageUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MemberMangeTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MemberManageUserControl";
            this.Size = new System.Drawing.Size(789, 804);
            this.MemberMangeTableLayoutPanel.ResumeLayout(false);
            this.MemberMangeTableLayoutPanel.PerformLayout();
            this.SearchCriteriaGroupBox.ResumeLayout(false);
            this.SearchCriteriaGroupBox.PerformLayout();
            this.SearchResultsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MembersDataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MemberMangeTableLayoutPanel;
        private System.Windows.Forms.Label MemberManageLabel;
        private MemberDetailsUserControl MemberDetailsControl;
        private System.Windows.Forms.GroupBox SearchCriteriaGroupBox;
        private System.Windows.Forms.Label PhoneSearchLabel;
        private System.Windows.Forms.Label MemberIdSearchLabel;
        private System.Windows.Forms.TextBox MemberIdSearchTextBox;
        private System.Windows.Forms.Label SearchMessageLabel;
        private System.Windows.Forms.Label LastNameSearchLabel;
        private System.Windows.Forms.Label FirstNameSearchLabel;
        private System.Windows.Forms.TextBox LastNameSearchTextBox;
        private System.Windows.Forms.TextBox FirstNameSearchTextBox;
        private System.Windows.Forms.TextBox PhoneSearchTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem zzToolStripMenuItem;
        private System.Windows.Forms.Button ClearSearchButton;
        private System.Windows.Forms.Button SearchMemberButton;
        private System.Windows.Forms.GroupBox SearchResultsGroupBox;
        private System.Windows.Forms.DataGridView MembersDataGridView;
    }
}
