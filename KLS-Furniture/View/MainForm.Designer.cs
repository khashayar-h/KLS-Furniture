namespace KLS_Furniture
{
    partial class MainForm
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
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.NameLogoutTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.navUserControl1 = new KLS_Furniture.UserControls.NavUserControl();
            this.HeaderPanel.SuspendLayout();
            this.NameLogoutTableLayoutPanel.SuspendLayout();
            this.MainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MainTableLayoutPanel.SetColumnSpan(this.HeaderPanel, 2);
            this.HeaderPanel.Controls.Add(this.NameLogoutTableLayoutPanel);
            this.HeaderPanel.Controls.Add(this.label1);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderPanel.Location = new System.Drawing.Point(3, 3);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(972, 53);
            this.HeaderPanel.TabIndex = 1;
            // 
            // NameLogoutTableLayoutPanel
            // 
            this.NameLogoutTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameLogoutTableLayoutPanel.ColumnCount = 2;
            this.NameLogoutTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.91304F));
            this.NameLogoutTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.08696F));
            this.NameLogoutTableLayoutPanel.Controls.Add(this.LogoutButton, 1, 0);
            this.NameLogoutTableLayoutPanel.Controls.Add(this.UsernameLabel, 0, 0);
            this.NameLogoutTableLayoutPanel.Location = new System.Drawing.Point(739, 0);
            this.NameLogoutTableLayoutPanel.Name = "NameLogoutTableLayoutPanel";
            this.NameLogoutTableLayoutPanel.RowCount = 1;
            this.NameLogoutTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.NameLogoutTableLayoutPanel.Size = new System.Drawing.Size(230, 53);
            this.NameLogoutTableLayoutPanel.TabIndex = 3;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LogoutButton.BackColor = System.Drawing.Color.LightCoral;
            this.LogoutButton.Location = new System.Drawing.Point(149, 10);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(75, 33);
            this.LogoutButton.TabIndex = 1;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = false;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(136, 18);
            this.UsernameLabel.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(0, 16);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "RentMe Furniture Rental System";
            // 
            // ContentPanel
            // 
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(151, 62);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(824, 816);
            this.ContentPanel.TabIndex = 2;
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.19824F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.80177F));
            this.MainTableLayoutPanel.Controls.Add(this.ContentPanel, 1, 1);
            this.MainTableLayoutPanel.Controls.Add(this.HeaderPanel, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.navUserControl1, 0, 1);
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.696935F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.30306F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(978, 881);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // navUserControl1
            // 
            this.navUserControl1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.navUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navUserControl1.Location = new System.Drawing.Point(3, 62);
            this.navUserControl1.Name = "navUserControl1";
            this.navUserControl1.Size = new System.Drawing.Size(142, 816);
            this.navUserControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(978, 881);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RentMe";
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.NameLogoutTableLayoutPanel.ResumeLayout(false);
            this.NameLogoutTableLayoutPanel.PerformLayout();
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.NavUserControl navUserControl1;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TableLayoutPanel NameLogoutTableLayoutPanel;
    }
}

