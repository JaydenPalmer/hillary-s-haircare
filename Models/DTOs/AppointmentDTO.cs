namespace HillarysHaircare.Models.DTOs;

public class AppointmentDTO
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public CustomerDTO Customer { get; set; }

    public int StylistId { get; set; }
    public StylistDTO Stylist { get; set; }

    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public bool Status { get; set; } = true;
    public string? Notes { get; set; }

    public List<AppointmentServiceDTO> AppointmentServices { get; set; }
}
