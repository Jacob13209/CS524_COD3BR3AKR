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
    public partial class AccountManagement : Form
    {
        private string _userName = string.Empty;
        private string _password = string.Empty;
        private string _confirmedPassword = string.Empty;

        private UserManageMode _manageMode;

        public enum UserManageMode
        {
            eUserRegistration,
            eUserReset,
            eManagement
        }


        public AccountManagement(UserManageMode mode)
        {
            this._manageMode = mode;
            InitializeComponent();
        }

        private void AccountManagement_Shown(object sender, EventArgs e)
        {
            switch (this._manageMode)
            {
                case UserManageMode.eUserRegistration:                    
                    ((Control)this.tabRegistration).Enabled = true;
                    ((Control)this.tabReset).Enabled = false;
                    ((Control)this.tabUserManagement).Enabled = false;
                    this.tabManagement.SelectedTab = this.tabRegistration;
                    break;
                case UserManageMode.eUserReset:                    
                    ((Control)this.tabRegistration).Enabled = true;
                    ((Control)this.tabReset).Enabled = true;
                    ((Control)this.tabUserManagement).Enabled = false;
                    this.tabManagement.SelectedTab = this.tabReset;
                    break;
                case UserManageMode.eManagement:                   
                    ((Control)this.tabRegistration).Enabled = true;
                    ((Control)this.tabReset).Enabled = true;
                    ((Control)this.tabUserManagement).Enabled = true;
                    this.tabManagement.SelectedTab = this.tabUserManagement;
                    break;
            }
        }

        private void tabManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabManagement.SelectedTab == this.tabRegistration || this.tabManagement.SelectedTab == this.tabReset)
            {                
                this.groupUserRegReset.Parent = this.tabManagement.SelectedTab;

                // clear all the input
                this.txtUserName.Clear();
                this.txtPassword.Clear();
                this.txtConfirmPass.Clear();

                if (this.tabManagement.SelectedTab == this.tabRegistration)
                {                    
                    this.groupUserRegReset.Text = "New User";
                    this.btnOK.Text = "Sign Up";
                }
                else
                {
                    this.groupUserRegReset.Text = "User Reset";
                    this.btnOK.Text = "Reset";
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            User userAccount = new User();

            if (!string.IsNullOrEmpty(this._userName))
            {
                if (this._password == this._confirmedPassword)
                {
                    userAccount.UserName = this._userName;
                    userAccount.Password = this._password;
                }
                else
                {
                    // passwords not match
                    MessageBox.Show("Password and Confirmed Password does not match! \nPlease make sure type password carefully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtPassword.Clear();
                    this.txtConfirmPass.Clear();
                    return;
                }
            }
            else
            {
                // username is empty
                MessageBox.Show("Username is empty! \nPlease make sure to enter a valid Username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // only proceed when username not empty and both passwords matches
            switch (this._manageMode)
            {
                case UserManageMode.eUserRegistration:
                {
                    if (UserManager.IsUserExist(userAccount.UserName) == false)
                    {
                        // add new user into system
                        if (UserManager.AddNewUser(userAccount) == true)
                        {
                            MessageBox.Show("Registeration Successful! \nPlease login with new Username and Password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Close();
                        }
                        else
                        {
                            // unable to add user to the system
                            MessageBox.Show("Unable to add user to the system! \nPlease try again later.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        // username already exist
                        MessageBox.Show("Username already exist! \nPlease try different username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    break;
                }
                    
                case UserManageMode.eUserReset:
                {
                    if (UserManager.IsUserExist(userAccount.UserName) == true)
                    {
                        if (UserManager.UpdateUser(userAccount) == true)
                        {
                            MessageBox.Show("Password Reset Successful! \nPlease login with new password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Close();
                        }
                        else
                        {
                            // unable to reset password from system
                            MessageBox.Show("Unable to reset password at this time! \nPlease try again later.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        // username provided does not exist, unable to reset.
                        MessageBox.Show("Username does not exist! \nPlease make sure to enter a valid username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                }                                        
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            this._userName = this.txtUserName.Text;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            this._password = this.txtPassword.Text;
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            this._confirmedPassword = this.txtConfirmPass.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabManagement_Selecting(object sender, TabControlCancelEventArgs e)
        {
            bool showWarning = false;
            if (e.TabPage == this.tabUserManagement && this._manageMode != UserManageMode.eManagement)
            {
                e.Cancel = true;
                showWarning = true;
            }
            else if (e.TabPage == this.tabReset && this._manageMode == UserManageMode.eUserRegistration)
            {
                e.Cancel = true;
                showWarning = true;
            }
            else if (e.TabPage == this.tabRegistration && this._manageMode == UserManageMode.eUserReset)
            {
                e.Cancel = true;
                showWarning = true;
            }

            if (showWarning == true)
            {
                MessageBox.Show("Sorry! You don't have permission to access this TAB!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
