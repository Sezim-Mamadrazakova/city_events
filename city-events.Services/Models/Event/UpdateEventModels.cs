using city_events.Entity.Models;
namespace city_events.Services.Models;
public class UpdateEventModel
{
    public string? EventName{ get; set;}
    public string? EventPlace{get; set;}
    public DateTime DateStart{get;set;}
    public DateTime DateFinish{get;set;}
    
}