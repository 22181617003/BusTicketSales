using Microsoft.EntityFrameworkCore;
namespace BusTicketSales.Entities;

public class BusDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BusTicketSales;Username=postgres;Password=12345;");
    }

    public DbSet<Branch> Branches { get; set; }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Bus>()
            .HasOne(b => b.Branch)
            .WithMany(br => br.Buses)
            .HasForeignKey(b => b.BranchID);

        modelBuilder.Entity<Driver>()
            .HasOne(d => d.Branch)
            .WithMany(br => br.Drivers)
            .HasForeignKey(d => d.BranchID);

        modelBuilder.Entity<Trip>()
            .HasOne(t => t.Bus)
            .WithMany(b => b.Trips)
            .HasForeignKey(t => t.BusID);

        modelBuilder.Entity<Trip>()
            .HasOne(t => t.Driver)
            .WithMany(d => d.Trips)
            .HasForeignKey(t => t.DriverID);

        modelBuilder.Entity<Trip>()
            .HasOne(t => t.DepartureBranch)
            .WithMany(b => b.DepartureTrips)
            .HasForeignKey(t => t.DepartureBranchID);

        modelBuilder.Entity<Trip>()
            .HasOne(t => t.ArrivalBranch)
            .WithMany(b => b.ArrivalTrips)
            .HasForeignKey(t => t.ArrivalBranchID);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Trip)
            .WithMany(t => t.Reservations)
            .HasForeignKey(r => r.TripID);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reservations)
            .HasForeignKey(r => r.UserID);

        modelBuilder.Entity<Feedback>()
            .HasOne(f => f.User)
            .WithMany(u => u.Feedbacks)
            .HasForeignKey(f => f.UserID);

        modelBuilder.Entity<Feedback>()
            .HasOne(f => f.Trip)
            .WithMany(t => t.Feedbacks)
            .HasForeignKey(f => f.TripID);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Reservation)
            .WithOne(r => r.Payment)
            .HasForeignKey<Payment>(p => p.ReservationID);
    }
}
