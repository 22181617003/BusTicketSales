using BusTicketSales.Entities;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace BusTicketSales.Forms;

public partial class ReservationForm : Form
{
    public ReservationForm()
    {
        InitializeComponent();
        LoadTrips();
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
        try
        {
            // Gerekli kontrolleri al
            ComboBox cmbDepartureBranch = (ComboBox)this.Controls["cmbDepartureBranch"];
            ComboBox cmbArrivalBranch = (ComboBox)this.Controls["cmbArrivalBranch"];
            DateTimePicker dtpDate = (DateTimePicker)this.Controls["dtpDate"];
            DataGridView dgvTrips = (DataGridView)this.Controls["dgvTrips"];
            int selectedTripId = (int)dgvTrips.SelectedRows[0].Cells["tripIDDataGridViewTextBoxColumn"].Value;
            LoadSeats(selectedTripId);
            LoadPaymentMethods();

            // Seçili değerleri al
            int departureBranchId = (int)cmbDepartureBranch.SelectedValue;
            int arrivalBranchId = (int)cmbArrivalBranch.SelectedValue;
            DateTime selectedDate = dtpDate.Value.ToUniversalTime();

            // Veritabanı işlemleri
            using (var dbContext = new BusDbContext())
            {
                try
                {
                    var trips = dbContext.Trips
                        .Where(t => t.DepartureBranchID == departureBranchId &&
                                    t.ArrivalBranchID == arrivalBranchId &&
                                    t.DateTime.Date == selectedDate.Date)
                        .Select(t => new
                        {
                            t.TripID,
                            t.DateTime,
                            t.Price,
                            Bus = t.Bus.PlateNumber,
                            Driver = t.Driver.FullName
                        })
                        .ToList();

                    // Sonuçları DataGridView'e bağla
                    dgvTrips.DataSource = trips;
                }
                catch (Exception dbEx)
                {
                    MessageBox.Show("Veritabanından veri alınırken bir hata oluştu: " + dbEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        catch (InvalidCastException icEx)
        {
            MessageBox.Show("Kontrollerden birinin seçimi veya dönüşümünde bir hata oluştu: " + icEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (NullReferenceException nrEx)
        {
            MessageBox.Show("Bir kontrol veya veri null olduğu için hata oluştu: " + nrEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCompleteReservation_Click(object sender, EventArgs e)
    {
        try
        {
            // Kontrolleri al
            DataGridView dgvTrips = (DataGridView)this.Controls["dgvTrips"];
            ComboBox cmbSeats = (ComboBox)this.Controls["cmbAvailableSeats"];
            ComboBox cmbPaymentMethod = (ComboBox)this.Controls["cmbPaymentMethod"];
            // Seçili değerleri al
            var userId = LoggedUser.loggedInUser.UserID;
            int tripId = (int)dgvTrips.SelectedRows[0].Cells["tripIDDataGridViewTextBoxColumn"].Value;
            int seatNumber = (int)cmbAvailableSeats.SelectedItem;
            double price = (double)dgvTrips.SelectedRows[0].Cells["priceDataGridViewTextBoxColumn"].Value;
            string paymentMethod = cmbPaymentMethod.SelectedItem.ToString();

            // Veritabanı işlemleri
            using (var dbContext = new BusDbContext())
            {
                try
                {
                    // Rezervasyon ekle
                    var reservation = new Reservation
                    {
                        TripID = tripId,
                        UserID = userId,
                        SeatNumber = seatNumber,
                        ReservationDate = DateTime.UtcNow
                    };
                    dbContext.Reservations.Add(reservation);
                    dbContext.SaveChanges();

                    // Ödeme bilgisi ekle
                    var payment = new Payment
                    {
                        ReservationID = reservation.ReservationID,
                        Amount = (double)price,
                        PaymentDate = DateTime.UtcNow,
                        PaymentMethod = paymentMethod
                    };
                    dbContext.Payments.Add(payment);
                    dbContext.SaveChanges();

                    // İşlem tamamlandığında mesaj göster
                    MessageBox.Show("Rezervasyon tamamlandı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception dbEx)
                {
                    MessageBox.Show("Veritabanı işlemleri sırasında bir hata oluştu: " + dbEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        catch (InvalidCastException icEx)
        {
            MessageBox.Show("Seçimlerde bir dönüşüm hatası oluştu: " + icEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (NullReferenceException nrEx)
        {
            MessageBox.Show("Bir kontrol veya veri null olduğu için hata oluştu: " + nrEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Bilinmeyen bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadTrips()
    {
        using (var dbContext = new BusDbContext())
        {
            var trips = dbContext.Trips
                .Select(t => new
                {
                    t.TripID,
                    t.DateTime,
                    t.Price,
                    Bus = t.Bus.PlateNumber,
                    Driver = t.Driver.FullName
                })
                .ToList();

            dgvTrips.DataSource = trips; // DataGridView'e verileri bağla
        }
    }

    private void LoadSeats(int tripId)
    {
        try
        {
            using (var dbContext = new BusDbContext())
            {
                // Seçilen seferin otobüs bilgisine eriş
                var busCapacity = dbContext.Trips
                    .Where(t => t.TripID == tripId)
                    .Select(t => t.Bus.Capacity)
                    .FirstOrDefault();

                if (busCapacity > 0)
                {
                    // Koltuk numaralarını oluştur
                    var seats = Enumerable.Range(1, busCapacity).ToList();

                    // ComboBox'a bağla
                    ComboBox cmbSeats = (ComboBox)this.Controls["cmbAvailableSeats"];
                    cmbSeats.DataSource = seats;
                }
                else
                {
                    MessageBox.Show("Otobüs kapasitesi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Koltuk yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void LoadPaymentMethods()
    {
        try
        {
            // Sabit ödeme yöntemlerini tanımla
            var paymentMethods = new List<string> { "Kredi Kartı", "Nakit" };

            // ComboBox'a bağla
            ComboBox cmbPaymentMethod = (ComboBox)this.Controls["cmbPaymentMethod"];
            cmbPaymentMethod.DataSource = paymentMethods;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ödeme yöntemleri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}