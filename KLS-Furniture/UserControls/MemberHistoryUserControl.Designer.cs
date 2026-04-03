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
            this.MemberHistTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MemberHistTableLayoutPanel
            // 
            this.MemberHistTableLayoutPanel.ColumnCount = 1;
            this.MemberHistTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MemberHistTableLayoutPanel.Controls.Add(this.MemberHistoryLabel, 0, 0);
            this.MemberHistTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberHistTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MemberHistTableLayoutPanel.Name = "MemberHistTableLayoutPanel";
            this.MemberHistTableLayoutPanel.RowCount = 4;
            this.MemberHistTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.MemberHistTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MemberHistTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 238F));
            this.MemberHistTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 238F));
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
            // MemberHistoryUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MemberHistTableLayoutPanel);
            this.Name = "MemberHistoryUserControl";
            this.Size = new System.Drawing.Size(789, 804);
            this.MemberHistTableLayoutPanel.ResumeLayout(false);
            this.MemberHistTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MemberHistTableLayoutPanel;
        private System.Windows.Forms.Label MemberHistoryLabel;
    }
}
