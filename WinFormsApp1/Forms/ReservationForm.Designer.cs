namespace BusTicketSales.Forms
{
    partial class ReservationForm
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
            dgvTrips = new DataGridView();
            tripIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            priceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            busDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            driverDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            departureBranchDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            arrivalBranchDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            reservationsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tripBindingSource = new BindingSource(components);
            lblDeparture = new Label();
            lblArrival = new Label();
            lblDate = new Label();
            cmbDepartureBranch = new ComboBox();
            cmbArrivalBranch = new ComboBox();
            dtpDate = new DateTimePicker();
            btnSearchTrips = new Button();
            lblAvailableSeats = new Label();
            cmbAvailableSeats = new ComboBox();
            lblPayment = new Label();
            cmbPaymentMethod = new ComboBox();
            btnCompleteReservation = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTrips).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tripBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvTrips
            // 
            dgvTrips.AutoGenerateColumns = false;
            dgvTrips.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrips.Columns.AddRange(new DataGridViewColumn[] { tripIDDataGridViewTextBoxColumn, dateTimeDataGridViewTextBoxColumn, priceDataGridViewTextBoxColumn, busDataGridViewTextBoxColumn, driverDataGridViewTextBoxColumn, departureBranchDataGridViewTextBoxColumn, arrivalBranchDataGridViewTextBoxColumn, reservationsDataGridViewTextBoxColumn });
            dgvTrips.DataSource = tripBindingSource;
            dgvTrips.Location = new Point(12, 66);
            dgvTrips.Name = "dgvTrips";
            dgvTrips.RowHeadersWidth = 51;
            dgvTrips.Size = new Size(1054, 275);
            dgvTrips.TabIndex = 0;
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
            // driverDataGridViewTextBoxColumn
            // 
            driverDataGridViewTextBoxColumn.DataPropertyName = "Driver";
            driverDataGridViewTextBoxColumn.HeaderText = "Driver";
            driverDataGridViewTextBoxColumn.MinimumWidth = 6;
            driverDataGridViewTextBoxColumn.Name = "driverDataGridViewTextBoxColumn";
            driverDataGridViewTextBoxColumn.Width = 125;
            // 
            // departureBranchDataGridViewTextBoxColumn
            // 
            departureBranchDataGridViewTextBoxColumn.DataPropertyName = "DepartureBranch";
            departureBranchDataGridViewTextBoxColumn.HeaderText = "DepartureBranch";
            departureBranchDataGridViewTextBoxColumn.MinimumWidth = 6;
            departureBranchDataGridViewTextBoxColumn.Name = "departureBranchDataGridViewTextBoxColumn";
            departureBranchDataGridViewTextBoxColumn.Width = 125;
            // 
            // arrivalBranchDataGridViewTextBoxColumn
            // 
            arrivalBranchDataGridViewTextBoxColumn.DataPropertyName = "ArrivalBranch";
            arrivalBranchDataGridViewTextBoxColumn.HeaderText = "ArrivalBranch";
            arrivalBranchDataGridViewTextBoxColumn.MinimumWidth = 6;
            arrivalBranchDataGridViewTextBoxColumn.Name = "arrivalBranchDataGridViewTextBoxColumn";
            arrivalBranchDataGridViewTextBoxColumn.Width = 125;
            // 
            // reservationsDataGridViewTextBoxColumn
            // 
            reservationsDataGridViewTextBoxColumn.DataPropertyName = "Reservations";
            reservationsDataGridViewTextBoxColumn.HeaderText = "Reservations";
            reservationsDataGridViewTextBoxColumn.MinimumWidth = 6;
            reservationsDataGridViewTextBoxColumn.Name = "reservationsDataGridViewTextBoxColumn";
            reservationsDataGridViewTextBoxColumn.Width = 125;
            // 
            // tripBindingSource
            // 
            tripBindingSource.DataSource = typeof(Entities.Trip);
            // 
            // lblDeparture
            // 
            lblDeparture.AutoSize = true;
            lblDeparture.Location = new Point(12, 9);
            lblDeparture.Name = "lblDeparture";
            lblDeparture.Size = new Size(75, 20);
            lblDeparture.TabIndex = 1;
            lblDeparture.Text = "Kalkış Yeri";
            // 
            // lblArrival
            // 
            lblArrival.AutoSize = true;
            lblArrival.Location = new Point(182, 9);
            lblArrival.Name = "lblArrival";
            lblArrival.Size = new Size(68, 20);
            lblArrival.TabIndex = 2;
            lblArrival.Text = "Varış Yeri";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(340, 9);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(40, 20);
            lblDate.TabIndex = 3;
            lblDate.Text = "Tarih";
            // 
            // cmbDepartureBranch
            // 
            cmbDepartureBranch.FormattingEnabled = true;
            cmbDepartureBranch.Location = new Point(12, 32);
            cmbDepartureBranch.Name = "cmbDepartureBranch";
            cmbDepartureBranch.Size = new Size(151, 28);
            cmbDepartureBranch.TabIndex = 4;
            // 
            // cmbArrivalBranch
            // 
            cmbArrivalBranch.FormattingEnabled = true;
            cmbArrivalBranch.Location = new Point(182, 32);
            cmbArrivalBranch.Name = "cmbArrivalBranch";
            cmbArrivalBranch.Size = new Size(151, 28);
            cmbArrivalBranch.TabIndex = 5;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(339, 33);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(250, 27);
            dtpDate.TabIndex = 6;
            // 
            // btnSearchTrips
            // 
            btnSearchTrips.Location = new Point(607, 31);
            btnSearchTrips.Name = "btnSearchTrips";
            btnSearchTrips.Size = new Size(134, 29);
            btnSearchTrips.TabIndex = 7;
            btnSearchTrips.Text = "Sefer Ara";
            btnSearchTrips.UseVisualStyleBackColor = true;
            btnSearchTrips.Click += btnSearchTrips_Click;
            // 
            // lblAvailableSeats
            // 
            lblAvailableSeats.AutoSize = true;
            lblAvailableSeats.Location = new Point(1093, 66);
            lblAvailableSeats.Name = "lblAvailableSeats";
            lblAvailableSeats.Size = new Size(120, 20);
            lblAvailableSeats.TabIndex = 8;
            lblAvailableSeats.Text = "Mevcut Koltuklar";
            // 
            // cmbAvailableSeats
            // 
            cmbAvailableSeats.FormattingEnabled = true;
            cmbAvailableSeats.Location = new Point(1093, 89);
            cmbAvailableSeats.Name = "cmbAvailableSeats";
            cmbAvailableSeats.Size = new Size(151, 28);
            cmbAvailableSeats.TabIndex = 9;
            // 
            // lblPayment
            // 
            lblPayment.AutoSize = true;
            lblPayment.Location = new Point(1093, 212);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(116, 20);
            lblPayment.TabIndex = 10;
            lblPayment.Text = "Ödeme Yöntemi";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Location = new Point(1093, 235);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(151, 28);
            cmbPaymentMethod.TabIndex = 11;
            // 
            // btnCompleteReservation
            // 
            btnCompleteReservation.Location = new Point(1093, 308);
            btnCompleteReservation.Name = "btnCompleteReservation";
            btnCompleteReservation.Size = new Size(151, 29);
            btnCompleteReservation.TabIndex = 12;
            btnCompleteReservation.Text = "Ödemeyi Tamamla";
            btnCompleteReservation.UseVisualStyleBackColor = true;
            btnCompleteReservation.Click += btnCompleteReservation_Click;
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 368);
            Controls.Add(btnCompleteReservation);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(lblPayment);
            Controls.Add(cmbAvailableSeats);
            Controls.Add(lblAvailableSeats);
            Controls.Add(btnSearchTrips);
            Controls.Add(dtpDate);
            Controls.Add(cmbArrivalBranch);
            Controls.Add(cmbDepartureBranch);
            Controls.Add(lblDate);
            Controls.Add(lblArrival);
            Controls.Add(lblDeparture);
            Controls.Add(dgvTrips);
            Name = "ReservationForm";
            Text = "ReservationForm";
            Load += ReservationForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTrips).EndInit();
            ((System.ComponentModel.ISupportInitialize)tripBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTrips;
        private DataGridViewTextBoxColumn tripIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn busDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn driverDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn departureBranchDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn arrivalBranchDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn reservationsDataGridViewTextBoxColumn;
        private BindingSource tripBindingSource;
        private Label lblDeparture;
        private Label lblArrival;
        private Label lblDate;
        private ComboBox cmbDepartureBranch;
        private ComboBox cmbArrivalBranch;
        private DateTimePicker dtpDate;
        private Button btnSearchTrips;
        private Label lblAvailableSeats;
        private ComboBox cmbAvailableSeats;
        private Label lblPayment;
        private ComboBox cmbPaymentMethod;
        private Button btnCompleteReservation;
    }
}