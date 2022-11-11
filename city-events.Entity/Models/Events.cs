namespace city_events.Entity.Models;
public class Events : BaseEntity
{
    public string? EventName{ get; set;}
    public string? EventPlace{get; set;}
    public DateTime DateStart{get;set;}
    public DateTime DateFinish{get;set;}
    
    public virtual Guid UserId{get; set;}
    public virtual  User? User{get; set;}
    public virtual ICollection<Favorites>? Favorites{get; set;}

}