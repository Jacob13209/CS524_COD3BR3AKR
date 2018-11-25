using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COD3BR3AKR
{
    #region Enumeration Declaration
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

    public enum SupportedAlogrithm
    {        
        AES,
        RSA,
        TripleDES
    }
    #endregion

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private SystemMode              _userMode;
        private InputOption             _inputOption;
        private SupportedAlogrithm      _selectedAlogrithm;

        private Stopwatch _stopWatch = new Stopwatch();

        private string _textInput = string.Empty;
        private string _textOutput = string.Empty;

        private string _inputFileName   = string.Empty;
        private string _inputFilePath   = string.Empty;
        private string _outputFilePath  = string.Empty;
        private string _keyFilePath     = string.Empty;

        private bool   _fileCryptionRes = false;

        private bool    _isKeyRequired  = false;
        private string  _customizedKey  = string.Empty;

        Dictionary<SupportedAlogrithm, bool> AlogrithmKeyPair = new Dictionary<SupportedAlogrithm, bool>()
        {
            { SupportedAlogrithm.AES,       true },                        
            { SupportedAlogrithm.RSA,       true },
            { SupportedAlogrithm.TripleDES, true }
        };

        private void MainForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            // default settings to encryption
            this.mainTabCtrl.SelectedTab = this.tabEncrypt;
            this._userMode = SystemMode.eEncryption;
            this.labStatus.Text = string.Format("Ready for {0}", ((this._userMode == SystemMode.eEncryption) ? "Encryption" : "Decryption"));
            this.labDuration.Text = string.Empty;

            // use supported alogrithms as data source for selection
            this.comboAlogrithms.DataSource = Enum.GetNames(typeof(SupportedAlogrithm)).ToList();
        }

        private void labSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void mainTabCtrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // share controls between tabs
            this.groupFile.Parent = mainTabCtrl.SelectedTab;
            this.groupText.Parent = mainTabCtrl.SelectedTab;

            ResetInputControls();

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
            this._selectedAlogrithm = (SupportedAlogrithm)Enum.Parse(typeof(SupportedAlogrithm), this.comboAlogrithms.SelectedItem.ToString());
            if (AlogrithmKeyPair.Keys.Contains(this._selectedAlogrithm))
            {
                this._isKeyRequired = AlogrithmKeyPair[this._selectedAlogrithm];
            }

            this.txtKey.Clear();
            this.btnImportKey.Enabled  = this._isKeyRequired;
            this.cbKeyRequired.Checked = this._isKeyRequired;
            this.txtKey.ReadOnly       = !this._isKeyRequired;

            if (this._selectedAlogrithm == SupportedAlogrithm.RSA)
            {
                string message = string.Format("RSA needs Public/Private keys for Encryption/Decryption.\nDo you want to Generate and Save them?");
                DialogResult dialogResult = MessageBox.Show(message, "NOTICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    // generate public and private keys
                    RSACryption.GenerateRSAKeys(CryptionHelper.PRIVATE_KEY_PATH, CryptionHelper.PUBLIC_KEY_PATH);
                    message = string.Format("PublicKey.xml and PrivateKey.xml are saved at: \n{0}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                    MessageBox.Show(message,"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

                this._outputFilePath = Path.GetDirectoryName(this._inputFilePath) + "\\" + _inputFileName + ((this._userMode == SystemMode.eDecryption) ? ".dec" : ".enc");
                this.txtFileOutput.Text = this._outputFilePath;
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
            if (validateInput() == false)
            {
                MessageBox.Show("Please make sure you have entered or selected proper Input!\nMake sure to enter Customized Key if it is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.btnReset.Enabled   = false;
            this.btnCancel.Enabled  = true;
            this.labStatus.Text     = string.Format("{0} in Progress", ((this._userMode == SystemMode.eEncryption) ? "Encryption" : "Decryption"));
            this.labDuration.Text   = string.Empty;
            
            // initialize the cryption helper object
            CryptionHelper myHelper = new CryptionHelper(this._customizedKey, this._selectedAlogrithm);

            MethodInvoker mWorker = delegate
            {
                // restart the stopwatch to keep track of time
                this._stopWatch.Restart();

                switch (this._userMode)
                {
                    case SystemMode.eEncryption:
                    {
                        switch (this._inputOption)
                        {
                            case InputOption.eFile:
                                this._fileCryptionRes = myHelper.Encrypt(this._inputFilePath, this._outputFilePath);
                                break;
                            case InputOption.eText:
                                this._textOutput = myHelper.Encrypt(this._textInput);
                                this.txtRichOutput.Text = this._textOutput;
                                break;
                        }
                        break;
                    }                        
                    case SystemMode.eDecryption:
                    {
                        switch (this._inputOption)
                        {
                            case InputOption.eFile:
                                this._fileCryptionRes = myHelper.Decrypt(this._inputFilePath, this._outputFilePath);
                                break;
                            case InputOption.eText:
                                this._textOutput = myHelper.Decrypt(this._textInput);
                                this.txtRichOutput.Text = this._textOutput;
                                break;
                        }
                        break;
                    }                        
                }
            };
            mWorker.BeginInvoke(OperationCallbackFunction, mWorker);
        }

        private bool validateInput()
        {
            bool retVal = false;

            switch(this._inputOption)
            {
                case InputOption.eFile:
                    if (string.IsNullOrEmpty(this._inputFilePath) == false)
                    {
                        retVal = true;
                    }
                    break;
                case InputOption.eText:
                    if (string.IsNullOrEmpty(this._textInput) == false)
                    {
                        retVal = true;
                    }
                    break;
            }

            if (this.cbKeyRequired.Checked == true)
            {
                retVal &= !string.IsNullOrEmpty(this._customizedKey);
            }

            return retVal;
        }

        private void OperationCallbackFunction(IAsyncResult ar)
        {
            this._stopWatch.Stop();
            this.btnOK.Enabled      = true;
            this.btnCancel.Enabled  = false;
            this.btnReset.Enabled   = true;

            string modeStr = (this._userMode == SystemMode.eEncryption) ? "Encryption" : "Decryption";                    

            if ((this._inputOption == InputOption.eText && string.IsNullOrEmpty(this._textOutput)) ||
                (this._inputOption == InputOption.eFile && this._fileCryptionRes == false))
            {
                string errorMsg     = string.Format("Failed to complete this {0}!", modeStr);
                this.labStatus.Text = errorMsg;

                if (this._userMode == SystemMode.eDecryption && this.cbKeyRequired.Checked == true)
                {
                    errorMsg += "\nMake sure the Key you entered is Correct!";
                }               
                MessageBox.Show(errorMsg, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            else
            {
                this.labStatus.Text   = string.Format("{0} completed successfully!", modeStr);
                this.labDuration.Text = string.Format("{0} Milliseconds elapsed for this {1}",
                                                      (this._stopWatch.ElapsedMilliseconds.ToString()),
                                                      modeStr);
            }            
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            this._customizedKey = this.txtKey.Text;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetInputControls();
        }

        private void ResetInputControls()
        {
            this.groupText.Enabled = true;
            this.groupFile.Enabled = true;

            // reset the status display
            this.labStatus.Text = string.Format("Ready for {0}", ((this._userMode == SystemMode.eEncryption) ? "Encryption" : "Decryption"));
            this.labDuration.Text = string.Empty;

            foreach (var control in this.groupText.Controls)
            {
                if (control is RichTextBox)
                {
                    ((RichTextBox)control).Clear();
                }
            }

            foreach (var control in this.groupFile.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }
        }

        private void txtFileInput_TextChanged(object sender, EventArgs e)
        {
            this._inputFilePath = this.txtFileInput.Text;
        }

        private void txtFileOutput_TextChanged(object sender, EventArgs e)
        {
            this._outputFilePath = this.txtFileOutput.Text;
        }

        private void aboutCOD3BR3AKRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void btnImportKey_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDiag = new OpenFileDialog();
            openFileDiag.Title = "Please Select Key file";
            openFileDiag.Multiselect = false;
            openFileDiag.Filter = "All Files|*.*|XML Files|*.xml|Certificate Files|*.pem";

            if (openFileDiag.ShowDialog() == DialogResult.OK)
            {
                this._keyFilePath = openFileDiag.FileName;

                using (StreamReader sw = new StreamReader(this._keyFilePath))
                {
                    this._customizedKey = sw.ReadToEnd();
                }
                this.txtKey.Text = this._customizedKey;
            }
        }

        private void txtKey_MouseHover(object sender, EventArgs e)
        {
            if (! string.IsNullOrEmpty(this._customizedKey))
            {
                myToolTip.SetToolTip(this.txtKey, this._customizedKey);
            }            
        }

        private void txtFileInput_MouseHover(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this._inputFilePath))
            {
                myToolTip.SetToolTip(this.txtFileInput, this._inputFilePath);
            }
        }

        private void txtFileOutput_MouseHover(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this._outputFilePath))
            {
                myToolTip.SetToolTip(this.txtFileOutput, this._outputFilePath);
            }
        }
    }
}
