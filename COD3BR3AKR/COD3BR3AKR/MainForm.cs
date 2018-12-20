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
        private readonly int MAX_ENCRYPTION_LENGTH = 300;

        //Initialize logs the following way:
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //where is the log file
        private static readonly string LOG_FILE_PATH = Application.StartupPath + @"\COD3BR3AKR.log";

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

        private bool    _isSignOut      = false;
        private bool    _isKeyRequired  = false;
        private string  _customizedKey  = string.Empty;

        private UserLogin _loginForm;
        private AccountManagement _accountManagementForm;

        Dictionary<SupportedAlogrithm, bool> AlogrithmKeyPair = new Dictionary<SupportedAlogrithm, bool>()
        {
            { SupportedAlogrithm.AES,       true },                        
            { SupportedAlogrithm.RSA,       true },
            { SupportedAlogrithm.TripleDES, true }
        };

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(UserLogin loginForm)
        {
            this._loginForm = loginForm;
            InitializeComponent();
        }

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
            _isSignOut = true;
            log.Info(_loginForm._username+" signed out of the application"); //This adds an "INFO" log to a file and console.
            _loginForm.Show();
            _loginForm.resetUserInput();
            this.Close();
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
            _accountManagementForm = AccountManagement.CreateInstance(AccountManagement.UserManageMode.eManagement, _loginForm._username);
            _accountManagementForm.TopMost = true;
            _accountManagementForm.Show();                      
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
                string message = string.Empty;

                if (this._inputOption == InputOption.eFile)
                {
                    message = string.Format("RSA is not supported yet for File Input!\nPlease try a different alogrithm.");
                    MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    message = string.Format("RSA needs Public/Private keys for Encryption/Decryption.\nDo you want to Generate and Save them?");
                    DialogResult dialogResult = MessageBox.Show(message, "NOTICE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // generate public and private keys
                        RSACryption.GenerateRSAKeys(CryptionHelper.PRIVATE_KEY_PATH, CryptionHelper.PUBLIC_KEY_PATH);
                        message = string.Format("PublicKey.xml and PrivateKey.xml are saved at: \n{0}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
                        MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }                
            }
        }

        private void txtRichInput_TextChanged(object sender, EventArgs e)
        {
            this._textInput = this.txtRichInput.Text;
            if (this._userMode == SystemMode.eEncryption && this._textInput.Length > MAX_ENCRYPTION_LENGTH)
            {
                string warningMsg = string.Format("{0} characters is the maximum input for Encryption! \nYou have entered {1} characters.", 
                                                  MAX_ENCRYPTION_LENGTH, 
                                                  this._textInput.Length);
                log.Warn(string.Format("{0} entered {1} characters that exceeds the maximum supported {2} characters", _loginForm._username, this._textInput.Length, MAX_ENCRYPTION_LENGTH));
                MessageBox.Show(warningMsg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

                this._outputFilePath = Path.GetDirectoryName(this._inputFilePath) + "\\" + _inputFileName + ((this._userMode == SystemMode.eDecryption) ? "_DECRYPTED" : "_ENCRYPTED");
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
                log.Error(_loginForm._username + " clicked Main Form 'OK' with invalid input, using: '"+this._selectedAlogrithm+"'"); //This adds an "Error" log to a file and console.
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
                                log.Info(_loginForm._username + " successfully selected encryption FILE as input."); //This adds an "INFO" log to a file and console.
                                break;
                            case InputOption.eText:
                                // check the input length to make sure it is less than the maximum allowed
                                // this is only a requirement for Encryption Text only 
                                if (this._textInput.Length > MAX_ENCRYPTION_LENGTH)
                                {
                                    string errorMsg = string.Format("Only {0} characters is allowed! \nPlease make sure to remove {1} characters and try again.",
                                                    MAX_ENCRYPTION_LENGTH,
                                                    (this._textInput.Length - MAX_ENCRYPTION_LENGTH));
                                    MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    log.Info(_loginForm._username + " successfully selected encryption STRING as input."); //This adds an "INFO" log to a file and console.
                                    this._textOutput = myHelper.Encrypt(this._textInput);
                                    this.txtRichOutput.Text = this._textOutput;
                                }                                
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
                                log.Info(_loginForm._username + " successfully selected decryption FILE as input."); //This adds an "INFO" log to a file and console.
                                break;
                            case InputOption.eText:
                                log.Info(_loginForm._username + " successfully selected decryption STRING as input."); //This adds an "INFO" log to a file and console.
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
                log.Error(_loginForm._username + " failed to complete " + modeStr+" using '"+this._selectedAlogrithm+"'"); //This adds an "ERROR" log to a file and console.
                this.labStatus.Text = errorMsg;

                if (this._userMode == SystemMode.eDecryption && this.cbKeyRequired.Checked == true)
                {
                    errorMsg += "\nMake sure the Key you entered is Correct!";
                }               
                MessageBox.Show(errorMsg, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            else
            {
                log.Info(_loginForm._username + " successfully completed operation: " + modeStr+" using " +
                    this._selectedAlogrithm+" in "+this._stopWatch.ElapsedMilliseconds.ToString()+" Milliseconds!"); //This adds an "INFO" log to a file and console.
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isSignOut == true)
            {
                try
                {
                    _accountManagementForm.Close();
                } catch { }
                return;
            }
            try
            {
                string warnMessage = String.Format("Application is going to be CLOSED!\nPlease make sure all work have been saved!\nClick on OK to Confirm.");
                DialogResult dialogResult = MessageBox.Show(warnMessage, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.OK)
                {
                    e.Cancel = false;
                    _loginForm.Close();
                    _accountManagementForm.Close();
                    Environment.Exit(0);
                }                
                else
                {
                    e.Cancel = true;
                }
            } catch{ }
        }

        private void mainTabCtrl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush textBrush;

            // Get the item from the collection.
            TabPage tabPage = this.mainTabCtrl.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle tabBounds = this.mainTabCtrl.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background color, and don't paint a focus rectangle.
                textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.DarkGray, e.Bounds);
            }
            else
            {
                textBrush = new System.Drawing.SolidBrush(e.ForeColor);
            }

            Font tabFont = new Font(e.Font.FontFamily, 10, FontStyle.Bold, GraphicsUnit.Pixel);


            StringFormat _StringFlags = new StringFormat();
            _StringFlags.Alignment = StringAlignment.Center;
            _StringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(this.mainTabCtrl.TabPages[e.Index].Text, tabFont, textBrush, tabBounds, new StringFormat(_StringFlags));
        }

        private void systemLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(File.Exists(LOG_FILE_PATH) == false)
            {
                MessageBox.Show("Unable to find System Log File!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                log.Info(_loginForm._username + " Unable to find/open System Log.");
                return;
            }

            try
            {
                Process.Start("notepad++.exe", LOG_FILE_PATH);
            }
            catch
            {
                Process.Start(@"notepad.exe", LOG_FILE_PATH);
            }
        }
    }
}
