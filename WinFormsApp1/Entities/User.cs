using System.ComponentModel.DataAnnotations;

namespace BusTicketSales.Entities;

public class User
{
    [Key]
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool IsAdmin { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<Feedback> Feedbacks { get; set; }
}
