using System.ComponentModel.DataAnnotations;

namespace BusTicketSales.Entities;

public class Bus
{
    [Key]
    public int BusID { get; set; }
    public int BranchID { get; set; }
    public int PlateNumber { get; set; }
    public int Capacity { get; set; }
    public string Model { get; set; }
    public Branch Branch { get; set; }
    public ICollection<Trip> Trips { get; set; }
}
