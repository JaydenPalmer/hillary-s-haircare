namespace HillarysHaircare.Models.DTOs;

public class CustomerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<AppointmentDTO> Appointments { get; set; }
}
