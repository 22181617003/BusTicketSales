using System.ComponentModel.DataAnnotations;

namespace BusTicketSales.Entities;

public class Feedback
{
    [Key]
    public int FeedbackID { get; set; }
    public int UserID { get; set; }
    public int TripID { get; set; }
    public double Rating { get; set; }
    public string Comments { get; set; }
    public DateTime FeedbackDate { get; set; }
    public User User { get; set; }
    public Trip Trip { get; set; }

}
