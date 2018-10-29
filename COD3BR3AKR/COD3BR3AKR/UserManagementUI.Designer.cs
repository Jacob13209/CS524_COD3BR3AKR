namespace COD3BR3AKR
{
    partial class UserManagementUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagementUI));
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.btnMainButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.labUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.labPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.picUserManagement = new System.Windows.Forms.PictureBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.btnViewUser = new System.Windows.Forms.Button();
            this.groupBoxManage = new System.Windows.Forms.GroupBox();
            this.picBoxNewReset = new System.Windows.Forms.PictureBox();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserManagement)).BeginInit();
            this.groupBoxManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxNewReset)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.btnMainButton);
            this.groupBoxMain.Controls.Add(this.label1);
            this.groupBoxMain.Controls.Add(this.txtConfirmPass);
            this.groupBoxMain.Controls.Add(this.labUserName);
            this.groupBoxMain.Controls.Add(this.txtUserName);
            this.groupBoxMain.Controls.Add(this.labPassword);
            this.groupBoxMain.Controls.Add(this.txtPassword);
            this.groupBoxMain.Controls.Add(this.picUserManagement);
            this.groupBoxMain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxMain.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMain.Location = new System.Drawing.Point(30, 24);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(414, 256);
            this.groupBoxMain.TabIndex = 10;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "New User";
            // 
            // btnMainButton
            // 
            this.btnMainButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainButton.Location = new System.Drawing.Point(78, 190);
            this.btnMainButton.Name = "btnMainButton";
            this.btnMainButton.Size = new System.Drawing.Size(278, 35);
            this.btnMainButton.TabIndex = 4;
            this.btnMainButton.Text = "SIGN UP";
            this.btnMainButton.UseVisualStyleBackColor = true;
            this.btnMainButton.Click += new System.EventHandler(this.btnMainButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "CONFIRM PASSWORD:";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPass.Location = new System.Drawing.Point(232, 125);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(153, 26);
            this.txtConfirmPass.TabIndex = 5;
            this.txtConfirmPass.TextChanged += new System.EventHandler(this.txtConfirmPass_TextChanged);
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUserName.Location = new System.Drawing.Point(111, 39);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(105, 19);
            this.labUserName.TabIndex = 0;
            this.labUserName.Text = "USERNAME:";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(232, 36);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(153, 26);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPassword.Location = new System.Drawing.Point(111, 83);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(102, 19);
            this.labPassword.TabIndex = 2;
            this.labPassword.Text = "PASSWORD:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(232, 80);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(153, 26);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // picUserManagement
            // 
            this.picUserManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picUserManagement.Image = ((System.Drawing.Image)(resources.GetObject("picUserManagement.Image")));
            this.picUserManagement.Location = new System.Drawing.Point(3, 18);
            this.picUserManagement.Name = "picUserManagement";
            this.picUserManagement.Size = new System.Drawing.Size(408, 235);
            this.picUserManagement.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUserManagement.TabIndex = 6;
            this.picUserManagement.TabStop = false;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Location = new System.Drawing.Point(38, 37);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(117, 30);
            this.btnAddUser.TabIndex = 11;
            this.btnAddUser.Text = "ADD USER";
            this.btnAddUser.UseVisualStyleBackColor = true;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.Location = new System.Drawing.Point(38, 90);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(117, 30);
            this.btnDeleteUser.TabIndex = 12;
            this.btnDeleteUser.Text = "DELETE USER";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUser.Location = new System.Drawing.Point(38, 144);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(117, 30);
            this.btnUpdateUser.TabIndex = 13;
            this.btnUpdateUser.Text = "UPDATE USER";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            // 
            // btnViewUser
            // 
            this.btnViewUser.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewUser.Location = new System.Drawing.Point(38, 198);
            this.btnViewUser.Name = "btnViewUser";
            this.btnViewUser.Size = new System.Drawing.Size(117, 30);
            this.btnViewUser.TabIndex = 14;
            this.btnViewUser.Text = "ALL USERS";
            this.btnViewUser.UseVisualStyleBackColor = true;
            // 
            // groupBoxManage
            // 
            this.groupBoxManage.Controls.Add(this.picBoxNewReset);
            this.groupBoxManage.Controls.Add(this.btnViewUser);
            this.groupBoxManage.Controls.Add(this.btnAddUser);
            this.groupBoxManage.Controls.Add(this.btnUpdateUser);
            this.groupBoxManage.Controls.Add(this.btnDeleteUser);
            this.groupBoxManage.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxManage.Location = new System.Drawing.Point(469, 24);
            this.groupBoxManage.Name = "groupBoxManage";
            this.groupBoxManage.Size = new System.Drawing.Size(200, 254);
            this.groupBoxManage.TabIndex = 15;
            this.groupBoxManage.TabStop = false;
            this.groupBoxManage.Text = "Management";
            // 
            // picBoxNewReset
            // 
            this.picBoxNewReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxNewReset.Image = ((System.Drawing.Image)(resources.GetObject("picBoxNewReset.Image")));
            this.picBoxNewReset.InitialImage = null;
            this.picBoxNewReset.Location = new System.Drawing.Point(3, 18);
            this.picBoxNewReset.Name = "picBoxNewReset";
            this.picBoxNewReset.Size = new System.Drawing.Size(194, 233);
            this.picBoxNewReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxNewReset.TabIndex = 7;
            this.picBoxNewReset.TabStop = false;
            // 
            // UserManagementUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 334);
            this.Controls.Add(this.groupBoxManage);
            this.Controls.Add(this.groupBoxMain);
            this.Name = "UserManagementUI";
            this.Text = "UserManagement";
            this.Shown += new System.EventHandler(this.UserManagementUI_Shown);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUserManagement)).EndInit();
            this.groupBoxManage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxNewReset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label labPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnMainButton;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Button btnViewUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.GroupBox groupBoxManage;
        private System.Windows.Forms.PictureBox picBoxNewReset;
        private System.Windows.Forms.PictureBox picUserManagement;
    }
}