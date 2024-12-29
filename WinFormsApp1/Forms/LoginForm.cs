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
                // Giriş yapan kullanıcıyı statik bir yapıda sakla
                LoggedUser.loggedInUser = user;
                MessageBox.Show("Giriş başarılı!");

                this.Hide(); // Login formunu gizle

                // Kullanıcının admin olup olmadığını kontrol et
                if (user.IsAdmin)
                {
                    var adminForm = new AdminForm();
                    adminForm.Show();
                }
                else
                {
                    var reservationForm = new ReservationForm();
                    reservationForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
        }
    }


}
