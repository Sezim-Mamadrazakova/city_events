using AutoMapper;
using city_events.webAPI.Models;
using city_events.Services.Models;

namespace city_events.webAPI.MapperProfile;

public class PresentationProfile : Profile{
    public PresentationProfile()
    {
        #region Pages

        CreateMap(typeof(PageModel<>),typeof(PageResponse<>));

        #endregion

        #region Users

        CreateMap<UserModel, UserResponse>().ReverseMap();
        CreateMap<UpdateUserRequest, UpdateUserModel>().ReverseMap();
        CreateMap<UserPreviewModel, UserPreviewResponse>().ReverseMap();
        CreateMap<UserResponse, UserPreviewModel>().ReverseMap();
        
        #endregion
        #region Event
        CreateMap<EventModel,EventResponse>().ReverseMap();
        CreateMap<UpdateEventRequest, UpdateEventModel>().ReverseMap();
        CreateMap<EventPreviewModel, EventPreviewResponse>().ReverseMap();
        CreateMap<EventResponse, EventPreviewModel>().ReverseMap();
        #endregion
        #region City
        CreateMap<CityModel,CityResponse>().ReverseMap();
        CreateMap<UpdateCityRequest, UpdateEventModel>().ReverseMap();
        CreateMap<CityPreviewModel, CityPreviewResponse>().ReverseMap();
        CreateMap<CityResponse, CityPreviewModel>().ReverseMap();

        #endregion
        #region Admin
        CreateMap<AdminModel, AdminResponse>().ReverseMap();
        CreateMap<UpdateAdminRequest, UpdateAdminModel>().ReverseMap();
        CreateMap<AdminPreviewModel, AdminPreviewResponse>().ReverseMap();
        CreateMap<AdminResponse, AdminPreviewModel>().ReverseMap();
        #endregion
        #region Favorite
        CreateMap<FavoriteModel, FavotiteResponses>().ReverseMap();
        #endregion
    }
}