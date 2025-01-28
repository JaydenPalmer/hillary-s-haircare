using System.ComponentModel.DataAnnotations;

namespace HillarysHaircare.Models;

public class Service
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    public decimal BasePrice { get; set; }
    public List<AppointmentService> AppointmentServices { get; set; }
}
