
namespace city_events.Services.Models;
public class CreateEventModel
{
    
    public string? EventName{ get; set;}
    public string? EventPlace{get; set;}
    public DateTime DateStart{get;set;}
    public DateTime DateFinish{get;set;}
    
    public virtual Guid UserId{get; set;}
    
}