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
            this.MemberIdSearchLabel = new System.Windows.Forms.Label();
            this.PhoneSearchLabel = new System.Windows.Forms.Label();
            this.FirstNameSearchLabel = new System.Windows.Forms.Label();
            this.LastNameSearchLabel = new System.Windows.Forms.Label();
            this.SearchMessageLabel = new System.Windows.Forms.Label();
            this.MemberIdSearchTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PhoneSearchTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameSearchTextBox = new System.Windows.Forms.TextBox();
            this.LastNameSearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchMemberButton = new System.Windows.Forms.Button();
            this.ClearSearchButton = new System.Windows.Forms.Button();
            this.MemberMangeTableLayoutPanel.SuspendLayout();
            this.SearchCriteriaGroupBox.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MemberMangeTableLayoutPanel
            // 
            this.MemberMangeTableLayoutPanel.ColumnCount = 1;
            this.MemberMangeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MemberMangeTableLayoutPanel.Controls.Add(this.MemberManageLabel, 0, 0);
            this.MemberMangeTableLayoutPanel.Controls.Add(this.memberDetailsUserControl1, 0, 3);
            this.MemberMangeTableLayoutPanel.Controls.Add(this.SearchCriteriaGroupBox, 0, 1);
            this.MemberMangeTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberMangeTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MemberMangeTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MemberMangeTableLayoutPanel.Name = "MemberMangeTableLayoutPanel";
            this.MemberMangeTableLayoutPanel.RowCount = 4;
            this.MemberMangeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.MemberMangeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.64146F));
            this.MemberMangeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.897F));
            this.MemberMangeTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.33116F));
            this.MemberMangeTableLayoutPanel.Size = new System.Drawing.Size(1185, 1255);
            this.MemberMangeTableLayoutPanel.TabIndex = 0;
            // 
            // MemberManageLabel
            // 
            this.MemberManageLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MemberManageLabel.AutoSize = true;
            this.MemberManageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberManageLabel.Location = new System.Drawing.Point(4, 8);
            this.MemberManageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MemberManageLabel.Name = "MemberManageLabel";
            this.MemberManageLabel.Size = new System.Drawing.Size(293, 31);
            this.MemberManageLabel.TabIndex = 0;
            this.MemberManageLabel.Text = "Member Management";
            this.MemberManageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // memberDetailsUserControl1
            // 
            this.memberDetailsUserControl1.AutoSize = true;
            this.memberDetailsUserControl1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.memberDetailsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memberDetailsUserControl1.Location = new System.Drawing.Point(6, 799);
            this.memberDetailsUserControl1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.memberDetailsUserControl1.Name = "memberDetailsUserControl1";
            this.memberDetailsUserControl1.Size = new System.Drawing.Size(1173, 448);
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
            this.SearchCriteriaGroupBox.Location = new System.Drawing.Point(3, 50);
            this.SearchCriteriaGroupBox.Name = "SearchCriteriaGroupBox";
            this.SearchCriteriaGroupBox.Size = new System.Drawing.Size(1179, 292);
            this.SearchCriteriaGroupBox.TabIndex = 0;
            this.SearchCriteriaGroupBox.TabStop = false;
            // 
            // MemberIdSearchLabel
            // 
            this.MemberIdSearchLabel.AutoSize = true;
            this.MemberIdSearchLabel.Location = new System.Drawing.Point(31, 72);
            this.MemberIdSearchLabel.Name = "MemberIdSearchLabel";
            this.MemberIdSearchLabel.Size = new System.Drawing.Size(116, 25);
            this.MemberIdSearchLabel.TabIndex = 0;
            this.MemberIdSearchLabel.Text = "Member ID";
            // 
            // PhoneSearchLabel
            // 
            this.PhoneSearchLabel.AutoSize = true;
            this.PhoneSearchLabel.Location = new System.Drawing.Point(31, 174);
            this.PhoneSearchLabel.Name = "PhoneSearchLabel";
            this.PhoneSearchLabel.Size = new System.Drawing.Size(74, 25);
            this.PhoneSearchLabel.TabIndex = 1;
            this.PhoneSearchLabel.Text = "Phone";
            // 
            // FirstNameSearchLabel
            // 
            this.FirstNameSearchLabel.AutoSize = true;
            this.FirstNameSearchLabel.Location = new System.Drawing.Point(456, 72);
            this.FirstNameSearchLabel.Name = "FirstNameSearchLabel";
            this.FirstNameSearchLabel.Size = new System.Drawing.Size(116, 25);
            this.FirstNameSearchLabel.TabIndex = 2;
            this.FirstNameSearchLabel.Text = "First Name";
            // 
            // LastNameSearchLabel
            // 
            this.LastNameSearchLabel.AutoSize = true;
            this.LastNameSearchLabel.Location = new System.Drawing.Point(457, 174);
            this.LastNameSearchLabel.Name = "LastNameSearchLabel";
            this.LastNameSearchLabel.Size = new System.Drawing.Size(115, 25);
            this.LastNameSearchLabel.TabIndex = 3;
            this.LastNameSearchLabel.Text = "Last Name";
            // 
            // SearchMessageLabel
            // 
            this.SearchMessageLabel.AutoSize = true;
            this.SearchMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.SearchMessageLabel.Location = new System.Drawing.Point(31, 235);
            this.SearchMessageLabel.Name = "SearchMessageLabel";
            this.SearchMessageLabel.Size = new System.Drawing.Size(221, 25);
            this.SearchMessageLabel.TabIndex = 4;
            this.SearchMessageLabel.Text = "SearchMessageLabel";
            // 
            // MemberIdSearchTextBox
            // 
            this.MemberIdSearchTextBox.Location = new System.Drawing.Point(194, 69);
            this.MemberIdSearchTextBox.Name = "MemberIdSearchTextBox";
            this.MemberIdSearchTextBox.Size = new System.Drawing.Size(224, 31);
            this.MemberIdSearchTextBox.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zzToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 42);
            // 
            // zzToolStripMenuItem
            // 
            this.zzToolStripMenuItem.Name = "zzToolStripMenuItem";
            this.zzToolStripMenuItem.Size = new System.Drawing.Size(110, 38);
            this.zzToolStripMenuItem.Text = "zz";
            // 
            // PhoneSearchTextBox
            // 
            this.PhoneSearchTextBox.Location = new System.Drawing.Point(194, 171);
            this.PhoneSearchTextBox.Name = "PhoneSearchTextBox";
            this.PhoneSearchTextBox.Size = new System.Drawing.Size(224, 31);
            this.PhoneSearchTextBox.TabIndex = 6;
            // 
            // FirstNameSearchTextBox
            // 
            this.FirstNameSearchTextBox.Location = new System.Drawing.Point(589, 72);
            this.FirstNameSearchTextBox.Name = "FirstNameSearchTextBox";
            this.FirstNameSearchTextBox.Size = new System.Drawing.Size(224, 31);
            this.FirstNameSearchTextBox.TabIndex = 7;
            // 
            // LastNameSearchTextBox
            // 
            this.LastNameSearchTextBox.Location = new System.Drawing.Point(589, 174);
            this.LastNameSearchTextBox.Name = "LastNameSearchTextBox";
            this.LastNameSearchTextBox.Size = new System.Drawing.Size(224, 31);
            this.LastNameSearchTextBox.TabIndex = 8;
            // 
            // SearchMemberButton
            // 
            this.SearchMemberButton.Location = new System.Drawing.Point(881, 211);
            this.SearchMemberButton.Name = "SearchMemberButton";
            this.SearchMemberButton.Size = new System.Drawing.Size(99, 49);
            this.SearchMemberButton.TabIndex = 9;
            this.SearchMemberButton.Text = "Search";
            this.SearchMemberButton.UseVisualStyleBackColor = true;
            // 
            // ClearSearchButton
            // 
            this.ClearSearchButton.Location = new System.Drawing.Point(1012, 211);
            this.ClearSearchButton.Name = "ClearSearchButton";
            this.ClearSearchButton.Size = new System.Drawing.Size(101, 49);
            this.ClearSearchButton.TabIndex = 10;
            this.ClearSearchButton.Text = "Clear";
            this.ClearSearchButton.UseVisualStyleBackColor = true;
            // 
            // MemberManageUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MemberMangeTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MemberManageUserControl";
            this.Size = new System.Drawing.Size(1185, 1255);
            this.MemberMangeTableLayoutPanel.ResumeLayout(false);
            this.MemberMangeTableLayoutPanel.PerformLayout();
            this.SearchCriteriaGroupBox.ResumeLayout(false);
            this.SearchCriteriaGroupBox.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
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
    }
}
