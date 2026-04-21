using KLS_Furniture.Controller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KLS_Furniture.UserControls
{
    /// <summary>
    /// Class definition for Admin report to show most popular furniture during time period
    /// </summary>
    public partial class AdminReportUserControl : UserControl
    {
        private readonly AdminController _adminController;

        /// <summary>
        /// Constructor for AdminReportUserControl class
        /// </summary>
        public AdminReportUserControl()
        {
            InitializeComponent();
            _adminController = new AdminController();

            StartDateTimePicker.Value = DateTime.Today.AddDays(-7);
            EndDateTimePicker.Value = DateTime.Today;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            DateTime start = StartDateTimePicker.Value.Date;
            DateTime end = EndDateTimePicker.Value.Date;

            if (start > end)
            {
                MessageBox.Show("Start date cannot be after end date.", "Invalid Range");
                return;
            }

            try
            {
                var data = _adminController.GetPopularFurnitureReport(start, end);

                if (data.Count == 0)
                {
                    MessageBox.Show("No qualified furniture found in the selected period.", "Report");
                    return;
                }

                // Bind to DataGridView
                ReportDataGridView.DataSource = data;

                var grid = ReportDataGridView;

                // Hide raw percentage columns
                grid.Columns["PercentageOfTotalRentals"].Visible = false;
                grid.Columns["YoungPercentage"].Visible = false;
                grid.Columns["OtherAgePercentage"].Visible = false;

                // Rename and format visible columns
                grid.Columns["CategoryName"].HeaderText = "Category";
                grid.Columns["FurnitureName"].HeaderText = "Furniture Name";
                grid.Columns["RentalTransactionCount"].HeaderText = "Rental Count";
                grid.Columns["TotalRentalTransactionsInPeriod"].HeaderText = "Total Rentals in Period";
                grid.Columns["PercentageOfTotalRentalsFormatted"].HeaderText = "% of Total Rentals";
                grid.Columns["PercentageOfTotalRentalsFormatted"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grid.Columns["YoungPercentageFormatted"].HeaderText = "% Aged 18-29";
                grid.Columns["YoungPercentageFormatted"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grid.Columns["OtherAgePercentageFormatted"].HeaderText = "% Outside 18-29";
                grid.Columns["OtherAgePercentageFormatted"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                // Auto-resize all columns to fit content
                grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                // Make header bold for better look
                grid.ColumnHeadersDefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }

        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ReportDataGridView.DataSource = null;
            StartDateTimePicker.Value = DateTime.Today.AddDays(-7);
            EndDateTimePicker.Value = DateTime.Today;
        }
    }
}
