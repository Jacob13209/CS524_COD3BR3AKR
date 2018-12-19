namespace COD3BR3AKR
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userDocumentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutCOD3BR3AKRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabCtrl = new System.Windows.Forms.TabControl();
            this.tabEncrypt = new System.Windows.Forms.TabPage();
            this.groupFile = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFileOutput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupText = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRichOutput = new System.Windows.Forms.RichTextBox();
            this.txtRichInput = new System.Windows.Forms.RichTextBox();
            this.tabDecrypt = new System.Windows.Forms.TabPage();
            this.groupAlgorithmOptions = new System.Windows.Forms.GroupBox();
            this.btnImportKey = new System.Windows.Forms.Button();
            this.cbKeyRequired = new System.Windows.Forms.CheckBox();
            this.comboAlogrithms = new System.Windows.Forms.ComboBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.labSignOut = new System.Windows.Forms.LinkLabel();
            this.labStatus = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.labDuration = new System.Windows.Forms.Label();
            this.myToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainMenuStrip.SuspendLayout();
            this.mainTabCtrl.SuspendLayout();
            this.tabEncrypt.SuspendLayout();
            this.groupFile.SuspendLayout();
            this.groupText.SuspendLayout();
            this.groupAlgorithmOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.mainMenuStrip.Size = new System.Drawing.Size(1270, 35);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.advancedToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManagementToolStripMenuItem});
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(252, 30);
            this.advancedToolStripMenuItem.Text = "Advanced";
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(241, 30);
            this.userManagementToolStripMenuItem.Text = "User Management";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userDocumentationToolStripMenuItem,
            this.aboutCOD3BR3AKRToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // userDocumentationToolStripMenuItem
            // 
            this.userDocumentationToolStripMenuItem.Name = "userDocumentationToolStripMenuItem";
            this.userDocumentationToolStripMenuItem.Size = new System.Drawing.Size(263, 30);
            this.userDocumentationToolStripMenuItem.Text = "User Documentation";
            // 
            // aboutCOD3BR3AKRToolStripMenuItem
            // 
            this.aboutCOD3BR3AKRToolStripMenuItem.Name = "aboutCOD3BR3AKRToolStripMenuItem";
            this.aboutCOD3BR3AKRToolStripMenuItem.Size = new System.Drawing.Size(263, 30);
            this.aboutCOD3BR3AKRToolStripMenuItem.Text = "About COD3BR3AKR";
            this.aboutCOD3BR3AKRToolStripMenuItem.Click += new System.EventHandler(this.aboutCOD3BR3AKRToolStripMenuItem_Click);
            // 
            // mainTabCtrl
            // 
            this.mainTabCtrl.Controls.Add(this.tabEncrypt);
            this.mainTabCtrl.Controls.Add(this.tabDecrypt);
            this.mainTabCtrl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.mainTabCtrl.Location = new System.Drawing.Point(18, 63);
            this.mainTabCtrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.mainTabCtrl.Name = "mainTabCtrl";
            this.mainTabCtrl.SelectedIndex = 0;
            this.mainTabCtrl.Size = new System.Drawing.Size(1208, 526);
            this.mainTabCtrl.TabIndex = 1;
            this.mainTabCtrl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.mainTabCtrl_DrawItem);
            this.mainTabCtrl.SelectedIndexChanged += new System.EventHandler(this.mainTabCtrl_SelectedIndexChanged);
            // 
            // tabEncrypt
            // 
            this.tabEncrypt.BackColor = System.Drawing.Color.DarkGray;
            this.tabEncrypt.Controls.Add(this.groupFile);
            this.tabEncrypt.Controls.Add(this.groupText);
            this.tabEncrypt.Location = new System.Drawing.Point(4, 29);
            this.tabEncrypt.Margin = new System.Windows.Forms.Padding(0);
            this.tabEncrypt.Name = "tabEncrypt";
            this.tabEncrypt.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabEncrypt.Size = new System.Drawing.Size(1200, 493);
            this.tabEncrypt.TabIndex = 1;
            this.tabEncrypt.Text = "Encryption";
            // 
            // groupFile
            // 
            this.groupFile.Controls.Add(this.btnOpen);
            this.groupFile.Controls.Add(this.txtFileOutput);
            this.groupFile.Controls.Add(this.label6);
            this.groupFile.Controls.Add(this.btnBrowse);
            this.groupFile.Controls.Add(this.txtFileInput);
            this.groupFile.Controls.Add(this.label5);
            this.groupFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupFile.Location = new System.Drawing.Point(32, 302);
            this.groupFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupFile.Name = "groupFile";
            this.groupFile.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupFile.Size = new System.Drawing.Size(1119, 157);
            this.groupFile.TabIndex = 1;
            this.groupFile.TabStop = false;
            this.groupFile.Text = "FILE INPUT";
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(950, 106);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(128, 35);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Browse";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFileOutput
            // 
            this.txtFileOutput.Location = new System.Drawing.Point(150, 109);
            this.txtFileOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFileOutput.Name = "txtFileOutput";
            this.txtFileOutput.ReadOnly = true;
            this.txtFileOutput.Size = new System.Drawing.Size(746, 26);
            this.txtFileOutput.TabIndex = 4;
            this.txtFileOutput.TextChanged += new System.EventHandler(this.txtFileOutput_TextChanged);
            this.txtFileOutput.MouseHover += new System.EventHandler(this.txtFileOutput_MouseHover);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Output File：";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(950, 48);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(128, 35);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFileInput
            // 
            this.txtFileInput.Location = new System.Drawing.Point(150, 51);
            this.txtFileInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFileInput.Name = "txtFileInput";
            this.txtFileInput.ReadOnly = true;
            this.txtFileInput.Size = new System.Drawing.Size(746, 26);
            this.txtFileInput.TabIndex = 1;
            this.txtFileInput.TextChanged += new System.EventHandler(this.txtFileInput_TextChanged);
            this.txtFileInput.MouseHover += new System.EventHandler(this.txtFileInput_MouseHover);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Input File：";
            // 
            // groupText
            // 
            this.groupText.Controls.Add(this.label8);
            this.groupText.Controls.Add(this.label7);
            this.groupText.Controls.Add(this.txtRichOutput);
            this.groupText.Controls.Add(this.txtRichInput);
            this.groupText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupText.Location = new System.Drawing.Point(32, 23);
            this.groupText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupText.Name = "groupText";
            this.groupText.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupText.Size = new System.Drawing.Size(1119, 246);
            this.groupText.TabIndex = 0;
            this.groupText.TabStop = false;
            this.groupText.Text = "TEXT INPUT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(585, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Output";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Input";
            // 
            // txtRichOutput
            // 
            this.txtRichOutput.Location = new System.Drawing.Point(614, 65);
            this.txtRichOutput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRichOutput.Name = "txtRichOutput";
            this.txtRichOutput.ReadOnly = true;
            this.txtRichOutput.Size = new System.Drawing.Size(462, 156);
            this.txtRichOutput.TabIndex = 1;
            this.txtRichOutput.Text = "";
            // 
            // txtRichInput
            // 
            this.txtRichInput.Location = new System.Drawing.Point(36, 65);
            this.txtRichInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRichInput.Name = "txtRichInput";
            this.txtRichInput.Size = new System.Drawing.Size(470, 156);
            this.txtRichInput.TabIndex = 0;
            this.txtRichInput.Text = "";
            this.txtRichInput.TextChanged += new System.EventHandler(this.txtRichInput_TextChanged);
            this.txtRichInput.Enter += new System.EventHandler(this.txtRichInput_Enter);
            this.txtRichInput.Leave += new System.EventHandler(this.txtRichInput_Leave);
            // 
            // tabDecrypt
            // 
            this.tabDecrypt.BackColor = System.Drawing.Color.DarkGray;
            this.tabDecrypt.Location = new System.Drawing.Point(4, 29);
            this.tabDecrypt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDecrypt.Name = "tabDecrypt";
            this.tabDecrypt.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDecrypt.Size = new System.Drawing.Size(1200, 493);
            this.tabDecrypt.TabIndex = 2;
            this.tabDecrypt.Text = "Decryption";
            // 
            // groupAlgorithmOptions
            // 
            this.groupAlgorithmOptions.BackColor = System.Drawing.SystemColors.Control;
            this.groupAlgorithmOptions.Controls.Add(this.btnImportKey);
            this.groupAlgorithmOptions.Controls.Add(this.cbKeyRequired);
            this.groupAlgorithmOptions.Controls.Add(this.comboAlogrithms);
            this.groupAlgorithmOptions.Controls.Add(this.txtKey);
            this.groupAlgorithmOptions.Controls.Add(this.label2);
            this.groupAlgorithmOptions.Controls.Add(this.label1);
            this.groupAlgorithmOptions.Location = new System.Drawing.Point(24, 612);
            this.groupAlgorithmOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupAlgorithmOptions.Name = "groupAlgorithmOptions";
            this.groupAlgorithmOptions.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupAlgorithmOptions.Size = new System.Drawing.Size(1196, 125);
            this.groupAlgorithmOptions.TabIndex = 2;
            this.groupAlgorithmOptions.TabStop = false;
            this.groupAlgorithmOptions.Text = "ALGORITHM OPTIONS";
            // 
            // btnImportKey
            // 
            this.btnImportKey.Location = new System.Drawing.Point(1060, 55);
            this.btnImportKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImportKey.Name = "btnImportKey";
            this.btnImportKey.Size = new System.Drawing.Size(128, 35);
            this.btnImportKey.TabIndex = 6;
            this.btnImportKey.Text = "Import Key";
            this.btnImportKey.UseVisualStyleBackColor = true;
            this.btnImportKey.Click += new System.EventHandler(this.btnImportKey_Click);
            // 
            // cbKeyRequired
            // 
            this.cbKeyRequired.AutoCheck = false;
            this.cbKeyRequired.AutoSize = true;
            this.cbKeyRequired.Location = new System.Drawing.Point(538, 65);
            this.cbKeyRequired.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbKeyRequired.Name = "cbKeyRequired";
            this.cbKeyRequired.Size = new System.Drawing.Size(130, 24);
            this.cbKeyRequired.TabIndex = 4;
            this.cbKeyRequired.Text = "Key Required";
            this.cbKeyRequired.UseVisualStyleBackColor = true;
            // 
            // comboAlogrithms
            // 
            this.comboAlogrithms.FormattingEnabled = true;
            this.comboAlogrithms.Location = new System.Drawing.Point(207, 58);
            this.comboAlogrithms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboAlogrithms.Name = "comboAlogrithms";
            this.comboAlogrithms.Size = new System.Drawing.Size(284, 28);
            this.comboAlogrithms.TabIndex = 3;
            this.comboAlogrithms.SelectedIndexChanged += new System.EventHandler(this.comboAlogrithms_SelectedIndexChanged);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(830, 58);
            this.txtKey.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(223, 26);
            this.txtKey.TabIndex = 2;
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            this.txtKey.MouseHover += new System.EventHandler(this.txtKey_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(708, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Custom Key:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alogrithm Selection: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 768);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Status: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 809);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Duration:";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(888, 780);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 49);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1062, 780);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 49);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labSignOut
            // 
            this.labSignOut.AutoSize = true;
            this.labSignOut.Location = new System.Drawing.Point(1170, 9);
            this.labSignOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labSignOut.Name = "labSignOut";
            this.labSignOut.Size = new System.Drawing.Size(71, 20);
            this.labSignOut.TabIndex = 9;
            this.labSignOut.TabStop = true;
            this.labSignOut.Text = "Sign Out";
            this.labSignOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labSignOut_LinkClicked);
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labStatus.ForeColor = System.Drawing.Color.Teal;
            this.labStatus.Location = new System.Drawing.Point(102, 766);
            this.labStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(61, 20);
            this.labStatus.TabIndex = 10;
            this.labStatus.Text = "Ready";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(705, 780);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(112, 49);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // labDuration
            // 
            this.labDuration.AutoSize = true;
            this.labDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDuration.ForeColor = System.Drawing.Color.Teal;
            this.labDuration.Location = new System.Drawing.Point(104, 809);
            this.labDuration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labDuration.Name = "labDuration";
            this.labDuration.Size = new System.Drawing.Size(0, 20);
            this.labDuration.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1270, 856);
            this.Controls.Add(this.labDuration);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.labStatus);
            this.Controls.Add(this.labSignOut);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupAlgorithmOptions);
            this.Controls.Add(this.mainTabCtrl);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "COD3BR3AKR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainTabCtrl.ResumeLayout(false);
            this.tabEncrypt.ResumeLayout(false);
            this.groupFile.ResumeLayout(false);
            this.groupFile.PerformLayout();
            this.groupText.ResumeLayout(false);
            this.groupText.PerformLayout();
            this.groupAlgorithmOptions.ResumeLayout(false);
            this.groupAlgorithmOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userDocumentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutCOD3BR3AKRToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabCtrl;
        private System.Windows.Forms.TabPage tabEncrypt;
        private System.Windows.Forms.TabPage tabDecrypt;
        private System.Windows.Forms.GroupBox groupFile;
        private System.Windows.Forms.GroupBox groupText;
        private System.Windows.Forms.GroupBox groupAlgorithmOptions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbKeyRequired;
        private System.Windows.Forms.ComboBox comboAlogrithms;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.LinkLabel labSignOut;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFileInput;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFileOutput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtRichOutput;
        private System.Windows.Forms.RichTextBox txtRichInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label labDuration;
        private System.Windows.Forms.Button btnImportKey;
        private System.Windows.Forms.ToolTip myToolTip;
    }
}