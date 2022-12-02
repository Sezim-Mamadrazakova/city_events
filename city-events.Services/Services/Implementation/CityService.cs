using AutoMapper;
using city_events.Entity.Models;
using city_events.Repository;
using city_events.Services.Abstract;
using city_events.Services.Models;

namespace city_events.Services.Implementation;

public class CityService :ICityService
{
    private readonly IRepository<City> cityRepository;
    private readonly IMapper mapper;
    public CityService(IRepository<City> cityRepository, IMapper mapper)
    {
        this.cityRepository=cityRepository;
        this.mapper = mapper;
    }

    public void DeleteCity(Guid id)
    {
        var cityToDelete =cityRepository.GetById(id);
        if (cityToDelete == null)
        {
            throw new Exception("Admin not found");
        }
        cityRepository.Delete(cityToDelete);
    }

    public CityModel GetCity(Guid id)
    {
        var city = cityRepository.GetById(id);
        return mapper.Map<CityModel>(city);
    }

    public PageModel<CityPreviewModel> GetCitys(int limit = 20, int offset = 0)
    {
        var city =cityRepository.GetAll();
        int totalCount =city.Count();
        var chunk=city.OrderBy(x=>x.city).Skip(offset).Take(limit);

        return new PageModel<CityPreviewModel>()
        {
            Items = mapper.Map<IEnumerable<CityPreviewModel>>(city),
            TotalCount = totalCount
        };
    }

    public CityModel UpdateCity(Guid id, UpdateCityModel city)
    {
        var existingCity = cityRepository.GetById(id);
        if (existingCity == null)
        {
            throw new Exception("Admin not found");
        }
        existingCity.city=city.city;
        existingCity = cityRepository.Save(existingCity);
        return mapper.Map<CityModel>(existingCity);
    }
    CityModel ICityService.CreateCity(CityModel cityModel)
    {
      cityRepository.Save(mapper.Map<Entity.Models.City>(cityModel));
        return cityModel;
    }
}