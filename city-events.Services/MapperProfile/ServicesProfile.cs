using AutoMapper;
using  city_events.Entity.Models;
using city_events.Services.Models;
namespace city_events.Services.MapperProfile;
public class ServicesProfile: Profile{
    public ServicesProfile(){
        #region Users
        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<UserModel, UserPreviewModel>()
            .ForMember(x => x.FullName, y => y.MapFrom(u => u.FullName))
            .ForMember(x => x.Email, y => y.MapFrom(u => u.Email));
        #endregion
        #region Events
        CreateMap<Events, EventModel>().ReverseMap();
        CreateMap<EventModel, EventPreviewModel>()
            .ForMember(x=>x.EventName, y=>y.MapFrom(u => u.EventName))
            .ForMember(x=>x.EventPlace, y=>y.MapFrom(u => u.EventPlace))
            .ForMember(x=>x.DateStart, y=>y.MapFrom(u=>u.DateStart))
            .ForMember(x=>x.DateFinish, y=>y.MapFrom(u =>u.DateFinish));

        #endregion
        #region Favorites
        CreateMap<Favorites, FavoriteModel>().ReverseMap();
        #endregion
        #region City
        CreateMap<City, CityModel>().ReverseMap();
        CreateMap<CityModel, CityPreviewModel>()
            .ForMember(x=>x.city, y=>y.MapFrom(u=>u.city));
        #endregion
    }
} 