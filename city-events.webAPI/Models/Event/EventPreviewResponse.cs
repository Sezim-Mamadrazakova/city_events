namespace city_events.webAPI.Models;
public class EventPreviewResponse
{
    public Guid Id {get; set;}
    public string? EventName{ get; set;}
    public string? EventPlace{get; set;}
    public DateTime DateStart{get;set;}
    public DateTime DateFinish{get;set;}
    
}