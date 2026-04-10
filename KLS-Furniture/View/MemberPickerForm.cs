using KLS_Furniture.Model.Lookups;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KLS_Furniture.View
{
    public partial class MemberPickerForm : Form
    {
        public RentalMemberLookupItem SelectedMember { get; private set; }

        public MemberPickerForm(List<RentalMemberLookupItem> members)
        {
            InitializeComponent();

            dgvMembers.AutoGenerateColumns = false;
            dgvMembers.DataSource = members;

            btnSelect.Click += BtnSelect_Click;
            btnCancel.Click += BtnCancel_Click;
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