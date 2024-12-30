using BusTicketSales.Entities;
using BusTicketSales.Forms;
namespace BusTicketSales;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
    }

    private void btnRegister_Click(object sender, EventArgs e) 
    {
        RegisterForm registerForm = new RegisterForm();
        registerForm.Show(); // Kayıt formunu aç
        this.Hide(); // Giriş formunu gizle
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text;
        string password = txtPassword.Text;

        using (var dbContext = new BusDbContext())
        {
            var user = dbContext.Users
                .FirstOrDefault(u => u.UserName == username && u.Password == password);

            if (user != null)
            {
                if (user.IsAdmin)
                {
                    // Admin sayfasını aç
                    var adminForm = new AdminForm();
                    adminForm.Show();
                    this.Hide(); // Giriş formunu gizle
                }
                else
                {
                    // Kullanıcı sayfasını aç
                    var userForm = new ReservationForm();
                    userForm.Show();
                    this.Hide(); // Giriş formunu gizle
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
        }
    }

}
