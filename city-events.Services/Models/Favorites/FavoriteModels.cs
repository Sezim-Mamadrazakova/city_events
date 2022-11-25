using city_events.Entity.Models;
namespace city_events.Services.Models;
public class FavoriteModel:BaseModel{
    public virtual Guid UserId{get;set;}
    public virtual Guid EventsId{get;set;}
}