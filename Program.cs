using System.Text.Json.Serialization;
using HillarysHaircare.Models;
using HillarysHaircare.Models.DTOs;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HillarysHaircareDbContext>(
    builder.Configuration["HillarysHaircareDbConnectionString"]
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//get an entire appointment
app.MapGet(
    "/api/appointments",
    (HillarysHaircareDbContext db) =>
    {
        return db
            .Appointments.Include(c => c.Customer)
            .Include(s => s.Stylist)
            .Include(appser => appser.AppointmentServices)
            .ThenInclude(ser => ser.Service)
            .Select(a => new AppointmentDTO
            {
                Id = a.Id,
                CustomerId = a.CustomerId,
                Customer = new CustomerDTO { Id = a.Customer.Id, Name = a.Customer.Name },
                StylistId = a.StylistId,
                Stylist = new StylistDTO { Id = a.Stylist.Id, Name = a.Stylist.Name },
                Date = a.Date,
                Time = a.Time,
                Status = a.Status,
                Notes = a.Notes,
                AppointmentServices = a
                    .AppointmentServices.Select(appService => new AppointmentServiceDTO
                    {
                        Id = appService.Id,
                        AppointmentId = appService.AppointmentId,
                        ServiceId = appService.ServiceId,
                        Service = new ServiceDTO
                        {
                            Id = appService.Service.Id,
                            Name = appService.Service.Name,
                        },
                    })
                    .ToList(),
            });
    }
);

//cancel an appointment
app.MapPost(
    "/api/appointments/{id}/cancel",
    (HillarysHaircareDbContext db, int id) =>
    {
        Appointment appointmentToCancel = db.Appointments.SingleOrDefault(a => a.Id == id);

        if (appointmentToCancel == null)
        {
            return Results.NotFound("Must already be canceled?");
        }

        appointmentToCancel.Status = false;

        db.SaveChanges();
        return Results.NoContent();
    }
);

//get all the customers
app.MapGet(
    "/api/customers",
    (HillarysHaircareDbContext db) =>
    {
        return db.Customers.Select(c => new CustomerDTO { Id = c.Id, Name = c.Name });
    }
);

app.MapGet(
    "/api/stylists",
    (HillarysHaircareDbContext db) =>
    {
        return db
            .Stylists.Include(a => a.Appointments)
            .Select(s => new StylistDTO
            {
                Id = s.Id,
                Name = s.Name,
                IsActive = s.IsActive,
                Appointments = s
                    .Appointments.Select(sa => new AppointmentDTO
                    {
                        Id = sa.Id,
                        Date = sa.Date,
                        Time = sa.Time,
                        Status = sa.Status,
                    })
                    .ToList(),
            });
    }
);

//posting an appointment with their join tables for services
app.MapPost(
    "/api/appointments",
    async (HillarysHaircareDbContext db, CreateAppointmentDTO createAppointmentDTO) =>
    {
        var appointment = new Appointment
        {
            CustomerId = createAppointmentDTO.CustomerId,
            StylistId = createAppointmentDTO.StylistId,
            Date = createAppointmentDTO.Date,
            Time = createAppointmentDTO.Time,
            Notes = createAppointmentDTO.Notes,
            Status = true,
        };

        db.Appointments.Add(appointment);
        await db.SaveChangesAsync();

        var appointmentServices = createAppointmentDTO.ServiceIds.Select(
            serviceId => new AppointmentService
            {
                AppointmentId = appointment.Id,
                ServiceId = serviceId,
            }
        );

        db.AppointmentServices.AddRange(appointmentServices);
        await db.SaveChangesAsync();

        return Results.Created(
            $"/api/appointments/{appointment.Id}",
            new
            {
                appointment.Id,
                appointment.CustomerId,
                appointment.StylistId,
                appointment.Date,
                appointment.Time,
                appointment.Notes,
                appointment.Status,
            }
        );
    }
);

app.MapGet(
    "/api/services",
    (HillarysHaircareDbContext db) =>
    {
        return db.Services.Select(s => new ServiceDTO
        {
            Id = s.Id,
            Name = s.Name,
            BasePrice = s.BasePrice,
        });
    }
);

app.MapPost(
    "/api/stylists/{id}/deactivate",
    (HillarysHaircareDbContext db, int id) =>
    {
        Stylist stylistToDeactivate = db.Stylists.FirstOrDefault(style => style.Id == id);

        if (stylistToDeactivate == null)
        {
            Results.NotFound("huh thats weird");
        }

        stylistToDeactivate.IsActive = false;
        db.SaveChanges();

        return Results.NoContent();
    }
);

app.Run();
