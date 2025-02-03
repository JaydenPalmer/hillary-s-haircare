namespace HillarysHaircare.Models.DTOs;

public class CreateAppointmentDTO
{
    public int CustomerId { get; set; }
    public int StylistId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public string? Notes { get; set; }
    public List<int> ServiceIds { get; set; }
}
