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
    public partial class UserManagementUI : Form
    {
        private string userName = string.Empty;
        private string password = string.Empty;
        private string confirmedPassword = string.Empty;

        public UserManageMode ManageMode { get; set; }

        public enum UserManageMode
        {
            eNewUser,
            ePasswordReset,
            eNormalUser
        }

        public UserManagementUI()
        {
            InitializeComponent();
        }        

        private void UserManagementUI_Shown(object sender, EventArgs e)
        {
            switch(this.ManageMode)
            {
                case UserManageMode.eNewUser:
                    this.picBoxNewReset.Visible = true;
                    this.picUserManagement.Visible = false;
                    this.groupBoxMain.Text = "New User";
                    this.btnMainButton.Text = "SIGN UP";
                    break;
                case UserManageMode.ePasswordReset:
                    this.picBoxNewReset.Visible = true;
                    this.picUserManagement.Visible = false;
                    this.groupBoxMain.Text = "Reset Password";
                    this.btnMainButton.Text = "RESET";
                    break;
                case UserManageMode.eNormalUser:
                    this.picUserManagement.Visible = true;
                    this.picBoxNewReset.Visible = false;
                    this.groupBoxMain.Text = "User Management";
                    
                    break;
            }
        }

        private void btnMainButton_Click(object sender, EventArgs e)
        {
            User userAccount = new User();

            if (!string.IsNullOrEmpty(this.userName))
            {
                if (this.password == this.confirmedPassword)
                {
                    userAccount.UserName = this.userName;
                    userAccount.Password = this.password;                    
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
            switch (this.ManageMode)
            {
            case UserManageMode.eNewUser:
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
            case UserManageMode.ePasswordReset:
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

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            this.userName = this.txtUserName.Text;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            this.password = this.txtPassword.Text;
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            this.confirmedPassword = this.txtConfirmPass.Text;
        }
    }
}
