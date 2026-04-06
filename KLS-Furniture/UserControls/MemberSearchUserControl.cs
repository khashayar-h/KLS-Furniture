using KLS_Furniture.Model;
using KLS_Furniture.Model.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KLS_Furniture.UserControls
{
    /// <summary>
    /// Reusable control that contains the member search fields and the results DataGridView.
    /// </summary>
    public partial class MemberSearchUserControl : UserControl
    {
        private readonly BindingSource _memberBindingSource;

        public MemberSearchUserControl()
        {
            InitializeComponent();

            _memberBindingSource = new BindingSource();
            ConfigureResultsGrid();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            // Clear message when user types in any search field
            MemberIdSearchTextBox.TextChanged += (s, e) => ClearMessage();
            PhoneSearchTextBox.TextChanged += (s, e) => ClearMessage();
            FirstNameSearchTextBox.TextChanged += (s, e) => ClearMessage();
            LastNameSearchTextBox.TextChanged += (s, e) => ClearMessage();

            // Button events
            SearchMemberButton.Click += (s, e) => SearchClicked?.Invoke(this, EventArgs.Empty);
            ClearSearchButton.Click += (s, e) => ClearClicked?.Invoke(this, EventArgs.Empty);

            // Grid selection event
            MembersDataGridView.SelectionChanged += MembersDataGridView_SelectionChanged;
        }

        /// <summary>
        /// Configures columns and binding for the results grid.
        /// </summary>
        private void ConfigureResultsGrid()
        {
            MembersDataGridView.AutoGenerateColumns = false;
            MembersDataGridView.Columns.Clear();

            MembersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            MembersDataGridView.ScrollBars = ScrollBars.Both;

            MembersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MemberIdColumn",
                HeaderText = "Member ID",
                DataPropertyName = "MemberId",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            });

            MembersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FirstNameColumn",
                HeaderText = "First Name",
                DataPropertyName = "FirstName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            });

            MembersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LastNameColumn",
                HeaderText = "Last Name",
                DataPropertyName = "LastName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            });

            MembersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PhoneColumn",
                HeaderText = "Phone",
                DataPropertyName = "Phone",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            });

            MembersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateOfBirthColumn",
                HeaderText = "Date of Birth",
                DataPropertyName = "DateOfBirth",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "d" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            });

            MembersDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AddressColumn",
                HeaderText = "Address",
                DataPropertyName = "FullAddress",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            });

            MembersDataGridView.DataSource = _memberBindingSource;
        }

        #region Public Properties for Designer / Easy Binding

        /// <summary>
        /// Public setter/getter method for member id text
        /// </summary>
        public string MemberIdText
        {
            get => MemberIdSearchTextBox.Text;
            set => MemberIdSearchTextBox.Text = value ?? "";
        }

        /// <summary>
        /// Public setter/getter method for first name text
        /// </summary>
        public string FirstNameText
        {
            get => FirstNameSearchTextBox.Text;
            set => FirstNameSearchTextBox.Text = value ?? "";
        }

        /// <summary>
        /// Public setter/getter method for last name text
        /// </summary>
        public string LastNameText
        {
            get => LastNameSearchTextBox.Text;
            set => LastNameSearchTextBox.Text = value ?? "";
        }

        /// <summary>
        /// Public setter/getter method for phone text
        /// </summary>
        public string PhoneText
        {
            get => PhoneSearchTextBox.Text;
            set => PhoneSearchTextBox.Text = value ?? "";
        }

        #endregion

        #region Public Events
        /// <summary>
        /// Public event variables to be handled in parent containers
        /// </summary>
        public event EventHandler SearchClicked;
        public event EventHandler ClearClicked;
        public event EventHandler<Member> MemberSelected;

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds a search criteria object from the textboxes.
        /// </summary>
        /// <returns>The populated search criteria.</returns>
        public MemberSearchCriteria BuildSearchCriteria()
        {
            int? memberId = null;

            if (!string.IsNullOrWhiteSpace(MemberIdSearchTextBox.Text))
            {
                if (!int.TryParse(MemberIdSearchTextBox.Text.Trim(), out int parsedId))
                {
                    throw new FormatException("Member ID must be numeric.");
                }
                memberId = parsedId;
            }

            return new MemberSearchCriteria
            {
                MemberID = memberId,
                Phone = PhoneSearchTextBox.Text.Trim(),
                FirstName = FirstNameSearchTextBox.Text.Trim(),
                LastName = LastNameSearchTextBox.Text.Trim()
            };
        }

        /// <summary>
        /// Clears all search inputs and results.
        /// </summary>
        public void Clear()
        {
            MemberIdSearchTextBox.Clear();
            FirstNameSearchTextBox.Clear();
            LastNameSearchTextBox.Clear();
            PhoneSearchTextBox.Clear();
            _memberBindingSource.DataSource = null;
            ClearMessage();
        }

        /// <summary>
        /// Displays a normal status message.
        /// </summary>
        public void ShowMessage(string message)
        {
            SearchMessageLabel.ForeColor = Color.Black;
            SearchMessageLabel.Text = message;
        }

        /// <summary>
        /// Displays an error message.
        /// </summary>
        public void ShowError(string message)
        {
            SearchMessageLabel.ForeColor = Color.Red;
            SearchMessageLabel.Text = message;
        }

        /// <summary>
        /// Clears the message label.
        /// </summary>
        public void ClearMessage()
        {
            SearchMessageLabel.Text = string.Empty;
            SearchMessageLabel.ForeColor = Color.Black;
        }

        /// <summary>
        /// Sets datasource to provided members.
        /// </summary>
        public void SetDataSource(List<Member> members)
        {
            _memberBindingSource.DataSource = members;
        }

        /// <summary>
        /// Returns the selected member
        /// </summary>
        public Member GetSelectedMember()
        {
            return MembersDataGridView.CurrentRow?.DataBoundItem as Member;
        }

        #endregion

        private void MembersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (MembersDataGridView.CurrentRow?.DataBoundItem is Member selectedMember)
            {
                MemberSelected?.Invoke(this, selectedMember);
            }
        }
    }
}