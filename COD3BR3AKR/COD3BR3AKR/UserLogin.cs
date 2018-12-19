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

        //Necessary for logging 
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string _username = string.Empty;
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
                log.Error(_username+" is INACTIVE, so failed logon"); //This adds an "Error" log to a file and console.
                showError("Your User Account is INACTIVE! Try resetting Password.");
            }
            else if (UserManager.IsUserAuthPass(_username, _password) == true)
            {
                // User Authentication success
                log.Info(_username + " successfully logged in!"); //This adds an "Info" log to a file and console.
                _mainForm = new MainForm(this);
                _mainForm.Show();
                this.Hide();
            }
            else
            {
                if (this._numberOfFailures >= MAX_ATTEMPTS_ALLOWED)
                {
                    log.Error(_username + " failed authentication more than " + MAX_ATTEMPTS_ALLOWED +" times so account became INACTIVE"); //This adds an "Error" log to a file and console.

                    UserManager.InactiveUser(this._username);
                }

                resetUserInput();
                this._numberOfFailures++;
                log.Error(_username + " failed authentication for the "+this._numberOfFailures+" time(s)"); //This adds an "Error" log to a file and console.
                showError("The username or password is incorrect! Try again.");               
            }                        
        }

        private void linLableForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            log.Info(_username + " clicked on reset link");
            AccountManagement _accountManForm = AccountManagement.CreateInstance(AccountManagement.UserManageMode.eUserReset, _username);
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
                //log.Info(_username + " updated name to "+ this.txtUserName.Text);
                this._username = this.txtUserName.Text;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (this.txtPassword.Text != "")
            {
                //log.Info(_username + " updated password");
                this._password = this.txtPassword.Text;
            }
        }

        private void linLabelSignUP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //log.Info(_username + " clicked on SignUp ");

            AccountManagement _accountManForm = AccountManagement.CreateInstance(AccountManagement.UserManageMode.eUserRegistration, _username);
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
