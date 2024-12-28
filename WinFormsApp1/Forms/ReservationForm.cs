using BusTicketSales.Entities;
using System.Windows.Forms;

namespace BusTicketSales.Forms;

public partial class ReservationForm : Form
{
    public ReservationForm()
    {
        InitializeComponent();
    }

    private void ReservationForm_Load(object sender, EventArgs e)
    {
        using (var dbContext = new BusDbContext())
        {
            var branches = dbContext.Branches.Select(b => new { b.BranchID, b.BranchName }).ToList();

            cmbDepartureBranch.DataSource = branches;
            cmbDepartureBranch.DisplayMember = "BranchName";
            cmbDepartureBranch.ValueMember = "BranchId";

            cmbArrivalBranch.DataSource = branches.ToList(); // Yeni bir liste olarak set edin
            cmbArrivalBranch.DisplayMember = "BranchName";
            cmbArrivalBranch.ValueMember = "BranchId";
        }
    }

    private void btnSearchTrips_Click(object sender, EventArgs e)
    {
        ComboBox cmbDepartureBranch = (ComboBox)this.Controls["cmbDepartureBranch"];
        ComboBox cmbArrivalBranch = (ComboBox)this.Controls["cmbArrivalBranch"];
        DateTimePicker dtpDate = (DateTimePicker)this.Controls["dtpDate"];
        DataGridView dgvTrips = (DataGridView)this.Controls["dgvTrips"];

        int departureBranchId = (int)cmbDepartureBranch.SelectedValue;
        int arrivalBranchId = (int)cmbArrivalBranch.SelectedValue;
        DateTime selectedDate = dtpDate.Value.Date;

        using (var dbContext = new BusDbContext())
        {
            var trips = dbContext.Trips
                .Where(t => t.DepartureBranchID == departureBranchId &&
                            t.ArrivalBranchID == arrivalBranchId &&
                            t.DateTime.Date == selectedDate)
                .Select(t => new
                {
                    t.TripID,
                    t.DateTime,
                    t.Price,
                    Bus = t.Bus.PlateNumber,
                    Driver = t.Driver.FullName
                })
                .ToList();

            dgvTrips.DataSource = trips;
        }
    }

    private void btnCompleteReservation_Click(object sender, EventArgs e)
    {
        DataGridView dgvTrips = (DataGridView)this.Controls["dgvTrips"];
        ComboBox cmbSeats = (ComboBox)this.Controls["cmbSeats"];
        ComboBox cmbPaymentMethod = (ComboBox)this.Controls["cmbPaymentMethod"];

        if (dgvTrips.SelectedRows.Count == 0 || cmbSeats.SelectedItem == null || cmbPaymentMethod.SelectedItem == null)
        {
            MessageBox.Show("Lütfen tüm seçimleri tamamlayınız.");
            return;
        }
        var userId = LoggedUser.loggedInUser.UserID;
        int tripId = (int)dgvTrips.SelectedRows[0].Cells["TripId"].Value;
        int seatNumber = (int)cmbSeats.SelectedItem;
        decimal price = (decimal)dgvTrips.SelectedRows[0].Cells["Price"].Value;
        string paymentMethod = cmbPaymentMethod.SelectedItem.ToString();

        using (var dbContext = new BusDbContext())
        {
            var reservation = new Reservation
            {
                TripID = tripId,
                UserID = userId,
                SeatNumber = seatNumber,
                ReservationDate = DateTime.Now
            };
            dbContext.Reservations.Add(reservation);
            dbContext.SaveChanges();

            var payment = new Payment
            {
                ReservationID = reservation.ReservationID,
                Amount = (double)price,
                PaymentDate = DateTime.Now,
                PaymentMethod = paymentMethod
            };
            dbContext.Payments.Add(payment);
            dbContext.SaveChanges();

            MessageBox.Show("Rezervasyon tamamlandı!");
        }
    }
}
