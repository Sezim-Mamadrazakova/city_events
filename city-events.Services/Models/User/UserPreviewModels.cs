using city_events.Entity.Models;
namespace city_events.Services.Models;
public class UserPreviewModel
{
    public Guid Id{get;set;}
    public string? FullName{get; set;}
    public string? Email{get; set;}
    
}