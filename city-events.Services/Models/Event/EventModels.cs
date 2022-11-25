using city_events.Entity.Models;
namespace city_events.Services.Models;
public class EventModel:BaseModel
{
    public Guid Id {get; set;}
    public string? EventName{ get; set;}
    public string? EventPlace{get; set;}
    public DateTime DateStart{get;set;}
    public DateTime DateFinish{get;set;}
    
    public virtual Guid UserId{get; set;}
    
}