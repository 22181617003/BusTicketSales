using System.ComponentModel.DataAnnotations;

namespace BusTicketSales.Entities;

public class Trip
{
    [Key]
    public int TripID { get; set; }
    public int BusID { get; set; }
    public int DriverID { get; set; }
    public int DepartureBranchID { get; set; }
    public int ArrivalBranchID { get; set; }
    public DateTime DateTime { get; set; }
    public double Price { get; set; }
    public Bus Bus { get; set; }
    public Driver Driver { get; set; }
    public Branch DepartureBranch { get; set; }
    public Branch ArrivalBranch { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<Feedback> Feedbacks { get; set; }
}
