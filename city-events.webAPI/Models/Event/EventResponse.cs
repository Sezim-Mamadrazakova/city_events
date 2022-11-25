namespace city_events.webAPI.Models;
public class EventResponse
{
    public Guid Id {get; set;}
    public string? EventName{ get; set;}
    public string? EventPlace{get; set;}
    public DateTime DateStart{get;set;}
    public DateTime DateFinish{get;set;}
    
    public virtual Guid UserId{get; set;}
    
}