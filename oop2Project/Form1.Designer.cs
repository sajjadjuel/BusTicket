
namespace oop2Project
{
    partial class Form1
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
            this.email = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btnregistration = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.BackColor = System.Drawing.Color.Transparent;
            this.email.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(325, 108);
            this.email.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(52, 19);
            this.email.TabIndex = 1;
            this.email.Text = "E-mail";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(319, 130);
            this.password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(72, 19);
            this.password.TabIndex = 2;
            this.password.Text = "Password";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(395, 105);
            this.txtusername.Margin = new System.Windows.Forms.Padding(2);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(168, 20);
            this.txtusername.TabIndex = 3;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(395, 129);
            this.txtpassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(168, 20);
            this.txtpassword.TabIndex = 4;
            // 
            // btnlogin
            // 
            this.btnlogin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.Location = new System.Drawing.Point(389, 176);
            this.btnlogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(76, 24);
            this.btnlogin.TabIndex = 5;
            this.btnlogin.Text = "Login";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            this.btnlogin.MouseEnter += new System.EventHandler(this.btnlogin_MouseEnter);
            this.btnlogin.MouseLeave += new System.EventHandler(this.btnlogin_MouseLeave);
            // 
            // btnregistration
            // 
            this.btnregistration.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregistration.Location = new System.Drawing.Point(432, 242);
            this.btnregistration.Margin = new System.Windows.Forms.Padding(2);
            this.btnregistration.Name = "btnregistration";
            this.btnregistration.Size = new System.Drawing.Size(77, 24);
            this.btnregistration.TabIndex = 6;
            this.btnregistration.Text = "Sign up";
            this.btnregistration.UseVisualStyleBackColor = true;
            this.btnregistration.Click += new System.EventHandler(this.btnregistration_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 242);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(407, 226);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Dont have any account ? ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(478, 323);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Contact number ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(447, 344);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "01918888221, 01419092734";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(144, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "Safest Bus Booking Site ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(481, 176);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 24);
            this.button1.TabIndex = 12;
            this.button1.Text = "Forgot Password";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(9, 323);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 32);
            this.button2.TabIndex = 13;
            this.button2.Text = "Exit ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::oop2Project.Properties.Resources.photo_1544620347_c4fd4a3d5957;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnregistration);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.password);
            this.Controls.Add(this.email);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button btnregistration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox txtusername;
    }
}
