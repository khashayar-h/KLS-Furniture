using System;
using System.Drawing;
using System.Windows.Forms;

namespace KLS_Furniture.UserControls
{
    /// <summary>
    /// User contol class for application navigation
    /// </summary>
    public partial class NavUserControl : UserControl
    {
        /// <summary>
        /// Initializes events for parent forms to respond to after nav click
        /// </summary>
        public event EventHandler MemberManagementClicked;
        public event EventHandler FurnitureRentalClicked;
        public event EventHandler ReturnsClicked;
        public event EventHandler MemberHistoryClicked;
        public event EventHandler AdminReportsClicked;

        /// <summary>
        /// Navigation User control constructor
        /// </summary>
        public NavUserControl()
        {
            InitializeComponent();
        }

        //Funtions to invoke events that will be handled in parent forms
        private void MemberManageNavButton_Click(object sender, EventArgs e)
        {
            this.MemberManagementClicked?.Invoke(this, e);
        }

        private void RentalNavButton_Click(object sender, EventArgs e)
        {            
            this.FurnitureRentalClicked?.Invoke(this, e);
        }

        private void ReturnsNavButton_Click(object sender, EventArgs e)
        {
            this.ReturnsClicked?.Invoke(this, e);
        }

        private void MemberHistNavButton_Click(object sender, EventArgs e)
        {
            this.MemberHistoryClicked?.Invoke(this, e);
        }

        private void AdminReportNavButton_Click(object sender, EventArgs e)
        {
            this.AdminReportsClicked?.Invoke(this, e);
        }

        //Reset background on buttons to allow only single active highlight
        private void ResetButtons()
        {
            this.MemberManageNavButton.BackColor = SystemColors.Control;
            this.RentalNavButton.BackColor = SystemColors.Control;
            this.ReturnsNavButton.BackColor = SystemColors.Control;
            this.MemberHistNavButton.BackColor = SystemColors.Control;
            this.AdminReportNavButton.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// Allows the parent form to programmatically set which tab is active
        /// </summary>
        public void SetActiveTab(string tabName)
        {
            ResetButtons();
            switch (tabName.ToLower())
            {
                case "membermanagement":
                    MemberManageNavButton.BackColor = Color.LightSteelBlue;
                    break;
                case "furniturerental":
                    RentalNavButton.BackColor = Color.LightSteelBlue;
                    break;
                case "returns":
                    ReturnsNavButton.BackColor = Color.LightSteelBlue;
                    break;
                case "memberhistory":
                    MemberHistNavButton.BackColor = Color.LightSteelBlue;
                    break;
                case "adminreports":
                    AdminReportNavButton.BackColor = Color.LightSteelBlue;
                    break;
            }
        }

        public void HideAdminFunctions()
        {
            AdminReportNavButton.Hide();
        }
    }
}
