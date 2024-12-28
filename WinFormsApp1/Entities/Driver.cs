using System.ComponentModel.DataAnnotations;

namespace BusTicketSales.Entities;

public class Driver
{
    [Key]
    public int DriverID { get; set; }
    public int BranchID { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public int LicenseNumber { get; set; }
    public Branch Branch { get; set; }
    public ICollection<Trip> Trips { get; set; }
}
