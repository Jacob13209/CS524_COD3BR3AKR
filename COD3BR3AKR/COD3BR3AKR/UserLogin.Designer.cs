﻿namespace COD3BR3AKR
{
    partial class UserLogin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linLableForgetPass = new System.Windows.Forms.LinkLabel();
            this.labUserName = new System.Windows.Forms.Label();
            this.linLabelSignUP = new System.Windows.Forms.LinkLabel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.labPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.labError = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.linLableForgetPass);
            this.groupBox1.Controls.Add(this.labUserName);
            this.groupBox1.Controls.Add(this.linLabelSignUP);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.labPassword);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(168, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 243);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(209, 136);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(85, 30);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // linLableForgetPass
            // 
            this.linLableForgetPass.AutoSize = true;
            this.linLableForgetPass.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linLableForgetPass.Location = new System.Drawing.Point(206, 191);
            this.linLableForgetPass.Name = "linLableForgetPass";
            this.linLableForgetPass.Size = new System.Drawing.Size(108, 15);
            this.linLableForgetPass.TabIndex = 7;
            this.linLableForgetPass.TabStop = true;
            this.linLableForgetPass.Text = "Forgot Password?";
            this.linLableForgetPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linLableForgetPass_LinkClicked);
            // 
            // labUserName
            // 
            this.labUserName.AutoSize = true;
            this.labUserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labUserName.Location = new System.Drawing.Point(60, 39);
            this.labUserName.Name = "labUserName";
            this.labUserName.Size = new System.Drawing.Size(105, 19);
            this.labUserName.TabIndex = 0;
            this.labUserName.Text = "USERNAME:";
            // 
            // linLabelSignUP
            // 
            this.linLabelSignUP.AutoSize = true;
            this.linLabelSignUP.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linLabelSignUP.Location = new System.Drawing.Point(61, 191);
            this.linLabelSignUP.Name = "linLabelSignUP";
            this.linLabelSignUP.Size = new System.Drawing.Size(117, 15);
            this.linLabelSignUP.TabIndex = 6;
            this.linLabelSignUP.TabStop = true;
            this.linLabelSignUP.Text = "Sign Up as new user";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(180, 36);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(153, 26);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(75, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "CANCEL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labPassword
            // 
            this.labPassword.AutoSize = true;
            this.labPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPassword.Location = new System.Drawing.Point(60, 82);
            this.labPassword.Name = "labPassword";
            this.labPassword.Size = new System.Drawing.Size(102, 19);
            this.labPassword.TabIndex = 2;
            this.labPassword.Text = "PASSWORD:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(180, 79);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(153, 26);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // labError
            // 
            this.labError.AutoSize = true;
            this.labError.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labError.ForeColor = System.Drawing.Color.Red;
            this.labError.Location = new System.Drawing.Point(217, 47);
            this.labError.Name = "labError";
            this.labError.Size = new System.Drawing.Size(0, 15);
            this.labError.TabIndex = 10;
            this.labError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 363);
            this.Controls.Add(this.labError);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserLogin";
            this.Text = "COD3BR3AKR";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linLableForgetPass;
        private System.Windows.Forms.Label labUserName;
        private System.Windows.Forms.LinkLabel linLabelSignUP;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label labError;
    }
}