using KLS_Furniture.Model.Lookups;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KLS_Furniture.View
{
    /// <summary>
    /// Class that allows user to select a member from list
    /// </summary>
    public partial class MemberPickerForm : Form
    {
        private readonly BindingSource _bindingSource;

        /// <summary>
        /// Class variable for member selected 
        /// </summary>
        public RentalMemberLookupItem SelectedMember { get; private set; }

        /// <summary>
        /// Constructor of MemberPickerForm class
        /// </summary>
        /// <param name="members">List of memebers to display</param>
        public MemberPickerForm(List<RentalMemberLookupItem> members)
        {
            InitializeComponent();

            _bindingSource = new BindingSource();

            ConfigureGrid();

            _bindingSource.DataSource = members;

            btnSelect.Click += BtnSelect_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        private void ConfigureGrid()
        {
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.AutoGenerateColumns = false;
            dgvMembers.Columns.Clear();

            dgvMembers.DataSource = _bindingSource;

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MemberIdColumn",
                HeaderText = "Member ID",
                DataPropertyName = "MemberId",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvMembers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DisplayTextColumn",
                HeaderText = "Member",
                DataPropertyName = "DisplayText",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (dgvMembers.CurrentRow == null)
            {
                MessageBox.Show("Please select a member first.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedMember = dgvMembers.CurrentRow.DataBoundItem as RentalMemberLookupItem;

            if (SelectedMember == null)
            {
                MessageBox.Show("Please select a valid member.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}