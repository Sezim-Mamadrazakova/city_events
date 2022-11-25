using city_events.Entity.Models;
namespace city_events.Services.Models;
public class AdminModel: BaseModel
{
    public Guid Id{get;set;}
    public string? Login{get;set;} 
}