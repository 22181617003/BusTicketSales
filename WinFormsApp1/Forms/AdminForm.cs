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
    }

    private void AdminForm_Load(object sender, EventArgs e)
    {
        try
        {
            // Kalkış ve varış noktalarını doldur
            LoadBranches();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnAddTrip_Click(object sender, EventArgs e)
    {
        // Gerekli alanların doldurulup doldurulmadığını kontrol et
        if (cmbDepartureBranch.SelectedValue == null || cmbArrivalBranch.SelectedValue == null ||
            string.IsNullOrWhiteSpace(txtPrice.Text))
        {
            MessageBox.Show("Lütfen tüm alanları doldurun.");
            return;
        }

        // Fiyatın geçerli bir sayı olup olmadığını kontrol et
        if (!double.TryParse(txtPrice.Text, out double price))
        {
            MessageBox.Show("Geçerli bir fiyat girin.");
            return;
        }

        // Veritabanına trip ekle
        try
        {
            using (var dbContext = new BusDbContext())
            {
                var trip = new Trip
                {
                    DepartureBranchID = (int)cmbDepartureBranch.SelectedValue,
                    ArrivalBranchID = (int)cmbArrivalBranch.SelectedValue,
                    DateTime = dtpTripDate.Value,
                    Price = price
                };

                dbContext.Trips.Add(trip);
                dbContext.SaveChanges();
            }

            MessageBox.Show("Sefer başarıyla eklendi.");
            LoadTrips(); // Grid'i güncellemek için
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Bir hata oluştu: {ex.Message}");
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

                string departureBranchName = cmbDepartureBranch.SelectedItem.ToString();
                string arrivalBranchName = cmbArrivalBranch.SelectedItem.ToString();
                var departureBranch = dbContext.Branches.FirstOrDefault(b => b.BranchName ==  departureBranchName);
                var arrivalBranch = dbContext.Branches.FirstOrDefault(b => b.BranchName == arrivalBranchName);

                // Sefer bilgilerini güncelle
                trip.DepartureBranchID = departureBranch.BranchID;
                trip.ArrivalBranchID = arrivalBranch.BranchID;
                trip.DateTime = dtpTripDate.Value.ToUniversalTime();
                trip.Price = double.Parse(txtPrice.Text);

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
}