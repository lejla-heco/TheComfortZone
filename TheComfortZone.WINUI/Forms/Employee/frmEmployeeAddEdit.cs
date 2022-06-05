using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.DTO.User;
using TheComfortZone.DTO.Utils;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.Employee
{
    public partial class frmEmployeeAddEdit : Form
    {
        UserAPIService userAPIService = new UserAPIService();
        private string EMPLOYEE_ROLE = UserType.Employee.ToString();
        private UserResponse? user;
        private bool design = false;

        public frmEmployeeAddEdit(UserResponse user = null)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            this.user = user;
            design = this.user == null ? false : true;
        }

        private void frmEmployeeAddEdit_Load(object sender, EventArgs e)
        {
            if (design)
                loadUserData();
        }

        private void loadUserData()
        {
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtAdress.Text = user.Adress;
            txtPhoneNumber.Text = user.PhoneNumber;
            txtEmail.Text = user.Email;
            txtUsername.Text = user.Username;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (!design)
                {
                    UserInsertRequest insert = new UserInsertRequest();
                    insert.FirstName = txtFirstName.Text;
                    insert.LastName = txtLastName.Text;
                    insert.Adress = txtAdress.Text;
                    insert.PhoneNumber = txtPhoneNumber.Text;
                    insert.Email = txtEmail.Text;
                    insert.Username = txtUsername.Text;
                    insert.Password = txtPassword.Text;
                    insert.PasswordConfirmation = txtPasswordConfirmation.Text;
                    insert.RoleName = EMPLOYEE_ROLE;

                    if (insert.Password != insert.PasswordConfirmation)
                        MessageBox.Show("Password and Password confirmation fields must be the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    else
                    {
                        var response = await userAPIService.Post(insert);
                        if (response != null)
                        {
                            MessageBox.Show("Successfully added new employee!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                        }
                    }
                }

                if (design)
                {
                    UserUpdateRequest update = new UserUpdateRequest();
                    update.FirstName = txtFirstName.Text;
                    update.LastName = txtLastName.Text;
                    update.Adress = txtAdress.Text;
                    update.PhoneNumber = txtPhoneNumber.Text;
                    update.Email = txtEmail.Text;
                    update.Username = txtUsername.Text;
                    update.Password = txtPassword.Text;
                    update.PasswordConfirmation = txtPasswordConfirmation.Text;

                    var response = await userAPIService.Put(user.UserId, update);
                    if (response != null)
                    {
                        MessageBox.Show("Successfully updated employee!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        /** VALIDATION **/
        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errorProvider.SetError(txtFirstName, "Field first name cannot be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtFirstName, null);
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                e.Cancel = true;
                txtLastName.Focus();
                errorProvider.SetError(txtLastName, "Field last name cannot be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtLastName, null);
            }
        }

        private void txtAdress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdress.Text))
            {
                e.Cancel = true;
                txtAdress.Focus();
                errorProvider.SetError(txtAdress, "Adress field cannot be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtAdress, null);
            }
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                e.Cancel = true;
                txtPhoneNumber.Focus();
                errorProvider.SetError(txtPhoneNumber, "Phone number field cannot be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtPhoneNumber, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider.SetError(txtEmail, "Email field cannot be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider.SetError(txtUsername, "Username field cannot be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtUsername, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!design)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    e.Cancel = true;
                    txtPassword.Focus();
                    errorProvider.SetError(txtPassword, "Password field cannot be left blank!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtPassword, null);
                }
            }
        }

        private void txtPasswordConfirmation_Validating(object sender, CancelEventArgs e)
        {
            if (!design || design && !string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (string.IsNullOrWhiteSpace(txtPasswordConfirmation.Text))
                {
                    e.Cancel = true;
                    txtPasswordConfirmation.Focus();
                    errorProvider.SetError(txtPasswordConfirmation, "Password confirmation field cannot be left blank!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider.SetError(txtPasswordConfirmation, null);
                }
            }
        }
    }
}
