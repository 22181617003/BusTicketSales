﻿
namespace BusTicketSales.Forms
{
    partial class AdminForm
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
            components = new System.ComponentModel.Container();
            tabControl = new TabControl();
            tbpTrip = new TabPage();
            gpbTrip = new GroupBox();
            cmbBusID = new ComboBox();
            dgvTrips = new DataGridView();
            tripIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            priceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            busDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tripBindingSource = new BindingSource(components);
            btnUpdateTrip = new Button();
            btnRemoveTrip = new Button();
            btnAddTrip = new Button();
            dtpTripDate = new DateTimePicker();
            txtPrice = new TextBox();
            cmbArrivalBranch = new ComboBox();
            cmbDepartureBranch = new ComboBox();
            tbpUserManagement = new TabPage();
            chkIsAdmin = new CheckBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtFullName = new TextBox();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            btnUpdateUser = new Button();
            btnRemoveUser = new Button();
            btnAddUser = new Button();
            dgvUsers = new DataGridView();
            userIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            userNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            passwordDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ısAdminDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            userBindingSource1 = new BindingSource(components);
            userBindingSource = new BindingSource(components);
            cmbDriverID = new ComboBox();
            tabControl.SuspendLayout();
            tbpTrip.SuspendLayout();
            gpbTrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrips).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tripBindingSource).BeginInit();
            tbpUserManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tbpTrip);
            tabControl.Controls.Add(tbpUserManagement);
            tabControl.Location = new Point(4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1384, 555);
            tabControl.TabIndex = 0;
            // 
            // tbpTrip
            // 
            tbpTrip.Controls.Add(gpbTrip);
            tbpTrip.Location = new Point(4, 29);
            tbpTrip.Name = "tbpTrip";
            tbpTrip.Padding = new Padding(3);
            tbpTrip.Size = new Size(1376, 522);
            tbpTrip.TabIndex = 1;
            tbpTrip.Text = "Sefer Yönetimi";
            tbpTrip.UseVisualStyleBackColor = true;
            // 
            // gpbTrip
            // 
            gpbTrip.Controls.Add(cmbDriverID);
            gpbTrip.Controls.Add(cmbBusID);
            gpbTrip.Controls.Add(dgvTrips);
            gpbTrip.Controls.Add(btnUpdateTrip);
            gpbTrip.Controls.Add(btnRemoveTrip);
            gpbTrip.Controls.Add(btnAddTrip);
            gpbTrip.Controls.Add(dtpTripDate);
            gpbTrip.Controls.Add(txtPrice);
            gpbTrip.Controls.Add(cmbArrivalBranch);
            gpbTrip.Controls.Add(cmbDepartureBranch);
            gpbTrip.Location = new Point(6, 6);
            gpbTrip.Name = "gpbTrip";
            gpbTrip.Size = new Size(1186, 520);
            gpbTrip.TabIndex = 0;
            gpbTrip.TabStop = false;
            gpbTrip.Text = "Sefer Bilgileri";
            // 
            // cmbBusID
            // 
            cmbBusID.FormattingEnabled = true;
            cmbBusID.Location = new Point(807, 47);
            cmbBusID.Name = "cmbBusID";
            cmbBusID.Size = new Size(151, 28);
            cmbBusID.TabIndex = 8;
            cmbBusID.Text = "Bus";
            // 
            // dgvTrips
            // 
            dgvTrips.AutoGenerateColumns = false;
            dgvTrips.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrips.Columns.AddRange(new DataGridViewColumn[] { tripIDDataGridViewTextBoxColumn, dateTimeDataGridViewTextBoxColumn, priceDataGridViewTextBoxColumn, busDataGridViewTextBoxColumn });
            dgvTrips.DataSource = tripBindingSource;
            dgvTrips.Location = new Point(6, 204);
            dgvTrips.Name = "dgvTrips";
            dgvTrips.RowHeadersWidth = 51;
            dgvTrips.Size = new Size(555, 206);
            dgvTrips.TabIndex = 7;
            // 
            // tripIDDataGridViewTextBoxColumn
            // 
            tripIDDataGridViewTextBoxColumn.DataPropertyName = "TripID";
            tripIDDataGridViewTextBoxColumn.HeaderText = "TripID";
            tripIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            tripIDDataGridViewTextBoxColumn.Name = "tripIDDataGridViewTextBoxColumn";
            tripIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateTimeDataGridViewTextBoxColumn
            // 
            dateTimeDataGridViewTextBoxColumn.DataPropertyName = "DateTime";
            dateTimeDataGridViewTextBoxColumn.HeaderText = "DateTime";
            dateTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            dateTimeDataGridViewTextBoxColumn.Name = "dateTimeDataGridViewTextBoxColumn";
            dateTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            priceDataGridViewTextBoxColumn.HeaderText = "Price";
            priceDataGridViewTextBoxColumn.MinimumWidth = 6;
            priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            priceDataGridViewTextBoxColumn.Width = 125;
            // 
            // busDataGridViewTextBoxColumn
            // 
            busDataGridViewTextBoxColumn.DataPropertyName = "Bus";
            busDataGridViewTextBoxColumn.HeaderText = "Bus";
            busDataGridViewTextBoxColumn.MinimumWidth = 6;
            busDataGridViewTextBoxColumn.Name = "busDataGridViewTextBoxColumn";
            busDataGridViewTextBoxColumn.Width = 125;
            // 
            // tripBindingSource
            // 
            tripBindingSource.DataSource = typeof(Entities.Trip);
            // 
            // btnUpdateTrip
            // 
            btnUpdateTrip.Location = new Point(404, 113);
            btnUpdateTrip.Name = "btnUpdateTrip";
            btnUpdateTrip.Size = new Size(94, 29);
            btnUpdateTrip.TabIndex = 6;
            btnUpdateTrip.Text = "Düzenle";
            btnUpdateTrip.UseVisualStyleBackColor = true;
            btnUpdateTrip.Click += btnUpdateTrip_Click;
            // 
            // btnRemoveTrip
            // 
            btnRemoveTrip.Location = new Point(213, 113);
            btnRemoveTrip.Name = "btnRemoveTrip";
            btnRemoveTrip.Size = new Size(94, 29);
            btnRemoveTrip.TabIndex = 5;
            btnRemoveTrip.Text = "Sil";
            btnRemoveTrip.UseVisualStyleBackColor = true;
            btnRemoveTrip.Click += btnRemoveTrip_Click;
            // 
            // btnAddTrip
            // 
            btnAddTrip.Location = new Point(17, 113);
            btnAddTrip.Name = "btnAddTrip";
            btnAddTrip.Size = new Size(94, 29);
            btnAddTrip.TabIndex = 4;
            btnAddTrip.Text = "Ekle";
            btnAddTrip.UseVisualStyleBackColor = true;
            btnAddTrip.Click += btnAddTrip_Click;
            // 
            // dtpTripDate
            // 
            dtpTripDate.Location = new Point(533, 49);
            dtpTripDate.Name = "dtpTripDate";
            dtpTripDate.Size = new Size(250, 27);
            dtpTripDate.TabIndex = 3;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(373, 48);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "Fiyat";
            txtPrice.Size = new Size(125, 27);
            txtPrice.TabIndex = 2;
            // 
            // cmbArrivalBranch
            // 
            cmbArrivalBranch.FormattingEnabled = true;
            cmbArrivalBranch.Location = new Point(189, 48);
            cmbArrivalBranch.Name = "cmbArrivalBranch";
            cmbArrivalBranch.Size = new Size(151, 28);
            cmbArrivalBranch.TabIndex = 1;
            cmbArrivalBranch.Text = "Varış";
            // 
            // cmbDepartureBranch
            // 
            cmbDepartureBranch.FormattingEnabled = true;
            cmbDepartureBranch.Location = new Point(6, 48);
            cmbDepartureBranch.Name = "cmbDepartureBranch";
            cmbDepartureBranch.Size = new Size(151, 28);
            cmbDepartureBranch.TabIndex = 0;
            cmbDepartureBranch.Text = "Kalkış";
            // 
            // tbpUserManagement
            // 
            tbpUserManagement.Controls.Add(chkIsAdmin);
            tbpUserManagement.Controls.Add(txtPhone);
            tbpUserManagement.Controls.Add(txtEmail);
            tbpUserManagement.Controls.Add(txtFullName);
            tbpUserManagement.Controls.Add(txtPassword);
            tbpUserManagement.Controls.Add(txtUserName);
            tbpUserManagement.Controls.Add(btnUpdateUser);
            tbpUserManagement.Controls.Add(btnRemoveUser);
            tbpUserManagement.Controls.Add(btnAddUser);
            tbpUserManagement.Controls.Add(dgvUsers);
            tbpUserManagement.Location = new Point(4, 29);
            tbpUserManagement.Name = "tbpUserManagement";
            tbpUserManagement.Padding = new Padding(3);
            tbpUserManagement.Size = new Size(1376, 522);
            tbpUserManagement.TabIndex = 2;
            tbpUserManagement.Text = "Kullanıcı Yönetimi";
            tbpUserManagement.UseVisualStyleBackColor = true;
            // 
            // chkIsAdmin
            // 
            chkIsAdmin.AutoSize = true;
            chkIsAdmin.Location = new Point(971, 171);
            chkIsAdmin.Name = "chkIsAdmin";
            chkIsAdmin.Size = new Size(75, 24);
            chkIsAdmin.TabIndex = 9;
            chkIsAdmin.Text = "Admin";
            chkIsAdmin.UseVisualStyleBackColor = true;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(971, 138);
            txtPhone.Name = "txtPhone";
            txtPhone.PlaceholderText = "Telefon";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(971, 105);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 7;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(971, 72);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "Ad-Soyad";
            txtFullName.Size = new Size(125, 27);
            txtFullName.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(971, 39);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Şifre";
            txtPassword.Size = new Size(125, 27);
            txtPassword.TabIndex = 5;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(971, 6);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Kullanıcı Adı";
            txtUserName.Size = new Size(125, 27);
            txtUserName.TabIndex = 4;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.Location = new Point(533, 222);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(94, 29);
            btnUpdateUser.TabIndex = 3;
            btnUpdateUser.Text = "Düzenle";
            btnUpdateUser.UseVisualStyleBackColor = true;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // btnRemoveUser
            // 
            btnRemoveUser.Location = new Point(385, 222);
            btnRemoveUser.Name = "btnRemoveUser";
            btnRemoveUser.Size = new Size(94, 29);
            btnRemoveUser.TabIndex = 2;
            btnRemoveUser.Text = "Sil";
            btnRemoveUser.UseVisualStyleBackColor = true;
            btnRemoveUser.Click += btnRemoveUser_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(236, 222);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(94, 29);
            btnAddUser.TabIndex = 1;
            btnAddUser.Text = "Ekle";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { userIDDataGridViewTextBoxColumn, userNameDataGridViewTextBoxColumn, passwordDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, phoneDataGridViewTextBoxColumn, ısAdminDataGridViewCheckBoxColumn });
            dgvUsers.DataSource = userBindingSource1;
            dgvUsers.Location = new Point(6, 6);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(931, 185);
            dgvUsers.TabIndex = 0;
            dgvUsers.SelectionChanged += dgvUsers_SelectedChanged;
            dgvTrips.SelectionChanged += dgvTrips_SelectedChanged;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            userIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            userIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            userNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            userNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            passwordDataGridViewTextBoxColumn.MinimumWidth = 6;
            passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            passwordDataGridViewTextBoxColumn.Width = 125;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            fullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            fullNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            phoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            phoneDataGridViewTextBoxColumn.Width = 125;
            // 
            // ısAdminDataGridViewCheckBoxColumn
            // 
            ısAdminDataGridViewCheckBoxColumn.DataPropertyName = "IsAdmin";
            ısAdminDataGridViewCheckBoxColumn.HeaderText = "IsAdmin";
            ısAdminDataGridViewCheckBoxColumn.MinimumWidth = 6;
            ısAdminDataGridViewCheckBoxColumn.Name = "ısAdminDataGridViewCheckBoxColumn";
            ısAdminDataGridViewCheckBoxColumn.Width = 125;
            // 
            // userBindingSource1
            // 
            userBindingSource1.DataSource = typeof(Entities.User);
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(Entities.User);
            // 
            // cmbDriverID
            // 
            cmbDriverID.FormattingEnabled = true;
            cmbDriverID.Location = new Point(984, 47);
            cmbDriverID.Name = "cmbDriverID";
            cmbDriverID.Size = new Size(151, 28);
            cmbDriverID.TabIndex = 9;
            cmbDriverID.Text = "Driver";
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1199, 460);
            Controls.Add(tabControl);
            Name = "AdminForm";
            Text = "AdminForm";
            tabControl.ResumeLayout(false);
            tbpTrip.ResumeLayout(false);
            gpbTrip.ResumeLayout(false);
            gpbTrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrips).EndInit();
            ((System.ComponentModel.ISupportInitialize)tripBindingSource).EndInit();
            tbpUserManagement.ResumeLayout(false);
            tbpUserManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tbpTrip;
        private TabPage tbpUserManagement;
        private GroupBox gpbTrip;
        private DataGridView dgvTrips;
        private Button btnUpdateTrip;
        private Button btnRemoveTrip;
        private Button btnAddTrip;
        private DateTimePicker dtpTripDate;
        private TextBox txtPrice;
        private ComboBox cmbArrivalBranch;
        private ComboBox cmbDepartureBranch;
        private BindingSource tripBindingSource;
        private Button btnUpdateUser;
        private Button btnRemoveUser;
        private Button btnAddUser;
        private DataGridView dgvUsers;
        private BindingSource userBindingSource;
        private ComboBox cmbBusID;
        private DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn ısAdminDataGridViewCheckBoxColumn;
        private CheckBox chkIsAdmin;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtFullName;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private BindingSource userBindingSource1;
        private DataGridViewTextBoxColumn tripIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn busDataGridViewTextBoxColumn;
        private ComboBox cmbDriverID;
    }
}