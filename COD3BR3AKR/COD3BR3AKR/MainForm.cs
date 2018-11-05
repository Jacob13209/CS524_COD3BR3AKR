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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public enum SystemMode
        {
            eEncryption,
            eDecryption
        }

        private SystemMode _userMode;

        private void MainForm_Load(object sender, EventArgs e)
        {
            // default settings to encryption
            this.mainTabCtrl.SelectedTab = this.tabEncrypt;
            this._userMode = SystemMode.eEncryption;

        }

        private void labSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void mainTabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // share controls between tabs
            this.groupFile.Parent = mainTabCtrl.SelectedTab;
            this.groupText.Parent = mainTabCtrl.SelectedTab;

            if (mainTabCtrl.SelectedTab.Name == "tabEncrypt")
            {
                this._userMode = SystemMode.eEncryption;
            }
            else if (mainTabCtrl.SelectedTab.Name == "tabDecrypt")
            {
                this._userMode = SystemMode.eDecryption;
            }
        }
    }
}
