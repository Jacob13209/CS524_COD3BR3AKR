using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COD3BR3AKR
{
    public partial class UserLogin : Form
    {
        private const int MAX_ATTEMPTS_ALLOWED = 10;

        private string _username = string.Empty;
        private string _password = string.Empty;
        private int _numberOfFailures = 0;

        MainForm _mainForm;

        public UserLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '•';
        }

        private void showError(string errStr)
        {
            this.labError.Text = "Error: " + errStr;
            resetUserInput();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Reset the error msg when User Click on 'Sign in' again
            this.labError.Text = string.Empty;

            if (UserManager.IsUserExist(_username) == true && UserManager.IsUserActive(_username) == false)
            {
                showError("Your User Account is INACTIVE! Try resetting Password.");
            }
            else if (UserManager.IsUserAuthPass(_username, _password) == true)
            {
                // User Authentication success
                _mainForm = new MainForm(this);
                _mainForm.Show();
                this.Hide();
            }
            else
            {
                if (this._numberOfFailures >= MAX_ATTEMPTS_ALLOWED)
                {
                    UserManager.InactiveUser(this._username);
                }

                resetUserInput();
                this._numberOfFailures++;
                showError("The username or password is incorrect! Try again.");               
            }                        
        }

        private void linLableForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccountManagement _accountManForm = AccountManagement.CreateInstance(AccountManagement.UserManageMode.eUserReset);
            _accountManForm.TopMost = true;
            _accountManForm.Show();
        }

        public void resetUserInput()
        {
            this.txtUserName.ResetText();
            this.txtPassword.ResetText();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (this.txtUserName.Text != "")
            {
                this._username = this.txtUserName.Text;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (this.txtPassword.Text != "")
            {
                this._password = this.txtPassword.Text;
            }
        }

        private void linLabelSignUP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccountManagement _accountManForm = AccountManagement.CreateInstance(AccountManagement.UserManageMode.eUserRegistration);
            _accountManForm.TopMost = true;
            _accountManForm.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ready to exit!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
