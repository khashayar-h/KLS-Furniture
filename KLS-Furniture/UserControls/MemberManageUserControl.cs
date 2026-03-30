using KLS_Furniture.Controller;
using KLS_Furniture.Model;
using KLS_Furniture.Model.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KLS_Furniture.UserControls
{
    /// <summary>
    /// Handles member management search and result selection behavior.
    /// </summary>
    public partial class MemberManageUserControl : UserControl
    {
        private readonly MemberManagementController _controller;
        private readonly BindingSource _memberBindingSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberManageUserControl"/> class.
        /// </summary>
        public MemberManageUserControl()
        {
            InitializeComponent();

            this._controller = new MemberManagementController();
            this._memberBindingSource = new BindingSource();

            this.ConfigureResultsGrid();
            this.WireUpEvents();
            this.ClearSearchUI();
        }

        /// <summary>
        /// Wires up UI events for search and selection.
        /// </summary>
        private void WireUpEvents()
        {
            this.SearchMemberButton.Click += SearchMemberButton_Click;
            this.ClearSearchButton.Click += ClearSearchButton_Click;
            this.MembersDataGridView.SelectionChanged += MembersDataGridView_SelectionChanged;

            this.MemberIdSearchTextBox.TextChanged += (s, e) => this.ClearMessage();
            this.PhoneSearchTextBox.TextChanged += (s, e) => this.ClearMessage();
            this.FirstNameSearchTextBox.TextChanged += (s, e) => this.ClearMessage();
            this.LastNameSearchTextBox.TextChanged += (s, e) => this.ClearMessage();

            this.MemberDetailsControl.MemberSaved += MemberDetailsControl_MemberSaved;
        }

        /// <summary>
        /// Configures columns and binding for the results grid.
        /// </summary>
        private void ConfigureResultsGrid()
        {
            this.MembersDataGridView.AutoGenerateColumns = false;
            this.MembersDataGridView.Columns.Clear();

            this.MembersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MemberIdColumn",
                HeaderText = "Member ID",
                DataPropertyName = "MemberId"
            });

            this.MembersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FirstNameColumn",
                HeaderText = "First Name",
                DataPropertyName = "FirstName"
            });

            this.MembersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LastNameColumn",
                HeaderText = "Last Name",
                DataPropertyName = "LastName"
            });

            this.MembersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PhoneColumn",
                HeaderText = "Phone",
                DataPropertyName = "Phone"
            });

            this.MembersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateOfBirthColumn",
                HeaderText = "Date of Birth",
                DataPropertyName = "DateOfBirth",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" }
            });

            this.MembersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AddressColumn",
                HeaderText = "Address",
                DataPropertyName = "FullAddress"
            });

            this.MembersDataGridView.DataSource = this._memberBindingSource;
        }

        private void SearchMemberButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearMessage();

                MemberSearchCriteria criteria = this.BuildSearchCriteria();

                if (!criteria.HasAnyCriteria())
                {
                    this.ShowError("Enter at least one search value.");
                    return;
                }

                List<Member> members = this._controller.SearchMembers(criteria);
                this._memberBindingSource.DataSource = members;

                if (members.Count == 0)
                {
                    this.ShowMessage("No members found.");
                    this.MemberDetailsControl.ResetDisplay();
                    return;
                }

                this.ShowMessage($"{members.Count} member(s) found.");

                if (this.MembersDataGridView.Rows.Count > 0)
                {
                    this.MembersDataGridView.ClearSelection();
                    this.MembersDataGridView.Rows[0].Selected = true;
                    this.MembersDataGridView.CurrentCell = this.MembersDataGridView.Rows[0].Cells[0];
                }
            }
            catch (FormatException ex)
            {
                this.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                this.ShowError("Search failed: " + ex.Message);
            }
        }

        private void ClearSearchButton_Click(object sender, EventArgs e)
        {
            this.ClearSearchUI();
        }

        private void MembersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (this.MembersDataGridView.CurrentRow?.DataBoundItem is Member selectedMember)
            {
                this.MemberDetailsControl.DisplayMember(selectedMember);
            }
        }

        /// <summary>
        /// Builds a search criteria object from the textboxes.
        /// </summary>
        /// <returns>The populated search criteria.</returns>
        private MemberSearchCriteria BuildSearchCriteria()
        {
            int? memberId = null;

            if (!string.IsNullOrWhiteSpace(this.MemberIdSearchTextBox.Text))
            {
                if (!int.TryParse(this.MemberIdSearchTextBox.Text.Trim(), out int parsedMemberId))
                {
                    throw new FormatException("Member ID must be numeric.");
                }

                memberId = parsedMemberId;
            }

            return new MemberSearchCriteria
            {
                MemberID = memberId,
                Phone = this.PhoneSearchTextBox.Text.Trim(),
                FirstName = this.FirstNameSearchTextBox.Text.Trim(),
                LastName = this.LastNameSearchTextBox.Text.Trim()
            };
        }

        /// <summary>
        /// Clears all search inputs, results, and detail display.
        /// </summary>
        private void ClearSearchUI()
        {
            this.MemberIdSearchTextBox.Clear();
            this.PhoneSearchTextBox.Clear();
            this.FirstNameSearchTextBox.Clear();
            this.LastNameSearchTextBox.Clear();

            this._memberBindingSource.DataSource = null;
            this.ClearMessage();
            this.MemberDetailsControl.ResetDisplay();
        }

        /// <summary>
        /// Displays a normal status message.
        /// </summary>
        private void ShowMessage(string message)
        {
            this.SearchMessageLabel.ForeColor = Color.Black;
            this.SearchMessageLabel.Text = message;
        }

        /// <summary>
        /// Displays an error message.
        /// </summary>
        private void ShowError(string message)
        {
            this.SearchMessageLabel.ForeColor = Color.Red;
            this.SearchMessageLabel.Text = message;
        }

        /// <summary>
        /// Clears the message label.
        /// </summary>
        private void ClearMessage()
        {
            this.SearchMessageLabel.Text = string.Empty;
            this.SearchMessageLabel.ForeColor = Color.Black;
        }

        private void MemberDetailsControl_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Refresh datagrid with latest data from database after update or create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="savedMember"></param>
        private void MemberDetailsControl_MemberSaved(object sender, Member savedMember)
        {
            if (savedMember == null) return;

            RefreshMemberGrid();

            // Reselect the updated/added member in the grid if available
            SelectMemberInGrid(savedMember.MemberId);
        }

        /// <summary>
        /// Rerun the current search to get updated data
        /// </summary>
        private void RefreshMemberGrid()
        {
            try
            {
                MemberSearchCriteria criteria = this.BuildSearchCriteria();
                List<Member> members = this._controller.SearchMembers(criteria);
                this._memberBindingSource.DataSource = members;

                this.ShowMessage($"{members.Count} member(s) found.");
            }
            catch (Exception ex)
            {
                this.ShowError("Failed to refresh grid: " + ex.Message);
            }
        }

        /// <summary>
        /// Finds and selects the member in the grid after add/update
        /// </summary>
        private void SelectMemberInGrid(int memberId)
        {
            foreach (DataGridViewRow row in this.MembersDataGridView.Rows)
            {
                if (row.DataBoundItem is Member m && m.MemberId == memberId)
                {
                    this.MembersDataGridView.ClearSelection();
                    row.Selected = true;
                    this.MembersDataGridView.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }
    }
}