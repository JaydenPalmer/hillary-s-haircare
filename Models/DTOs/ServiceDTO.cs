namespace HillarysHaircare.Models.DTOs;

public class ServiceDTO
{
    public int Id { get; set; }

    public string Name { get; set; }
    public decimal BasePrice { get; set; }
    public List<AppointmentServiceDTO> AppointmentServices { get; set; }
}
