namespace COD3BR3AKR
{
    partial class InputHandler
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupFile = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupText = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRichOutput = new System.Windows.Forms.RichTextBox();
            this.txtRichInput = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupFile.SuspendLayout();
            this.groupText.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupFile
            // 
            this.groupFile.Controls.Add(this.btnOpen);
            this.groupFile.Controls.Add(this.textBox2);
            this.groupFile.Controls.Add(this.label6);
            this.groupFile.Controls.Add(this.btnBrowse);
            this.groupFile.Controls.Add(this.txtFileInput);
            this.groupFile.Controls.Add(this.label5);
            this.groupFile.Location = new System.Drawing.Point(6, 184);
            this.groupFile.Name = "groupFile";
            this.groupFile.Size = new System.Drawing.Size(746, 102);
            this.groupFile.TabIndex = 3;
            this.groupFile.TabStop = false;
            this.groupFile.Text = "File Input";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(633, 69);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(85, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(100, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(499, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Output File：";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(633, 31);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(85, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // txtFileInput
            // 
            this.txtFileInput.Location = new System.Drawing.Point(100, 33);
            this.txtFileInput.Name = "txtFileInput";
            this.txtFileInput.ReadOnly = true;
            this.txtFileInput.Size = new System.Drawing.Size(499, 20);
            this.txtFileInput.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Input File：";
            // 
            // groupText
            // 
            this.groupText.Controls.Add(this.button1);
            this.groupText.Controls.Add(this.label8);
            this.groupText.Controls.Add(this.label7);
            this.groupText.Controls.Add(this.txtRichOutput);
            this.groupText.Controls.Add(this.txtRichInput);
            this.groupText.Location = new System.Drawing.Point(6, 3);
            this.groupText.Name = "groupText";
            this.groupText.Size = new System.Drawing.Size(746, 160);
            this.groupText.TabIndex = 2;
            this.groupText.TabStop = false;
            this.groupText.Text = "Text Input";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(390, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Output:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Input:";
            // 
            // txtRichOutput
            // 
            this.txtRichOutput.Location = new System.Drawing.Point(409, 42);
            this.txtRichOutput.Name = "txtRichOutput";
            this.txtRichOutput.Size = new System.Drawing.Size(309, 103);
            this.txtRichOutput.TabIndex = 1;
            this.txtRichOutput.Text = "";
            // 
            // txtRichInput
            // 
            this.txtRichInput.Location = new System.Drawing.Point(24, 42);
            this.txtRichInput.Name = "txtRichInput";
            this.txtRichInput.Size = new System.Drawing.Size(315, 103);
            this.txtRichInput.TabIndex = 0;
            this.txtRichInput.Text = "";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(345, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = ">>>";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // InputHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupFile);
            this.Controls.Add(this.groupText);
            this.Name = "InputHandler";
            this.Size = new System.Drawing.Size(760, 294);
            this.groupFile.ResumeLayout(false);
            this.groupFile.PerformLayout();
            this.groupText.ResumeLayout(false);
            this.groupText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupFile;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txtRichOutput;
        private System.Windows.Forms.RichTextBox txtRichInput;
        private System.Windows.Forms.Button button1;
    }
}
