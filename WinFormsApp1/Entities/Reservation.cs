using System.ComponentModel.DataAnnotations;

namespace BusTicketSales.Entities;

public class Reservation
{
    [Key]
    public int ReservationID { get; set; }
    public int TripID { get; set; }
    public int UserID { get; set; }
    public int SeatNumber { get; set; }
    public DateTime ReservationDate { get; set; }
    public Trip Trip { get; set; }
    public User User { get; set; }
    public Payment Payment { get; set; }
}
