namespace KLS_Furniture.UserControls
{
    partial class AdminReportUserControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AdminReportTitleLabel = new System.Windows.Forms.Label();
            this.StartLabel = new System.Windows.Forms.Label();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndLabel = new System.Windows.Forms.Label();
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ReportDataGridView = new System.Windows.Forms.DataGridView();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.31553F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.61165F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.AdminReportTitleLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.StartLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.StartDateTimePicker, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.EndLabel, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.EndDateTimePicker, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.ReportDataGridView, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ResetButton, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.SubmitButton, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionLabel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(824, 816);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // AdminReportTitleLabel
            // 
            this.AdminReportTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AdminReportTitleLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.AdminReportTitleLabel, 5);
            this.AdminReportTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminReportTitleLabel.Location = new System.Drawing.Point(3, 5);
            this.AdminReportTitleLabel.Name = "AdminReportTitleLabel";
            this.AdminReportTitleLabel.Size = new System.Drawing.Size(123, 20);
            this.AdminReportTitleLabel.TabIndex = 0;
            this.AdminReportTitleLabel.Text = "Admin Report";
            // 
            // StartLabel
            // 
            this.StartLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(3, 92);
            this.StartLabel.Name = "StartLabel";
            this.tableLayoutPanel1.SetRowSpan(this.StartLabel, 2);
            this.StartLabel.Size = new System.Drawing.Size(69, 16);
            this.StartLabel.TabIndex = 1;
            this.StartLabel.Text = "Start Date:";
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StartDateTimePicker.Location = new System.Drawing.Point(88, 89);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.tableLayoutPanel1.SetRowSpan(this.StartDateTimePicker, 2);
            this.StartDateTimePicker.Size = new System.Drawing.Size(238, 22);
            this.StartDateTimePicker.TabIndex = 2;
            // 
            // EndLabel
            // 
            this.EndLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EndLabel.AutoSize = true;
            this.EndLabel.Location = new System.Drawing.Point(332, 92);
            this.EndLabel.Name = "EndLabel";
            this.tableLayoutPanel1.SetRowSpan(this.EndLabel, 2);
            this.EndLabel.Size = new System.Drawing.Size(66, 16);
            this.EndLabel.TabIndex = 3;
            this.EndLabel.Text = "End Date:";
            // 
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EndDateTimePicker.Location = new System.Drawing.Point(414, 89);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.tableLayoutPanel1.SetRowSpan(this.EndDateTimePicker, 2);
            this.EndDateTimePicker.Size = new System.Drawing.Size(241, 22);
            this.EndDateTimePicker.TabIndex = 4;
            // 
            // ReportDataGridView
            // 
            this.ReportDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.ReportDataGridView, 5);
            this.ReportDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportDataGridView.Location = new System.Drawing.Point(3, 143);
            this.ReportDataGridView.Name = "ReportDataGridView";
            this.ReportDataGridView.RowHeadersWidth = 51;
            this.ReportDataGridView.RowTemplate.Height = 24;
            this.ReportDataGridView.Size = new System.Drawing.Size(818, 690);
            this.ReportDataGridView.TabIndex = 6;
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ResetButton.Location = new System.Drawing.Point(703, 105);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 30);
            this.ResetButton.TabIndex = 7;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SubmitButton.Location = new System.Drawing.Point(703, 65);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 30);
            this.SubmitButton.TabIndex = 5;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DescriptionLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.DescriptionLabel, 4);
            this.DescriptionLabel.Location = new System.Drawing.Point(3, 44);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(441, 16);
            this.DescriptionLabel.TabIndex = 8;
            this.DescriptionLabel.Text = "Please enter a date range below to see most popular items for that period";
            // 
            // AdminReportUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AdminReportUserControl";
            this.Size = new System.Drawing.Size(824, 816);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReportDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label AdminReportTitleLabel;
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.Label EndLabel;
        private System.Windows.Forms.DateTimePicker EndDateTimePicker;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.DataGridView ReportDataGridView;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Label DescriptionLabel;
    }
}
