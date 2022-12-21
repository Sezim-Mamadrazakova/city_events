using city_events.Services.Abstract;
using city_events.Services.Implementation;
using city_events.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;
namespace city_events.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));
        //services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IFavoriteService, FavoriteService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}