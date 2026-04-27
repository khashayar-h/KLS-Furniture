using KLS_Furniture.Controller;
using KLS_Furniture.Model;
using KLS_Furniture.Model.Entities;
using KLS_Furniture.Model.Lookups;
using KLS_Furniture.UserControls;
using KLS_Furniture.View;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KLS_Furniture
{
    /// <summary>
    /// Class for Main Form of application that displays Navigation and Content
    /// </summary>
    public partial class MainForm : Form
    {
        //Creates instance of user controls to be used in Content Panel
        private readonly MemberManageUserControl memberManageUserControl = new MemberManageUserControl();
        private readonly MemberHistoryUserControl memberHistoryUserControl = new MemberHistoryUserControl();
        private readonly FurnitureRentalUserControl furnitureRentalUserControl = new FurnitureRentalUserControl();
        private readonly AdminReportUserControl adminReportUserControl = new AdminReportUserControl();
        private readonly FurnitureReturnUserControl furnitureReturnUserControl = new FurnitureReturnUserControl();

        private UserControl currentScreen;

        private readonly LoginForm _loginForm;
        private bool _isLoggingOut = false;
        private readonly AuthController _authController;


        /// <summary>
        /// Constructor for MainForm class
        /// </summary>
        public MainForm(LoginForm loginForm = null, AuthController authController = null)
        {
            InitializeComponent();
            _loginForm = loginForm;
            _authController = authController;
            this.UsernameLabel.Text = authController.GetLoggedInUserDisplayText();

            //Add user controls to content panel
            this.ContentPanel.Controls.Add(memberManageUserControl);
            this.ContentPanel.Controls.Add(memberHistoryUserControl);
            this.ContentPanel.Controls.Add(furnitureRentalUserControl);
            this.ContentPanel.Controls.Add(furnitureReturnUserControl);


            // Link navigation events to correct form initialization
            navUserControl1.MemberManagementClicked += Nav_MemberManagementClicked;
            navUserControl1.FurnitureRentalClicked += Nav_FurnitureRentalClicked;
            navUserControl1.ReturnsClicked += Nav_ReturnClicked;
            navUserControl1.MemberHistoryClicked += Nav_MemberHistoryClicked;

            LoggedInUserLookupItem currentUser = authController.GetCurrentUser();

            if (currentUser.IsAdmin)
            {
                this.ContentPanel.Controls.Add(adminReportUserControl);
                navUserControl1.AdminReportsClicked += Nav_AdminReportsClicked;
            }
            else
            {
                navUserControl1.HideAdminFunctions();
            }

            foreach (Control control in ContentPanel.Controls)
            {
                control.Visible = false;
                control.Dock = DockStyle.Fill;
            }

            //Set first tab as active
            navUserControl1.SetActiveTab("membermanagement");
            //Calls Member Management as starting content
            this.ShowContent(memberManageUserControl);
        }

        //Updates Content Panel to selected screen
        private void ShowContent(UserControl selection)
        {
            if (currentScreen != null)
            {
                currentScreen.Visible = false;
            }

            selection.Visible = true;
            selection.BringToFront();
            currentScreen = selection;
        }

        private void Nav_MemberManagementClicked(object sender, EventArgs e)
        {
            navUserControl1.SetActiveTab("membermanagement");
            this.ShowContent(memberManageUserControl);
        }

        private void Nav_FurnitureRentalClicked(object sender, EventArgs e)
        {
            navUserControl1.SetActiveTab("furniturerental");
            this.ShowContent(furnitureRentalUserControl);
        }

        private void Nav_ReturnClicked(object sender, EventArgs e)
        {
            navUserControl1.SetActiveTab("returns");
            this.ShowContent(furnitureReturnUserControl);
        }

        private void Nav_MemberHistoryClicked(object sender, EventArgs e)
        {
            navUserControl1.SetActiveTab("memberhistory");
            this.ShowContent(memberHistoryUserControl);
        }

        private void Nav_AdminReportsClicked(object sender, EventArgs e)
        {
            navUserControl1.SetActiveTab("adminreports");
            this.ShowContent(adminReportUserControl);
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?",
                                    "KLS Furniture - Logout",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            _authController.Logout();
            _isLoggingOut = true;
            this.Close();

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_isLoggingOut)
            {
                _isLoggingOut = false;
                base.OnFormClosing(e);
                return;
            }
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Are you sure you want to Exit?",
                                             "Exit", MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                    return;
                }
            }
            base.OnFormClosing(e);
        }
    }
}
