namespace BusTicketSales
{
    partial class LoginForm
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
            btnLogin = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            lblUserName = new Label();
            lblPassword = new Label();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(34, 181);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(123, 40);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Giriş Yap";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(34, 40);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(265, 27);
            txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(34, 123);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(265, 27);
            txtPassword.TabIndex = 2;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(34, 17);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(92, 20);
            lblUserName.TabIndex = 3;
            lblUserName.Text = "Kullanıcı Adı";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(34, 100);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(39, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Şifre";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(177, 181);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(122, 40);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Kayıt Ol";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += this.btnRegister_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 358);
            Controls.Add(btnRegister);
            Controls.Add(lblPassword);
            Controls.Add(lblUserName);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(btnLogin);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label lblUserName;
        private Label lblPassword;
        private Button btnRegister;
    }
}