namespace BusTicketSales.Forms
{
    partial class RegisterForm
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
            lblUsername = new Label();
            lblPassword = new Label();
            lblFullname = new Label();
            lblEmail = new Label();
            lblPhone = new Label();
            label6 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            txtFullname = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            btnRegister = new Button();
            lblErrorMessage = new Label();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 197);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(92, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Kullanici Adi";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 244);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(39, 20);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Sifre";
            // 
            // lblFullname
            // 
            lblFullname.AutoSize = true;
            lblFullname.Location = new Point(12, 59);
            lblFullname.Name = "lblFullname";
            lblFullname.Size = new Size(75, 20);
            lblFullname.TabIndex = 2;
            lblFullname.Text = "Ad-Soyad";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 104);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(12, 154);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(58, 20);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Telefon";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 289);
            label6.Name = "label6";
            label6.Size = new Size(83, 20);
            label6.TabIndex = 5;
            label6.Text = "Sifre Tekrar";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(115, 190);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(125, 27);
            txtUsername.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(115, 237);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 7;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(115, 282);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(125, 27);
            txtConfirmPassword.TabIndex = 8;
            // 
            // txtFullname
            // 
            txtFullname.Location = new Point(115, 52);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(125, 27);
            txtFullname.TabIndex = 9;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(115, 97);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 10;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(115, 147);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 11;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(12, 337);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(228, 29);
            btnRegister.TabIndex = 12;
            btnRegister.Text = "Kayıt Ol";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.AutoSize = true;
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Location = new Point(268, 346);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(0, 20);
            lblErrorMessage.TabIndex = 13;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 413);
            Controls.Add(lblErrorMessage);
            Controls.Add(btnRegister);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtFullname);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label6);
            Controls.Add(lblPhone);
            Controls.Add(lblEmail);
            Controls.Add(lblFullname);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private Label lblPassword;
        private Label lblFullname;
        private Label lblEmail;
        private Label lblPhone;
        private Label label6;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private TextBox txtFullname;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private Button btnRegister;
        public Label lblErrorMessage;
    }
}