using city_events.Entity.Models;
namespace city_events.Services.Models;
public class CityModel : BaseModel
{
    public Guid Id {get; set;}
    public string? city{get;set;}
    
}