namespace city_events.Services.Models;
public class CreateFavoriteModel
{
    
    public virtual Guid UserId{get; set;}
    public virtual Guid EventId{get; set;}
    
}