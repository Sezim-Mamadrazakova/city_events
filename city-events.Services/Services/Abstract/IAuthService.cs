using city_events.Services.Models;
using IdentityModel.Client;

namespace city_events.Services.Abstract;
public interface IAuthService
{
    Task<UserModel> RegisterUser(RegisterUserModel model);
    Task<TokenResponse> LoginUser(LoginUserModel model);
}