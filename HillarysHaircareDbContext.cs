using HillarysHaircare.Models;
using Microsoft.EntityFrameworkCore;

public class HillarysHaircareDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentService> AppointmentServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Customer>()
            .HasData(
                new Customer[]
                {
                    new Customer { Id = 1, Name = "Sarah Johnson" },
                    new Customer { Id = 2, Name = "Michael Chen" },
                    new Customer { Id = 3, Name = "Emma Rodriguez" },
                    new Customer { Id = 4, Name = "James Williams" },
                    new Customer { Id = 5, Name = "Lisa Garcia" },
                    new Customer { Id = 6, Name = "David Miller" },
                    new Customer { Id = 7, Name = "Maria Wilson" },
                }
            );

        modelBuilder
            .Entity<Stylist>()
            .HasData(
                new Stylist[]
                {
                    new Stylist
                    {
                        Id = 1,
                        Name = "Jessica Smith",
                        IsActive = true,
                    },
                    new Stylist
                    {
                        Id = 2,
                        Name = "Ryan Brown",
                        IsActive = true,
                    },
                    new Stylist
                    {
                        Id = 3,
                        Name = "Amanda Davis",
                        IsActive = false,
                    },
                    new Stylist
                    {
                        Id = 4,
                        Name = "Carlos Martinez",
                        IsActive = true,
                    },
                }
            );

        modelBuilder
            .Entity<Service>()
            .HasData(
                new Service[]
                {
                    new Service
                    {
                        Id = 1,
                        Name = "Haircut",
                        BasePrice = 30.00M,
                    },
                    new Service
                    {
                        Id = 2,
                        Name = "Color",
                        BasePrice = 100.00M,
                    },
                    new Service
                    {
                        Id = 3,
                        Name = "Highlights",
                        BasePrice = 120.00M,
                    },
                    new Service
                    {
                        Id = 4,
                        Name = "Style",
                        BasePrice = 45.00M,
                    },
                    new Service
                    {
                        Id = 5,
                        Name = "Beard Trim",
                        BasePrice = 20.00M,
                    },
                }
            );

        modelBuilder
            .Entity<Appointment>()
            .HasData(
                new Appointment[]
                {
                    new Appointment
                    {
                        Id = 1,
                        CustomerId = 1,
                        StylistId = 1,
                        Date = new DateOnly(2025, 1, 28),
                        Time = new TimeOnly(9, 0),
                        Status = true,
                        Notes = "First time client, wants layered cut",
                    },
                    new Appointment
                    {
                        Id = 2,
                        CustomerId = 2,
                        StylistId = 1,
                        Date = new DateOnly(2025, 1, 28),
                        Time = new TimeOnly(10, 0),
                        Status = true,
                        Notes = "Regular client - usual style",
                    },
                    new Appointment
                    {
                        Id = 3,
                        CustomerId = 3,
                        StylistId = 2,
                        Date = new DateOnly(2025, 1, 28),
                        Time = new TimeOnly(11, 0),
                        Status = false,
                        Notes = "Cancelled due to illness",
                    },
                    new Appointment
                    {
                        Id = 4,
                        CustomerId = 4,
                        StylistId = 2,
                        Date = new DateOnly(2025, 1, 29),
                        Time = new TimeOnly(13, 0),
                        Status = true,
                        Notes = "Wants to try new color",
                    },
                    new Appointment
                    {
                        Id = 5,
                        CustomerId = 5,
                        StylistId = 1,
                        Date = new DateOnly(2025, 1, 29),
                        Time = new TimeOnly(14, 0),
                        Status = true,
                        Notes = null,
                    },
                }
            );

        modelBuilder
            .Entity<AppointmentService>()
            .HasData(
                new AppointmentService[]
                {
                    new AppointmentService
                    {
                        Id = 1,
                        AppointmentId = 1,
                        ServiceId = 1,
                    },
                    new AppointmentService
                    {
                        Id = 2,
                        AppointmentId = 1,
                        ServiceId = 4,
                    },
                    new AppointmentService
                    {
                        Id = 3,
                        AppointmentId = 2,
                        ServiceId = 1,
                    },
                    new AppointmentService
                    {
                        Id = 4,
                        AppointmentId = 4,
                        ServiceId = 1,
                    },
                    new AppointmentService
                    {
                        Id = 5,
                        AppointmentId = 4,
                        ServiceId = 2,
                    },
                    new AppointmentService
                    {
                        Id = 6,
                        AppointmentId = 5,
                        ServiceId = 3,
                    },
                }
            );
    }

    public HillarysHaircareDbContext(DbContextOptions<HillarysHaircareDbContext> context)
        : base(context) { }
}
