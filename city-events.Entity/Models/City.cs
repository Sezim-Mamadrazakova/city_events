namespace city_events.Entity.Models;
public class City: BaseEntity
{
    public string? city{get;set;}
    public virtual ICollection<User>? Users{get; set;}

}
