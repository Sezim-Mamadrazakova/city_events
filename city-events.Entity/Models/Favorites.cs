namespace city_events.Entity.Models;
public class Favorites: BaseEntity
{
    public virtual Guid UserId {get;set;}
    public virtual User? User{get; set;}
    public virtual Events? Events{get;set;}
    public virtual Guid EventsId{get;set;}
    
}