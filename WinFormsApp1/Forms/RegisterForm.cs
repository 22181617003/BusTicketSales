using BusTicketSales.Entities;

namespace BusTicketSales.Forms;

public partial class RegisterForm : Form
{
    public RegisterForm()
    {
        InitializeComponent();
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        string fullname = txtFullname.Text;
        string email = txtEmail.Text;
        string phone = txtPhone.Text;
        string username = txtUsername.Text;
        string password = txtPassword.Text;
        string confirmPassword = txtConfirmPassword.Text;

        // Hata kontrolü yapalım
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
        {
            lblErrorMessage.Text = "Lütfen tüm alanları doldurun.";
            return;
        }

        if (password != confirmPassword)
        {
            lblErrorMessage.Text = "Şifreler uyuşmuyor.";
            return;
        }

        // Veritabanına kullanıcı kaydını ekleyelim
        using (var dbContext = new BusDbContext())
        {
            // Kullanıcı adı kontrolü
            var existingUser = dbContext.Users.FirstOrDefault(u => u.UserName == username || u.Email == email);
            if (existingUser != null)
            {
                lblErrorMessage.Text = "Kullanıcı adı veya e-posta zaten mevcut.";
                return;
            }

            // Yeni kullanıcı oluşturma
            var user = new User
            {
                FullName = fullname,
                Email = email,
                Phone = phone,
                UserName = username,
                Password = password, // Şifreyi şifrelemeniz gerekmektedir, düz metin olarak kaydetmek güvenli değildir.
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            MessageBox.Show("Kayıt başarılı. Giriş yapabilirsiniz.");
            this.Close(); // Kayıt formunu kapatıyoruz
            LoginForm loginForm = new LoginForm();
            loginForm.Show(); // Giris formunu aç
        }
    }
}
