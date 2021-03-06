﻿namespace COD3BR3AKR
{
    partial class AccountManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountManagement));
            this.tabManagement = new System.Windows.Forms.TabControl();
            this.tabRegistration = new System.Windows.Forms.TabPage();
            this.groupUserRegReset = new System.Windows.Forms.GroupBox();
            this.labUserNameCheck = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.tabReset = new System.Windows.Forms.TabPage();
            this.tabUserManagement = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.info_Status_combo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.info_name_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.info_pass_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.info_ID_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.allUserView = new System.Windows.Forms.DataGridView();
            this.tabManagement.SuspendLayout();
            this.tabRegistration.SuspendLayout();
            this.groupUserRegReset.SuspendLayout();
            this.tabUserManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allUserView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabManagement
            // 
            this.tabManagement.Controls.Add(this.tabRegistration);
            this.tabManagement.Controls.Add(this.tabReset);
            this.tabManagement.Controls.Add(this.tabUserManagement);
            this.tabManagement.Location = new System.Drawing.Point(37, 24);
            this.tabManagement.Name = "tabManagement";
            this.tabManagement.SelectedIndex = 0;
            this.tabManagement.Size = new System.Drawing.Size(527, 353);
            this.tabManagement.TabIndex = 0;
            this.tabManagement.SelectedIndexChanged += new System.EventHandler(this.tabManagement_SelectedIndexChanged);
            this.tabManagement.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabManagement_Selecting);
            // 
            // tabRegistration
            // 
            this.tabRegistration.BackColor = System.Drawing.Color.DarkGray;
            this.tabRegistration.Controls.Add(this.groupUserRegReset);
            this.tabRegistration.Location = new System.Drawing.Point(4, 22);
            this.tabRegistration.Name = "tabRegistration";
            this.tabRegistration.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegistration.Size = new System.Drawing.Size(519, 327);
            this.tabRegistration.TabIndex = 0;
            this.tabRegistration.Text = "User Registration";
            // 
            // groupUserRegReset
            // 
            this.groupUserRegReset.Controls.Add(this.labUserNameCheck);
            this.groupUserRegReset.Controls.Add(this.label3);
            this.groupUserRegReset.Controls.Add(this.btnCancel);
            this.groupUserRegReset.Controls.Add(this.label2);
            this.groupUserRegReset.Controls.Add(this.btnOK);
            this.groupUserRegReset.Controls.Add(this.label1);
            this.groupUserRegReset.Controls.Add(this.txtConfirmPass);
            this.groupUserRegReset.Controls.Add(this.txtUserName);
            this.groupUserRegReset.Controls.Add(this.txtPassword);
            this.groupUserRegReset.Location = new System.Drawing.Point(40, 36);
            this.groupUserRegReset.Name = "groupUserRegReset";
            this.groupUserRegReset.Size = new System.Drawing.Size(431, 261);
            this.groupUserRegReset.TabIndex = 3;
            this.groupUserRegReset.TabStop = false;
            this.groupUserRegReset.Text = "New User";
            // 
            // labUserNameCheck
            // 
            this.labUserNameCheck.AutoSize = true;
            this.labUserNameCheck.Location = new System.Drawing.Point(343, 56);
            this.labUserNameCheck.Name = "labUserNameCheck";
            this.labUserNameCheck.Size = new System.Drawing.Size(0, 13);
            this.labUserNameCheck.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Confirm Password:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(76, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(226, 206);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 40);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Sign Up";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "User Name:";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPass.Location = new System.Drawing.Point(183, 154);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(153, 26);
            this.txtConfirmPass.TabIndex = 8;
            this.txtConfirmPass.TextChanged += new System.EventHandler(this.txtConfirmPass_TextChanged);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(183, 50);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(153, 26);
            this.txtUserName.TabIndex = 6;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtUserName.Enter += new System.EventHandler(this.txtUserName_Enter);
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(183, 99);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(153, 26);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // tabReset
            // 
            this.tabReset.BackColor = System.Drawing.Color.DarkGray;
            this.tabReset.Location = new System.Drawing.Point(4, 22);
            this.tabReset.Name = "tabReset";
            this.tabReset.Padding = new System.Windows.Forms.Padding(3);
            this.tabReset.Size = new System.Drawing.Size(519, 327);
            this.tabReset.TabIndex = 1;
            this.tabReset.Text = "User Reset";
            // 
            // tabUserManagement
            // 
            this.tabUserManagement.BackColor = System.Drawing.Color.DarkGray;
            this.tabUserManagement.Controls.Add(this.pictureBox1);
            this.tabUserManagement.Controls.Add(this.btnAdd);
            this.tabUserManagement.Controls.Add(this.btnDelete);
            this.tabUserManagement.Controls.Add(this.btnUpdate);
            this.tabUserManagement.Controls.Add(this.btnRefresh);
            this.tabUserManagement.Controls.Add(this.groupBox2);
            this.tabUserManagement.Controls.Add(this.groupBox1);
            this.tabUserManagement.Location = new System.Drawing.Point(4, 22);
            this.tabUserManagement.Name = "tabUserManagement";
            this.tabUserManagement.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserManagement.Size = new System.Drawing.Size(519, 327);
            this.tabUserManagement.TabIndex = 2;
            this.tabUserManagement.Text = "User Management";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::COD3BR3AKR.Properties.Resources.userAddReset;
            this.pictureBox1.Location = new System.Drawing.Point(438, 223);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(438, 74);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(438, 177);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(438, 126);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(438, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.info_Status_combo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.info_name_txt);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.info_pass_txt);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.info_ID_txt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(10, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Information";
            // 
            // info_Status_combo
            // 
            this.info_Status_combo.FormattingEnabled = true;
            this.info_Status_combo.Items.AddRange(new object[] {
            "Active",
            "InActive"});
            this.info_Status_combo.Location = new System.Drawing.Point(83, 60);
            this.info_Status_combo.Name = "info_Status_combo";
            this.info_Status_combo.Size = new System.Drawing.Size(100, 21);
            this.info_Status_combo.TabIndex = 7;
            this.info_Status_combo.SelectedIndexChanged += new System.EventHandler(this.info_Status_combo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "User Status:";
            // 
            // info_name_txt
            // 
            this.info_name_txt.Location = new System.Drawing.Point(280, 25);
            this.info_name_txt.Name = "info_name_txt";
            this.info_name_txt.Size = new System.Drawing.Size(100, 20);
            this.info_name_txt.TabIndex = 5;
            this.info_name_txt.TextChanged += new System.EventHandler(this.info_name_txt_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(211, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "User Name:";
            // 
            // info_pass_txt
            // 
            this.info_pass_txt.Location = new System.Drawing.Point(280, 60);
            this.info_pass_txt.Name = "info_pass_txt";
            this.info_pass_txt.Size = new System.Drawing.Size(100, 20);
            this.info_pass_txt.TabIndex = 3;
            this.info_pass_txt.TextChanged += new System.EventHandler(this.info_pass_txt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password:";
            // 
            // info_ID_txt
            // 
            this.info_ID_txt.Location = new System.Drawing.Point(83, 26);
            this.info_ID_txt.Name = "info_ID_txt";
            this.info_ID_txt.ReadOnly = true;
            this.info_ID_txt.Size = new System.Drawing.Size(100, 20);
            this.info_ID_txt.TabIndex = 1;
            this.info_ID_txt.TextChanged += new System.EventHandler(this.info_ID_txt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "User ID: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.allUserView);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 196);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Users";
            // 
            // allUserView
            // 
            this.allUserView.AllowUserToOrderColumns = true;
            this.allUserView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.allUserView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allUserView.Location = new System.Drawing.Point(25, 23);
            this.allUserView.MultiSelect = false;
            this.allUserView.Name = "allUserView";
            this.allUserView.ReadOnly = true;
            this.allUserView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.allUserView.Size = new System.Drawing.Size(365, 159);
            this.allUserView.TabIndex = 0;
            this.allUserView.SelectionChanged += new System.EventHandler(this.allUserView_SelectionChanged);
            // 
            // AccountManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 411);
            this.Controls.Add(this.tabManagement);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AccountManagement";
            this.Text = "COD3BR3AKR - AccountManagement";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccountManagement_FormClosed);
            this.Load += new System.EventHandler(this.AccountManagement_Load);
            this.Shown += new System.EventHandler(this.AccountManagement_Shown);
            this.tabManagement.ResumeLayout(false);
            this.tabRegistration.ResumeLayout(false);
            this.groupUserRegReset.ResumeLayout(false);
            this.groupUserRegReset.PerformLayout();
            this.tabUserManagement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allUserView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabManagement;
        private System.Windows.Forms.TabPage tabRegistration;
        private System.Windows.Forms.TabPage tabReset;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage tabUserManagement;
        private System.Windows.Forms.GroupBox groupUserRegReset;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView allUserView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox info_ID_txt;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox info_name_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox info_pass_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox info_Status_combo;
        private System.Windows.Forms.Label labUserNameCheck;
    }
}