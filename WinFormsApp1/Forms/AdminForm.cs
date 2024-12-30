using BusTicketSales.Entities;
using System.Data.Entity;

namespace BusTicketSales.Forms;

public partial class AdminForm : Form
{
    public AdminForm()
    {
        InitializeComponent();
        LoadUsers();
        LoadTrips();
        LoadBranches();
        LoadDrivers();
        LoadBuses();
    }

    private void AdminForm_Load(object sender, EventArgs e)
    {
        try
        {
            LoadBranches();
            LoadDrivers();
            LoadBuses();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnAddTrip_Click(object sender, EventArgs e)
    {
        // Gerekli alanların doldurulup doldurulmadığını kontrol et
        if (cmbDepartureBranch.SelectedItem == null || cmbArrivalBranch.SelectedItem == null ||
            cmbBus.SelectedItem == null || cmbDriver.SelectedItem == null || string.IsNullOrWhiteSpace(txtPrice.Text))
        {
            MessageBox.Show("Lütfen tüm alanları doldurun.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Fiyatın geçerli bir sayı olup olmadığını kontrol et
        if (!double.TryParse(txtPrice.Text, out double price))
        {
            MessageBox.Show("Geçerli bir fiyat girin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Veritabanına trip ekle
        try
        {
            using (var dbContext = new BusDbContext())
            {
                // Kalkış ve varış şubelerini al
                string departureBranchName = cmbDepartureBranch.SelectedItem.ToString();
                string arrivalBranchName = cmbArrivalBranch.SelectedItem.ToString();

                var departureBranch = dbContext.Branches.FirstOrDefault(b => b.BranchName == departureBranchName);
                var arrivalBranch = dbContext.Branches.FirstOrDefault(b => b.BranchName == arrivalBranchName);

                if (departureBranch == null || arrivalBranch == null)
                {
                    MessageBox.Show("Kalkış veya varış şubesi bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Otobüs ve şoförü al
                string busName = cmbBus.SelectedItem.ToString();
                string driverName = cmbDriver.SelectedItem.ToString();

                var bus = dbContext.Buses.FirstOrDefault(b => b.Model == busName);
                var driver = dbContext.Drivers.FirstOrDefault(d => d.FullName == driverName);

                if (bus == null)
                {
                    MessageBox.Show("Seçilen otobüs bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (driver == null)
                {
                    MessageBox.Show("Seçilen şoför bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Sefer nesnesini oluştur
                var trip = new Trip
                {
                    DepartureBranchID = departureBranch.BranchID,
                    ArrivalBranchID = arrivalBranch.BranchID,
                    DateTime = dtpTripDate.Value.ToUniversalTime(),
                    Price = price,
                    BusID = bus.BusID,
                    DriverID = driver.DriverID
                };

                dbContext.Trips.Add(trip);
                dbContext.SaveChanges();

                MessageBox.Show("Sefer başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sefer listesini güncelle
                LoadTrips(); // Grid'i güncellemek için
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnUpdateTrip_Click(object sender, EventArgs e)
    {
        try
        {
            // Seçili bir satır olup olmadığını kontrol et
            if (dgvTrips.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz bir seferi seçin.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen satırdaki TripID'yi al
            int tripId = Convert.ToInt32(dgvTrips.SelectedRows[0].Cells["tripIDDataGridViewTextBoxColumn"].Value);

            using (var dbContext = new BusDbContext())
            {
                // Veritabanından seferi bul
                var trip = dbContext.Trips.FirstOrDefault(t => t.TripID == tripId);

                if (trip == null)
                {
                    MessageBox.Show("Seçilen sefer bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // DepartureBranchID ve ArrivalBranchID'yi almak için SelectedValue kullanılıyor
                int departureBranchId = (int)cmbDepartureBranch.SelectedValue;
                int arrivalBranchId = (int)cmbArrivalBranch.SelectedValue;

                // Branch veritabanından alınan ID'lere göre Branch bilgileri alınıyor
                var departureBranch = dbContext.Branches.FirstOrDefault(b => b.BranchID == departureBranchId);
                var arrivalBranch = dbContext.Branches.FirstOrDefault(b => b.BranchID == arrivalBranchId);

                int selectedBusId = (int)cmbBus.SelectedValue;
                var bus = dbContext.Buses.FirstOrDefault(b => b.BusID == selectedBusId);
                if (bus == null)
                {
                    MessageBox.Show("Seçilen otobüs bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Driver tablosundan şoför ID'sini bul
                int selectedDriverId = (int)cmbDriver.SelectedValue;
                var driver = dbContext.Drivers.FirstOrDefault(d => d.DriverID == selectedDriverId);
                if (driver == null)
                {
                    MessageBox.Show("Seçilen şoför bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Sefer bilgilerini güncelle
                trip.DepartureBranchID = departureBranch.BranchID;
                trip.ArrivalBranchID = arrivalBranch.BranchID;
                trip.DateTime = dtpTripDate.Value.ToUniversalTime();
                trip.Price = double.Parse(txtPrice.Text);
                trip.BusID = bus.BusID;
                trip.DriverID = driver.DriverID;

                dbContext.SaveChanges();

                MessageBox.Show("Sefer başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sefer listesini güncelle
                LoadTrips();
            }
        }
        catch (Exception ex)
        {
            // Hataları yakala ve kullanıcıya bildir
            MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRemoveTrip_Click(object sender, EventArgs e)
    {
        try
        {
            // Seçili bir satır olup olmadığını kontrol et
            if (dgvTrips.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir seferi seçin.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen satırdaki TripID'yi al
            int tripId = Convert.ToInt32(dgvTrips.SelectedRows[0].Cells["tripIDDataGridViewTextBoxColumn"].Value);

            using (var dbContext = new BusDbContext())
            {
                // Veritabanından seferi bul
                var trip = dbContext.Trips.FirstOrDefault(t => t.TripID == tripId);

                if (trip == null)
                {
                    MessageBox.Show("Seçilen sefer bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Silme işlemi öncesi bağlı olan verilerin kontrolü yapılabilir (isteğe bağlı)
                var reservations = dbContext.Reservations.Where(r => r.TripID == tripId).ToList();
                var feedbacks = dbContext.Feedbacks.Where(f => f.TripID == tripId).ToList();

                if (reservations.Any() || feedbacks.Any())
                {
                    // Eğer sefer ile ilişkili rezervasyon veya geri bildirim varsa, kullanıcıya bildirim yapılır
                    DialogResult result = MessageBox.Show("Bu sefer ile ilişkili rezervasyonlar veya geri bildirimler bulunuyor. Yine de silmek istediğinizden emin misiniz?",
                                                          "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        return; // Silme işlemi iptal edilir
                    }
                }

                // Seferi veritabanından kaldır
                dbContext.Trips.Remove(trip);
                dbContext.SaveChanges();

                MessageBox.Show("Sefer başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sefer listesini güncelle
                LoadTrips();
            }
        }
        catch (Exception ex)
        {
            // Hataları yakala ve kullanıcıya bildir
            MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadTrips()
    {
        using (var dbContext = new BusDbContext())
        {
            // Tüm seferleri veri tabanından çekiyoruz
            var trips = (from trip in dbContext.Trips
                         join departureBranch in dbContext.Branches on trip.DepartureBranchID equals departureBranch.BranchID
                         join arrivalBranch in dbContext.Branches on trip.ArrivalBranchID equals arrivalBranch.BranchID
                         join bus in dbContext.Buses on trip.BusID equals bus.BusID
                         select new
                         {
                             TripID = trip.TripID,
                             DepartureBranch = departureBranch.BranchName,
                             ArrivalBranch = arrivalBranch.BranchName,
                             DateTime = trip.DateTime,
                             Price = trip.Price,
                             Bus = bus.Model,
                         }).ToList();

            // DataGridView'e veri atama
            dgvTrips.DataSource = trips;
        }
    }

    private void btnAddUser_Click(object sender, EventArgs e)
    {
        try
        {
            using (var dbContext = new BusDbContext())
            {
                // Yeni kullanıcı nesnesi oluştur
                var user = new User
                {
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    FullName = txtFullName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    IsAdmin = chkIsAdmin.Checked
                };

                // Kullanıcı doğrulama işlemi (örneğin, eksik alan kontrolü)
                if (string.IsNullOrWhiteSpace(user.UserName) ||
                    string.IsNullOrWhiteSpace(user.Password) ||
                    string.IsNullOrWhiteSpace(user.Email))
                {
                    MessageBox.Show("Kullanıcı adı, şifre ve e-posta alanları zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kullanıcıyı veritabanına ekle
                dbContext.Users.Add(user);
                dbContext.SaveChanges();

                MessageBox.Show("Kullanıcı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kullanıcı listesini güncelle
                LoadUsers();
            }
        }
        catch (Exception ex)
        {
            // Hataları yakala ve kullanıcıya bildir
            MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnUpdateUser_Click(object sender, EventArgs e)
    {
        try
        {
            // Seçili bir satır olup olmadığını kontrol et
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz bir kullanıcıyı seçin.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen satırdaki UserID'yi al
            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["userIDDataGridViewTextBoxColumn"].Value);

            using (var dbContext = new BusDbContext())
            {
                // Veritabanından kullanıcıyı bul
                var user = dbContext.Users.FirstOrDefault(u => u.UserID == userId);

                if (user == null)
                {
                    MessageBox.Show("Seçilen kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kullanıcı bilgilerini form elemanlarına yerleştir
                txtUserName.Text = user.UserName;
                txtPassword.Text = user.Password;
                txtFullName.Text = user.FullName;
                txtEmail.Text = user.Email;
                txtPhone.Text = user.Phone;
                chkIsAdmin.Checked = user.IsAdmin;

                // Kullanıcıyı düzenleme işlemi yapmak için formu göster
                if (MessageBox.Show("Kullanıcı bilgileri güncellenecek. Devam etmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dbContext.Users.Update(user);
                    dbContext.SaveChanges();

                    MessageBox.Show("Kullanıcı başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Kullanıcı listesini güncelle
                    LoadUsers();
                }
            }
        }
        catch (Exception ex)
        {
            // Hataları yakala ve kullanıcıya bildir
            MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRemoveUser_Click(object sender, EventArgs e)
    {
        try
        {
            // Seçili bir satır olup olmadığını kontrol et
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir kullanıcıyı seçin.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen satırdaki UserID'yi al
            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["userIDDataGridViewTextBoxColumn"].Value);

            using (var dbContext = new BusDbContext())
            {
                // Veritabanından kullanıcıyı bul
                var user = dbContext.Users.FirstOrDefault(u => u.UserID == userId);

                if (user == null)
                {
                    MessageBox.Show("Seçilen kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kullanıcıyı veritabanından kaldır
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();

                MessageBox.Show("Kullanıcı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kullanıcı listesini güncelle
                LoadUsers();
            }
        }
        catch (Exception ex)
        {
            // Hataları yakala ve kullanıcıya bildir
            MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadUsers()
    {
        using (var dbContext = new BusDbContext())
        {
            var users = dbContext.Users.Select(u => new
            {
                u.UserID,
                u.UserName,
                u.Password,
                u.FullName,
                u.Email,
                u.Phone,
                u.IsAdmin
            }).ToList();

            dgvUsers.DataSource = users;
        }
    }

    private void dgvUsers_SelectedChanged(object sender, EventArgs e)
    {
        try
        {
            if(dgvUsers.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki UserID'yi al
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["userIDDataGridViewTextBoxColumn"].Value);

                using (var dbContext = new BusDbContext())
                {
                    // Veritabanından kullanıcıyı bul
                    var user = dbContext.Users.FirstOrDefault(u => u.UserID == userId);

                    if (user == null)
                    {
                        MessageBox.Show("Seçilen kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kullanıcı bilgilerini form elemanlarına yerleştir
                    txtUserName.Text = user.UserName;
                    txtPassword.Text = user.Password;
                    txtFullName.Text = user.FullName;
                    txtEmail.Text = user.Email;
                    txtPhone.Text = user.Phone;
                    chkIsAdmin.Checked = user.IsAdmin;
                }
            }
        }
        catch (Exception ex)
        {
            // Hataları yakala ve kullanıcıya bildir
            MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvTrips_SelectedChanged(object sender, EventArgs e)
    {
        try
        {
            if (dgvTrips.SelectedRows.Count > 0)
            {
                // Seçilen satırdaki UserID'yi al
                int tripId = Convert.ToInt32(dgvTrips.SelectedRows[0].Cells["tripIDDataGridViewTextBoxColumn"].Value);

                using (var dbContext = new BusDbContext())
                {
                    // Veritabanından kullanıcıyı bul
                    var trip = dbContext.Trips
                                        .Include(t => t.Bus)
                                        .Include(t => t.Driver)
                                        .Include(t => t.DepartureBranch)
                                        .Include(t => t.ArrivalBranch)
                                        .FirstOrDefault(t => t.TripID == tripId);

                    if (trip == null)
                    {
                        MessageBox.Show("Seçilen kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kullanıcı bilgilerini form elemanlarına yerleştir
                    cmbDepartureBranch.SelectedValue = trip.DepartureBranchID;
                    cmbArrivalBranch.SelectedValue = trip.ArrivalBranchID;
                    dtpTripDate.Value = trip.DateTime;
                    txtPrice.Text = trip.Price.ToString("F2");
                    cmbBus.SelectedValue = trip.BusID;
                    cmbDriver.SelectedValue = trip.DriverID;
                }
            }
        }
        catch (Exception ex)
        {
            // Hataları yakala ve kullanıcıya bildir
            MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadBranches()
    {
        using (var dbContext = new BusDbContext())
        {
            var branches = dbContext.Branches
                                    .Select(b => new { b.BranchID, b.BranchName })
                                    .OrderBy(b => b.BranchName)
                                    .ToList();

            // Kalkış noktası ComboBox dolduruluyor
            cmbDepartureBranch.DataSource = branches;
            cmbDepartureBranch.DisplayMember = "BranchName";
            cmbDepartureBranch.ValueMember = "BranchID";

            // Varış noktası ComboBox dolduruluyor
            cmbArrivalBranch.DataSource = branches.ToList(); // Yeni bir liste kullanarak bağımsız veri kaynağı
            cmbArrivalBranch.DisplayMember = "BranchName";
            cmbArrivalBranch.ValueMember = "BranchID";
        }
    }

    private void LoadDrivers()
    {
        try
        {
            using (var dbContext = new BusDbContext())
            {
                var drivers = dbContext.Drivers
                                     .Select(d => new { d.DriverID, d.FullName })
                                     .OrderBy(d => d.FullName)
                                     .ToList();

                if (!drivers.Any())
                {
                    MessageBox.Show("Sistemde kayıtlı sürücü bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cmbDriver.DataSource = null; // Önceki kaynağı temizle
                cmbDriver.Items.Clear();

                cmbDriver.DataSource = drivers;
                cmbDriver.DisplayMember = "FullName"; // Gösterilecek alan
                cmbDriver.ValueMember = "DriverID";   // Seçilen ID
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Sürücü yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadBuses()
    {
        try
        {
            using (var dbContext = new BusDbContext())
            {
                var buses = dbContext.Buses
                                     .Select(b => new { b.BusID, b.Model })
                                     .OrderBy(b => b.Model)
                                     .ToList();

                if (!buses.Any())
                {
                    MessageBox.Show("Sistemde kayıtlı otobüs bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cmbBus.DataSource = null; // Önceki kaynağı temizle
                cmbBus.Items.Clear();

                cmbBus.DataSource = buses;
                cmbBus.DisplayMember = "Model"; // ComboBox'ta gösterilecek alan
                cmbBus.ValueMember = "BusID";   // ComboBox'ın seçeceği değer
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Otobüsler yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}