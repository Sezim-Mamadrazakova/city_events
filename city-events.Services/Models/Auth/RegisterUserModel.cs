using city_events.Entity.Models;
namespace city_events.Services.Models;
public class RegisterUserModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName{get;set;}
}