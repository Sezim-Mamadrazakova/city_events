using city_events.Entity.Models;
namespace city_events.Services.Models;
public class UserModel: BaseModel
{
    public Guid Id{get;set;}
    public string? FullName{get; set;}
    public string? Email{get; set;}
    public virtual Guid CityId{get;set;}
    
}