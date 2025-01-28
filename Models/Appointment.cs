using System.ComponentModel.DataAnnotations;

namespace HillarysHaircare.Models;

public class Appointment
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int StylistId { get; set; }
    public Stylist Stylist { get; set; }

    [Required]
    public DateOnly Date { get; set; }

    [Required]
    public TimeOnly Time { get; set; }
    public bool Status { get; set; } = true;
    public string? Notes { get; set; }

    public List<AppointmentService> AppointmentServices { get; set; }
    public decimal TotalPrice
    {
        get { return AppointmentServices?.Sum(appser => appser.Service.BasePrice) ?? 0; }
    }
}
