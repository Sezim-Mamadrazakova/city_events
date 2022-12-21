namespace city_events.Entity.Models;
using Microsoft.AspNetCore.Identity;
public class User: IdentityUser<Guid>, IBaseEntity
{
    public string? FullName{get; set;}
    public string? Email{get; set;}
    public string? PasswordHash{get; set;}
    public virtual ICollection<Events>? Event{get; set;}
    public virtual Guid CityId{get; set;}
    public virtual City? City{get; set;}
    public virtual ICollection<Favorites>? Favorite{get; set;}
    #region BaseEntity

    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }

    public bool IsNew()
    {
        return Id == Guid.Empty;
    }

    public void Init()
    {
        Id = Guid.NewGuid();
        CreationTime = DateTime.UtcNow;
        ModificationTime = DateTime.UtcNow;
    }

    #endregion
}
 
public class UserRole : IdentityRole<Guid>
{ 
    
}