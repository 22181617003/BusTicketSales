using System.ComponentModel.DataAnnotations;

namespace BusTicketSales.Entities;

public class Branch
{
    public int BranchID { get; set; }
    public string BranchName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Phone { get; set; }
    public ICollection<Bus> Buses { get; set; }
    public ICollection<Driver> Drivers { get; set; }
    public ICollection<Trip> DepartureTrips { get; set; }
    public ICollection<Trip> ArrivalTrips { get; set; }
}
