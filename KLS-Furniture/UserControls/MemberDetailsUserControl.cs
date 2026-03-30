using KLS_Furniture.Controller;
using KLS_Furniture.Model.Entities;
using KLS_Furniture.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace KLS_Furniture.UserControls
{
    /// <summary>
    /// User control class that handles Member info add, edit, and display functionality
    /// </summary>
    public partial class MemberDetailsUserControl : UserControl
    {
        private readonly MemberManagementController _controller;
        //Class variable that tracks edit vs new member function
        private bool _isEdit = false;
        //Class variable that tracks current member displayed
        private int _currentMemberID = -1;

        /// <summary>
        /// Raised when a member is added or updated.
        /// Allows datagrid to refresh with new/updated data.
        /// </summary>
        public event EventHandler<Member> MemberSaved;

        /// <summary>
        /// Contructor of MemberDetailsUserControl Class
        /// </summary>
        public MemberDetailsUserControl()
        {
            InitializeComponent();
            _controller = new MemberManagementController();
            this.DisableAllFields();
            this.PopulateStateCombo();
            this.PopulateGenderCombo();
            this.EditMemberButton.Enabled = false;
            this.SaveMemberButton.Enabled = false;
            this.BindUpdateClears();

        }

        /// <summary>
        /// Resets the member details control to its default state.
        /// </summary>
        public void ResetDisplay()
        {
            this._isEdit = false;
            this._currentMemberID = -1;

            this.ClearLabels();
            this.ClearInputs();
            this.DisableAllFields();

            this.AddMemberButton.Enabled = true;
            this.EditMemberButton.Enabled = false;
            this.SaveMemberButton.Enabled = false;
            this.MessageLabel.Text = string.Empty;
            this.MessageLabel.ForeColor = Color.Black;
        }

        /// <summary>
        /// Loads member data but keeps everything disabled
        /// Edit requires selecting Edit button
        /// </summary>
        /// <param name="member"> Member object to be displayed/edited</param>
        public void DisplayMember(Member member)
        {
            this._isEdit = false;
            this._currentMemberID = member.MemberId;

            this.FirstNameTextBox.Text = member.FirstName;
            this.LastNameTextBox.Text = member.LastName;
            this.PhoneTextBox.Text = member.Phone;
            this.DOBTextBox.Text = member.DateOfBirth.ToShortDateString();
            this.GenderComboBox.SelectedValue = member.Sex;
            this.AddressTextBox.Text = member.AddressLine1;
            this.AddLine2TextBox.Text = member.AddressLine2;
            this.CityTextBox.Text = member.City;
            this.StateComboBox.SelectedValue = member.State;
            this.ZipTextBox.Text = member.ZipCode;

            this.DisableAllFields();
            this.AddMemberButton.Enabled = true;
            this.EditMemberButton.Enabled = true;
            this.SaveMemberButton.Enabled = false;
            this.MessageLabel.Text = "Member details loaded. Click Edit to update.";
        }

        #region
        //Button response functions
        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            this.ClearLabels();
            this.ClearInputs();
            this.EnableAllFields();
            this.AddMemberButton.Enabled = false;
            this.EditMemberButton.Enabled = false;
            this.SaveMemberButton.Enabled = true;
            this.MessageLabel.Text = "Click Save to complete member add.";
        }

        private void EditMemberButton_Click(object sender, EventArgs e)
        {
            this._isEdit = true;
            this.EnableAllFields();
            this.AddMemberButton.Enabled = false;
            this.EditMemberButton.Enabled = false;
            this.SaveMemberButton.Enabled = true;
            this.MessageLabel.Text = "Editing member, click Save to update.";
        }

        private void SaveMemberButton_Click(object sender, EventArgs e)
        {
            if (!this.ValidateEntry()) return;

            Member member = new Member
            {
                FirstName = this.FirstNameTextBox.Text.Trim(),
                LastName = this.LastNameTextBox.Text.Trim(),
                Phone = this.PhoneTextBox.Text.Trim(),
                DateOfBirth = DateTime.Parse(this.DOBTextBox.Text),
                Sex = this.GenderComboBox.SelectedValue?.ToString(),
                AddressLine1 = this.AddressTextBox.Text.Trim(),
                AddressLine2 = this.AddLine2TextBox.Text.Trim(),
                City = this.CityTextBox.Text.Trim(),
                State = this.StateComboBox.SelectedValue?.ToString(),
                ZipCode = this.ZipTextBox.Text.Trim()
            };

            try
            {
                Member savedMember;
                string message;

                if (_isEdit)
                {
                    member.MemberId = _currentMemberID;
                    savedMember = _controller.UpdateMember(member);
                    message = "Member updated successfully!";
                }
                else
                {
                    savedMember = _controller.AddMember(member);
                    _currentMemberID = savedMember.MemberId;
                    message = "New member added successfully!"; 
                }
                this.ClearLabels();
                this.DisableAllFields();
                this.OnMemberSaved(savedMember);
                MessageLabel.Text = message;
                MessageLabel.ForeColor = Color.Green;
                this.EditMemberButton.Enabled = true;
                this.SaveMemberButton.Enabled = false;
                this.AddMemberButton.Enabled = true;
                _isEdit = false;
            }
            catch (Exception ex)
            {
                MessageLabel.Text = "Error saving member: " + ex.Message;
                MessageLabel.ForeColor = Color.Red;
            }

            
        }

        private void CancelMemberButton_Click(object sender, EventArgs e)
        {
            this.ClearLabels();
            this.DisableAllFields();
            this.AddMemberButton.Enabled = true;
            this.SaveMemberButton.Enabled = false;
            if (_isEdit == false)
            {
                this.ClearInputs();
                this._currentMemberID = -1;
            }
            if (this._currentMemberID != -1)
            {
                this.EditMemberButton.Enabled = true;
            } else
            {
                this.EditMemberButton.Enabled = false;
            }
            
            _isEdit = false;
        }
        #endregion

        #region
        //Combobox population functions
        private void PopulateStateCombo() 
        {
            this.StateComboBox.DataSource = US_States.GetAll();
            this.StateComboBox.DisplayMember = "Name";
            this.StateComboBox.ValueMember = "Abbreviation";
            this.StateComboBox.SelectedIndex = -1;
        }

        private void PopulateGenderCombo()
        {
            this.GenderComboBox.DataSource = new[]
                {
                    new { Option = "Male", Value = "M" },
                    new { Option = "Female", Value = "F" },
                    new { Option = "Unspecified", Value = "U" }
                };
            this.GenderComboBox.DisplayMember = "Option";
            this.GenderComboBox.ValueMember = "Value";
            this.GenderComboBox.SelectedIndex = -1;
        }

        #endregion

        #region
        //Helper functions
        private void EnableAllFields()
        {
            this.FirstNameTextBox.Enabled = true;
            this.LastNameTextBox.Enabled = true;
            this.PhoneTextBox.Enabled = true;
            this.DOBTextBox.Enabled = true;
            this.AddressTextBox.Enabled = true;
            this.ZipTextBox.Enabled = true;
            this.GenderComboBox.Enabled = true;
            this.StateComboBox.Enabled = true;
            this.AddLine2TextBox.Enabled = true;
            this.CityTextBox.Enabled = true;
        }

        private void DisableAllFields()
        {
            this.FirstNameTextBox.Enabled = false;
            this.LastNameTextBox.Enabled = false;
            this.PhoneTextBox.Enabled = false;
            this.DOBTextBox.Enabled = false;
            this.AddressTextBox.Enabled = false;
            this.ZipTextBox.Enabled = false;
            this.GenderComboBox.Enabled = false;
            this.StateComboBox.Enabled = false;
            this.AddLine2TextBox.Enabled = false;
            this.CityTextBox.Enabled = false;
        }

        private void ClearLabels()
        {
            this.FNameErrorLabel.Text = "";
            this.LNameErrorLabel.Text = "";
            this.PhoneErrorLabel.Text = "";
            this.DOBErrorLabel.Text = "";
            this.GenderErrorLabel.Text = "";
            this.AddressErrorLabel.Text = "";
            this.StateErrorLabel.Text = "";
            this.ZipErrorLabel.Text = "";
            this.MessageLabel.Text = "";
            this.CityErrorLabel.Text = "";
            this.MessageLabel.ForeColor = System.Drawing.Color.Black;
        }

        private void ClearInputs() 
        {
            this.FirstNameTextBox.Clear();
            this.LastNameTextBox.Clear();
            this.PhoneTextBox.Clear();
            this.DOBTextBox.Clear();
            this.AddressTextBox.Clear();
            this.AddLine2TextBox.Clear();
            this.CityTextBox.Clear();
            this.ZipTextBox.Clear();
            this.GenderComboBox.SelectedIndex = -1;
            this.StateComboBox.SelectedIndex = -1;
        }

        private void BindUpdateClears()
        {
            this.FirstNameTextBox.TextChanged += (s, e) => this.ClearLabels();
            this.LastNameTextBox.TextChanged += (s, e) => this.ClearLabels();
            this.PhoneTextBox.TextChanged += (s, e) => this.ClearLabels();
            this.DOBTextBox.TextChanged += (s, e) => this.ClearLabels();
            this.AddressTextBox.TextChanged += (s, e) => this.ClearLabels();
            this.AddLine2TextBox.TextChanged += (s, e) => this.ClearLabels();
            this.CityTextBox.TextChanged += (s, e) => this.ClearLabels();
            this.ZipTextBox.TextChanged += (s, e) => this.ClearLabels();
            this.StateComboBox.SelectedValueChanged += (s, e) => this.ClearLabels();
            this.GenderComboBox.SelectedValueChanged += (s, e) => this.ClearLabels();
        }

        #endregion

        private bool ValidateEntry()
        {
            bool isValid = true;
            this.ClearLabels();

            // First Name
            if (string.IsNullOrWhiteSpace(this.FirstNameTextBox.Text) || this.FirstNameTextBox.Text.Length < 2)
            {
                this.FNameErrorLabel.Text = "First name is required (min 2 chars)";
                isValid = false;
            }

            // Last Name
            if (string.IsNullOrWhiteSpace(this.LastNameTextBox.Text) || this.LastNameTextBox.Text.Length < 2)
            {
                this.LNameErrorLabel.Text = "Last name is required (min 2 chars)";
                isValid = false;
            }

            // Phone
            if (string.IsNullOrWhiteSpace(this.PhoneTextBox.Text) || this.PhoneTextBox.Text.Length < 10)
            {
                this.PhoneErrorLabel.Text = "Valid phone number required";
                isValid = false;
            }

            // DOB
            if (!DateTime.TryParse(this.DOBTextBox.Text, out DateTime dob) || dob > DateTime.Today.AddYears(-18))
            {
                this.DOBErrorLabel.Text = "Valid date of birth required (Must be 18+)";
                isValid = false;
            }

            // Gender
            if (this.GenderComboBox.SelectedIndex == -1)
            {
                this.GenderErrorLabel.Text = "Please select gender";
                isValid = false;
            }

            // Address
            if (string.IsNullOrWhiteSpace(this.AddressTextBox.Text))
            {
                this.AddressErrorLabel.Text = "Address is required";
                isValid = false;
            }

            // City
            if (string.IsNullOrWhiteSpace(this.CityTextBox.Text))
            {
                this.CityErrorLabel.Text = "City is required";
                isValid = false;
            }

            // State
            if (this.StateComboBox.SelectedIndex == -1)
            {
                this.StateErrorLabel.Text = "Please select a state";
                isValid = false;
            }

            // Zip Code (5 digits)
            if (string.IsNullOrWhiteSpace(this.ZipTextBox.Text) || this.ZipTextBox.Text.Length != 5 || !int.TryParse(this.ZipTextBox.Text, out _))
            {
                this.ZipErrorLabel.Text = "Valid 5-digit zip code required";
                isValid = false;
            }

            if (!isValid)
            {
                this.MessageLabel.Text = "Please fix the errors noted";
                this.MessageLabel.ForeColor = Color.Red;
            }
                
            return isValid;
        }

        protected virtual void OnMemberSaved(Member savedMember)
        {
            MemberSaved?.Invoke(this, savedMember);
        }

    }
}
