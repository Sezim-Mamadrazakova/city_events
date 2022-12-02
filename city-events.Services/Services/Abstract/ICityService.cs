using city_events.Services.Models;
namespace city_events.Services.Abstract;
public interface ICityService
{
    CityModel GetCity(Guid id);
    CityModel UpdateCity(Guid id, UpdateCityModel city);
    void DeleteCity(Guid id);
    PageModel<CityPreviewModel> GetCitys(int limit = 20, int offset = 0);
    CityModel CreateCity(CityModel city);
}