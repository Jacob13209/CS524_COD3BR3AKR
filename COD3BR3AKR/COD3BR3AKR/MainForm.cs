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

        public enum InputOption
        {
            eText,
            eFile
        }

        private SystemMode      _userMode;
        private InputOption     _inputOption;

        private string _textInput = string.Empty;
        private string _textOutput = string.Empty;

        private string _inputFileName = string.Empty;
        private string _inputFilePath = string.Empty;
        private string _outputFilePath = string.Empty;

        private bool    _isKeyRequired = false;
        private string  _customizedKey = string.Empty;

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

            if (mainTabCtrl.SelectedTab == this.tabEncrypt)
            {
                this._userMode = SystemMode.eEncryption;
            }
            else if (mainTabCtrl.SelectedTab == this.tabDecrypt)
            {
                this._userMode = SystemMode.eDecryption;
            }
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountManagement accountManagement = new AccountManagement(AccountManagement.UserManageMode.eManagement);

            accountManagement.Show();
        }

        private void comboAlogrithms_SelectedIndexChanged(object sender, EventArgs e)
        {



            this.cbKeyRequired.Checked = this._isKeyRequired;

            if (this._isKeyRequired == true)
            {
                txtKey.ReadOnly = false;
            }
            else
            {
                txtKey.ReadOnly = true;
            }
        }

        private void txtRichInput_TextChanged(object sender, EventArgs e)
        {
            this._textInput = this.txtRichInput.Text;

        }

        private void txtRichInput_Enter(object sender, EventArgs e)
        {
            this.groupFile.Enabled = false;
            this._inputOption = InputOption.eText;
        }

        private void txtRichInput_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this._textInput))
            {
                this.groupFile.Enabled = true;
                this._inputOption = InputOption.eFile;
            }            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDiag = new OpenFileDialog();
            openFileDiag.Title = "Please Select File";
            openFileDiag.Multiselect = false;
            openFileDiag.Filter = "All Files|*.*|Text Files|*.txt";

            if (openFileDiag.ShowDialog() == DialogResult.OK)
            {
                this._inputFilePath = openFileDiag.FileName;
                this._inputFileName = Path.GetFileName(this._inputFilePath);

                this.txtFileInput.Text = this._inputFilePath;
                this._inputOption = InputOption.eFile;
                this.groupText.Enabled = false;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                {
                    this._outputFilePath = folderBrowser.SelectedPath + "\\" + _inputFileName + ((this._userMode == SystemMode.eDecryption) ? ".dec" : ".enc");
                    this.txtFileOutput.Text = this._outputFilePath;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch(this._inputOption)
            {
                case InputOption.eFile:
                    break;
                case InputOption.eText:
                    break;
            }
        }
    }
}
