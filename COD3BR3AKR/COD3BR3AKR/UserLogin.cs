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
        private string _username = string.Empty;
        private string _password = string.Empty;
        
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
            User currentUser = new User(_username, _password);

            if (UserManager.IsUserAuthPass(currentUser) == true)
            {
                string welcomeMsg = string.Format("Weclome to COD3BR3AKR! {0}", _username);
                MessageBox.Show(welcomeMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                

                MainForm myMain = new MainForm();
                myMain.TopMost = true;
                myMain.Show();                
            }
            else
            {
                resetUserInput();
                showError("The username or password is incorrect! Try again.");
            }                        
        }


        private void linLableForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccountManagement accountManage = new AccountManagement(AccountManagement.UserManageMode.eUserReset);

            accountManage.Show();
        }

        private void resetUserInput()
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
            AccountManagement accountManage = new AccountManagement(AccountManagement.UserManageMode.eUserRegistration);

            accountManage.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ready to exit!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
    }
}
