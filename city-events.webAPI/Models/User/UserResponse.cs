namespace city_events.webAPI.Models;
public class UserResponse{
    public Guid Id{get;set;}
    public string? FullName{get; set;}
    public string? Email{get; set;}
    public virtual Guid CityId{get;set;}
    
}