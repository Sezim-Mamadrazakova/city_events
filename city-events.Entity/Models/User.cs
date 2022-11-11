namespace city_events.Entity.Models;
public class User: BaseEntity
{
    public string? FullName{get; set;}
    public string? Email{get; set;}
    public string? PasswordHash{get; set;}
    public virtual ICollection<Events>? Event{get; set;}
    public virtual Guid CityId{get; set;}
    public virtual City? City{get; set;}
    public virtual ICollection<Favorites>? Favorite{get; set;}

    
}