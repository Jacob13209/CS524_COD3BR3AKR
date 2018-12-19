using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COD3BR3AKR
{
    public partial class AccountManagement : Form
    {
        private string _userID = string.Empty;
        private string _userName = string.Empty;
        private string _password = string.Empty;
        private string _userStatus = string.Empty;
        private string _confirmedPassword = string.Empty;

        private UserManageMode _manageMode;
        private static UserManageMode _currentManageMode;

        public static readonly string USER_INFO_CONFIG = Application.StartupPath + @"\SystemUsers.xml";
        public static readonly string USER_ID_INIT     = Application.StartupPath + @"\Setup.ini";

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public enum UserManageMode
        {
            eUserRegistration,
            eUserReset,
            eManagement
        }

        private readonly string[] SupportedUserStatus = new string[] {"ACTIVE", "INACTIVE" };

        private static AccountManagement _onlyAccountManagement;

        public static AccountManagement CreateInstance(UserManageMode mode)
        {
            if (_onlyAccountManagement == null )
            {
                _currentManageMode = mode;
                _onlyAccountManagement = new AccountManagement(mode);
            }
            else
            {
                if (_currentManageMode != mode)
                {
                    _onlyAccountManagement.Close();
                    _onlyAccountManagement = new AccountManagement(mode);
                }
            }

            return _onlyAccountManagement;
        }

        public AccountManagement(UserManageMode mode)
        {
            this._manageMode = mode;            
            InitializeComponent();
        }

        private void AccountManagement_Shown(object sender, EventArgs e)
        {          
            // passwords
            this.info_pass_txt.PasswordChar = '•';
            this.txtPassword.PasswordChar = '•';
            this.txtConfirmPass.PasswordChar = '•';

            switch (this._manageMode)
            {
                case UserManageMode.eUserRegistration:                    
                    this.tabManagement.SelectedTab = this.tabRegistration;
                    break;
                case UserManageMode.eUserReset:                    
                    this.tabManagement.SelectedTab = this.tabReset;
                    break;
                case UserManageMode.eManagement:                   
                    this.tabManagement.SelectedTab = this.tabUserManagement;
                    this.info_Status_combo.DataSource = SupportedUserStatus;
                    break;
            }
            RefreshUserList();
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
            if (!string.IsNullOrEmpty(this._userName))
            {
                if (this._password != this._confirmedPassword)
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
                    if (UserManager.IsUserExist(this._userName) == false)
                    {
                        // add new user into system
                        if (UserManager.AddNewUser(this._userName, this._password) == true)
                        {
                            log.Info("The new user '"+this._userName+"' was added successfully!");
                            MessageBox.Show("Registeration Successful! \nPlease login with new Username and Password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            // unable to add user to the system
                            log.Error("The new user '"+this._userName+"' failed to be added to the system");

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
                    if (UserManager.IsUserExist(this._userName) == true)
                    {
                        if (UserManager.ResetUser(this._userName, this._password) == true)
                        {
                            log.Info("The user '"+this._userName+"' successfully reset password!");
                            MessageBox.Show("Password Reset Successful! \nPlease login with new password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            // unable to reset password from system
                            log.Error("The user '"+this._userName+"' failed to reset password");
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
            else if (e.TabPage == this.tabReset && this._manageMode != UserManageMode.eUserReset)
            {
                e.Cancel = true;
                showWarning = true;
            }
            else if (e.TabPage == this.tabRegistration && this._manageMode != UserManageMode.eUserRegistration)
            {
                e.Cancel = true;
                showWarning = true;
            }

            if (showWarning == true)
            {
                MessageBox.Show("Sorry! You don't have permission to access this TAB!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AccountManagement_Load(object sender, EventArgs e)
        {
            if (File.Exists(USER_ID_INIT) == false)
            {
                UserManager.InitializeInitialUserID();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshUserList();
        }

        private void RefreshUserList()
        {
            this.allUserView.DataSource = null;
            this.allUserView.Refresh();
            this.allUserView.DataSource = UserManager.GetAllUsers().Select(o => new
            { User_ID = o.UserID, User_Name = o.UserName, User_Status = o.UserStatus }).ToList();
            if (this.allUserView.Rows.Count > 0)
            {
                this.allUserView.Rows[0].Selected = true;
            }
        }

        private void allUserView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in allUserView.SelectedRows)
                {
                    this.info_ID_txt.Text = row.Cells[0].Value.ToString();
                    this.info_name_txt.Text = row.Cells[1].Value.ToString();
                    this.info_Status_combo.SelectedItem = row.Cells[2].Value.ToString();
                    this.info_pass_txt.Text = string.Empty;
                }
            }
            catch { }
        }

        private void info_ID_txt_TextChanged(object sender, EventArgs e)
        {
            this._userID = this.info_ID_txt.Text;
        }

        private void info_name_txt_TextChanged(object sender, EventArgs e)
        {
            this._userName = this.info_name_txt.Text;
        }

        private void info_Status_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._userStatus = this.info_Status_combo.SelectedItem.ToString();
        }

        private void info_pass_txt_TextChanged(object sender, EventArgs e)
        {
            this._password = this.info_pass_txt.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this._userName) == true)
            {
                MessageBox.Show("Username is empty! \nPlease make sure to enter a valid Username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (UserManager.IsUserExist(this._userName) == true)
            {
                MessageBox.Show("Username already exist! \nPlease try different username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserManager.AddNewUser(this._userName, this._password, this._userStatus);

            log.Info("A new user '" + this._userName + "' was added to the system!");

            string infoMsg = string.Format("User {0} has been added to the system successfully!", this._userName);

            MessageBox.Show(infoMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this._userID))
            {
                // Do not allow user to change the user name
                if (this._userName == UserManager.GetUserNameBasedOnID(this._userID))
                {
                    MessageBox.Show("Sorry! \nYou don't have permission to update User's UserName.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    // if no changes being made to password, assume keep the orginal password
                    if (string.IsNullOrEmpty(this._password))
                    {
                        UserManager.UpdateUser(this._userID, this._userStatus);
                    }
                    else
                    {                        
                        UserManager.UpdateUser(this._userID, this._userName, this._password, this._userStatus);
                    }
                    log.Info("The user '" + this._userName + "' was updated in the system!");

                    string infoMsg = string.Format("User {0} has been updated successfully!", this._userName);

                    MessageBox.Show(infoMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string warningMsg = String.Format("Are you sure you want to DELETE Following User?\n[UserID={0} UserName={1}]", this._userID, this._userName);

            if (GetDialogResult(warningMsg) == true)
            {
                UserManager.RemoveUser(this._userID);
            }
            log.Info("The user '" + this._userName + "' has been deleted from the system!");
            string infoMsg = string.Format("User {0} has been deleted from the system successfully!", this._userName);

            MessageBox.Show(infoMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private bool GetDialogResult(string message)
        {
            DialogResult dialogResult = MessageBox.Show(message, "NOTICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (UserManager.IsUserExist(this._userName) == false)
            {
                this.labUserNameCheck.Text = "Valid";
                this.labUserNameCheck.ForeColor = Color.Green;
            }
            else
            {
                this.labUserNameCheck.Text = "*Already Exist";
                this.labUserNameCheck.ForeColor = Color.Red;
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            this.labUserNameCheck.Text = string.Empty;
        }

        private void AccountManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onlyAccountManagement = null;
        }
    }
}
