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
            this.memberDetailsUserControl1 = new KLS_Furniture.UserControls.MemberDetailsUserControl();
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.MembersDataGridView = new System.Windows.Forms.DataGridView();
            this.MemberMangeTableLayoutPanel.SuspendLayout();
            this.SearchCriteriaGroupBox.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SearchResultsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MembersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MemberMangeTableLayoutPanel
            // 
            this.MemberMangeTableLayoutPanel.ColumnCount = 1;
            this.MemberMangeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MemberMangeTableLayoutPanel.Controls.Add(this.MemberManageLabel, 0, 0);
            this.MemberMangeTableLayoutPanel.Controls.Add(this.memberDetailsUserControl1, 0, 3);
            this.MemberMangeTableLayoutPanel.Controls.Add(this.SearchCriteriaGroupBox, 0, 1);
            this.MemberMangeTableLayoutPanel.Controls.Add(this.SearchResultsGroupBox, 0, 2);
            this.MemberMangeTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberMangeTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MemberMangeTableLayoutPanel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MemberMangeTableLayoutPanel.Name = "MemberMangeTableLayoutPanel";
            this.MemberMangeTableLayoutPanel.RowCount = 4;
            this.MemberMangeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.MemberMangeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.64146F));
            this.MemberMangeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.897F));
            this.MemberMangeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.33116F));
            this.MemberMangeTableLayoutPanel.Size = new System.Drawing.Size(592, 653);
            this.MemberMangeTableLayoutPanel.TabIndex = 0;
            // 
            // MemberManageLabel
            // 
            this.MemberManageLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MemberManageLabel.AutoSize = true;
            this.MemberManageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberManageLabel.Location = new System.Drawing.Point(2, 3);
            this.MemberManageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MemberManageLabel.Name = "MemberManageLabel";
            this.MemberManageLabel.Size = new System.Drawing.Size(162, 17);
            this.MemberManageLabel.TabIndex = 0;
            this.MemberManageLabel.Text = "Member Management";
            this.MemberManageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memberDetailsUserControl1
            // 
            this.memberDetailsUserControl1.AutoSize = true;
            this.memberDetailsUserControl1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.memberDetailsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memberDetailsUserControl1.Location = new System.Drawing.Point(3, 415);
            this.memberDetailsUserControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.memberDetailsUserControl1.Name = "memberDetailsUserControl1";
            this.memberDetailsUserControl1.Size = new System.Drawing.Size(586, 234);
            this.memberDetailsUserControl1.TabIndex = 1;
            // 
            // SearchCriteriaGroupBox
            // 
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
            this.SearchCriteriaGroupBox.Location = new System.Drawing.Point(2, 26);
            this.SearchCriteriaGroupBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SearchCriteriaGroupBox.Name = "SearchCriteriaGroupBox";
            this.SearchCriteriaGroupBox.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SearchCriteriaGroupBox.Size = new System.Drawing.Size(588, 151);
            this.SearchCriteriaGroupBox.TabIndex = 0;
            this.SearchCriteriaGroupBox.TabStop = false;
            // 
            // ClearSearchButton
            // 
            this.ClearSearchButton.Location = new System.Drawing.Point(506, 110);
            this.ClearSearchButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ClearSearchButton.Name = "ClearSearchButton";
            this.ClearSearchButton.Size = new System.Drawing.Size(50, 25);
            this.ClearSearchButton.TabIndex = 10;
            this.ClearSearchButton.Text = "Clear";
            this.ClearSearchButton.UseVisualStyleBackColor = true;
            // 
            // SearchMemberButton
            // 
            this.SearchMemberButton.Location = new System.Drawing.Point(440, 110);
            this.SearchMemberButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SearchMemberButton.Name = "SearchMemberButton";
            this.SearchMemberButton.Size = new System.Drawing.Size(50, 25);
            this.SearchMemberButton.TabIndex = 9;
            this.SearchMemberButton.Text = "Search";
            this.SearchMemberButton.UseVisualStyleBackColor = true;
            // 
            // LastNameSearchTextBox
            // 
            this.LastNameSearchTextBox.Location = new System.Drawing.Point(294, 90);
            this.LastNameSearchTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LastNameSearchTextBox.Name = "LastNameSearchTextBox";
            this.LastNameSearchTextBox.Size = new System.Drawing.Size(114, 20);
            this.LastNameSearchTextBox.TabIndex = 8;
            // 
            // FirstNameSearchTextBox
            // 
            this.FirstNameSearchTextBox.Location = new System.Drawing.Point(294, 37);
            this.FirstNameSearchTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FirstNameSearchTextBox.Name = "FirstNameSearchTextBox";
            this.FirstNameSearchTextBox.Size = new System.Drawing.Size(114, 20);
            this.FirstNameSearchTextBox.TabIndex = 7;
            // 
            // PhoneSearchTextBox
            // 
            this.PhoneSearchTextBox.Location = new System.Drawing.Point(97, 89);
            this.PhoneSearchTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PhoneSearchTextBox.Name = "PhoneSearchTextBox";
            this.PhoneSearchTextBox.Size = new System.Drawing.Size(114, 20);
            this.PhoneSearchTextBox.TabIndex = 6;
            // 
            // MemberIdSearchTextBox
            // 
            this.MemberIdSearchTextBox.Location = new System.Drawing.Point(97, 36);
            this.MemberIdSearchTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MemberIdSearchTextBox.Name = "MemberIdSearchTextBox";
            this.MemberIdSearchTextBox.Size = new System.Drawing.Size(114, 20);
            this.MemberIdSearchTextBox.TabIndex = 5;
            // 
            // SearchMessageLabel
            // 
            this.SearchMessageLabel.AutoSize = true;
            this.SearchMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.SearchMessageLabel.Location = new System.Drawing.Point(16, 122);
            this.SearchMessageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SearchMessageLabel.Name = "SearchMessageLabel";
            this.SearchMessageLabel.Size = new System.Drawing.Size(110, 13);
            this.SearchMessageLabel.TabIndex = 4;
            this.SearchMessageLabel.Text = "SearchMessageLabel";
            // 
            // LastNameSearchLabel
            // 
            this.LastNameSearchLabel.AutoSize = true;
            this.LastNameSearchLabel.Location = new System.Drawing.Point(228, 90);
            this.LastNameSearchLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LastNameSearchLabel.Name = "LastNameSearchLabel";
            this.LastNameSearchLabel.Size = new System.Drawing.Size(58, 13);
            this.LastNameSearchLabel.TabIndex = 3;
            this.LastNameSearchLabel.Text = "Last Name";
            // 
            // FirstNameSearchLabel
            // 
            this.FirstNameSearchLabel.AutoSize = true;
            this.FirstNameSearchLabel.Location = new System.Drawing.Point(228, 37);
            this.FirstNameSearchLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FirstNameSearchLabel.Name = "FirstNameSearchLabel";
            this.FirstNameSearchLabel.Size = new System.Drawing.Size(57, 13);
            this.FirstNameSearchLabel.TabIndex = 2;
            this.FirstNameSearchLabel.Text = "First Name";
            // 
            // PhoneSearchLabel
            // 
            this.PhoneSearchLabel.AutoSize = true;
            this.PhoneSearchLabel.Location = new System.Drawing.Point(16, 90);
            this.PhoneSearchLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PhoneSearchLabel.Name = "PhoneSearchLabel";
            this.PhoneSearchLabel.Size = new System.Drawing.Size(38, 13);
            this.PhoneSearchLabel.TabIndex = 1;
            this.PhoneSearchLabel.Text = "Phone";
            // 
            // MemberIdSearchLabel
            // 
            this.MemberIdSearchLabel.AutoSize = true;
            this.MemberIdSearchLabel.Location = new System.Drawing.Point(16, 37);
            this.MemberIdSearchLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MemberIdSearchLabel.Name = "MemberIdSearchLabel";
            this.MemberIdSearchLabel.Size = new System.Drawing.Size(59, 13);
            this.MemberIdSearchLabel.TabIndex = 0;
            this.MemberIdSearchLabel.Text = "Member ID";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zzToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(85, 26);
            // 
            // zzToolStripMenuItem
            // 
            this.zzToolStripMenuItem.Name = "zzToolStripMenuItem";
            this.zzToolStripMenuItem.Size = new System.Drawing.Size(84, 22);
            this.zzToolStripMenuItem.Text = "zz";
            // 
            // SearchResultsGroupBox
            // 
            this.SearchResultsGroupBox.Controls.Add(this.MembersDataGridView);
            this.SearchResultsGroupBox.Location = new System.Drawing.Point(3, 182);
            this.SearchResultsGroupBox.Name = "SearchResultsGroupBox";
            this.SearchResultsGroupBox.Size = new System.Drawing.Size(586, 226);
            this.SearchResultsGroupBox.TabIndex = 2;
            this.SearchResultsGroupBox.TabStop = false;
            // 
            // MembersDataGridView
            // 
            this.MembersDataGridView.AllowUserToAddRows = false;
            this.MembersDataGridView.AllowUserToDeleteRows = false;
            this.MembersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MembersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MembersDataGridView.Location = new System.Drawing.Point(0, 9);
            this.MembersDataGridView.MultiSelect = false;
            this.MembersDataGridView.Name = "MembersDataGridView";
            this.MembersDataGridView.ReadOnly = true;
            this.MembersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MembersDataGridView.Size = new System.Drawing.Size(586, 217);
            this.MembersDataGridView.TabIndex = 0;
            // 
            // MemberManageUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MemberMangeTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MemberManageUserControl";
            this.Size = new System.Drawing.Size(592, 653);
            this.MemberMangeTableLayoutPanel.ResumeLayout(false);
            this.MemberMangeTableLayoutPanel.PerformLayout();
            this.SearchCriteriaGroupBox.ResumeLayout(false);
            this.SearchCriteriaGroupBox.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.SearchResultsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MembersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MemberMangeTableLayoutPanel;
        private System.Windows.Forms.Label MemberManageLabel;
        private MemberDetailsUserControl memberDetailsUserControl1;
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
