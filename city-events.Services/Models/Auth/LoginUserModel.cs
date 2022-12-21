using city_events.Entity.Models;
namespace city_events.Services.Models;
public class LoginUserModel
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}