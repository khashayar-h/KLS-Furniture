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
            this.MemberDetailsControl = new KLS_Furniture.UserControls.MemberDetailsUserControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memberSearchUserControl1 = new KLS_Furniture.UserControls.MemberSearchUserControl();
            this.MemberMangeTableLayoutPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MemberMangeTableLayoutPanel
            // 
            this.MemberMangeTableLayoutPanel.ColumnCount = 1;
            this.MemberMangeTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MemberMangeTableLayoutPanel.Controls.Add(this.MemberManageLabel, 0, 0);
            this.MemberMangeTableLayoutPanel.Controls.Add(this.MemberDetailsControl, 0, 3);
            this.MemberMangeTableLayoutPanel.Controls.Add(this.memberSearchUserControl1, 0, 1);
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
            // memberSearchUserControl1
            // 
            this.memberSearchUserControl1.FirstNameText = "";
            this.memberSearchUserControl1.LastNameText = "";
            this.memberSearchUserControl1.Location = new System.Drawing.Point(3, 32);
            this.memberSearchUserControl1.MemberIdText = "";
            this.memberSearchUserControl1.Name = "memberSearchUserControl1";
            this.memberSearchUserControl1.PhoneText = "";
            this.MemberMangeTableLayoutPanel.SetRowSpan(this.memberSearchUserControl1, 2);
            this.memberSearchUserControl1.Size = new System.Drawing.Size(783, 429);
            this.memberSearchUserControl1.TabIndex = 2;
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
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MemberMangeTableLayoutPanel;
        private System.Windows.Forms.Label MemberManageLabel;
        private MemberDetailsUserControl MemberDetailsControl;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem zzToolStripMenuItem;
        private MemberSearchUserControl memberSearchUserControl1;
    }
}
