using BusTicketSales;

namespace WinFormsApp1;

public static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        ApplicationConfiguration.Initialize();
        Application.Run(new LoginForm());
    }
}