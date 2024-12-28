using System.ComponentModel.DataAnnotations;

namespace BusTicketSales.Entities;

public class Payment
{
    [Key]
    public int PaymentID { get; set; }
    public int ReservationID { get; set; }
    public double Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; }
    public Reservation Reservation { get; set; }

}
