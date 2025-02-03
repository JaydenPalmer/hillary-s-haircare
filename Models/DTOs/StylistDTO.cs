namespace HillarysHaircare.Models.DTOs;

public class StylistDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public List<AppointmentDTO> Appointments { get; set; }
}
