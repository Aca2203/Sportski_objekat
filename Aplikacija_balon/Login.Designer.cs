﻿
namespace Aplikacija_balon
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_lozinka = new System.Windows.Forms.TextBox();
            this.dugme_login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имејл:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Лозинка:";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(264, 76);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(208, 22);
            this.txt_email.TabIndex = 2;
            // 
            // txt_lozinka
            // 
            this.txt_lozinka.Location = new System.Drawing.Point(264, 117);
            this.txt_lozinka.Name = "txt_lozinka";
            this.txt_lozinka.Size = new System.Drawing.Size(208, 22);
            this.txt_lozinka.TabIndex = 3;
            // 
            // dugme_login
            // 
            this.dugme_login.Location = new System.Drawing.Point(275, 190);
            this.dugme_login.Name = "dugme_login";
            this.dugme_login.Size = new System.Drawing.Size(94, 41);
            this.dugme_login.TabIndex = 4;
            this.dugme_login.Text = "Uloguj se";
            this.dugme_login.UseVisualStyleBackColor = true;
            this.dugme_login.Click += new System.EventHandler(this.dugme_login_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 281);
            this.Controls.Add(this.dugme_login);
            this.Controls.Add(this.txt_lozinka);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_lozinka;
        private System.Windows.Forms.Button dugme_login;
    }
}

