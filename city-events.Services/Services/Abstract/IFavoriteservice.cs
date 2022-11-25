using city_events.Services.Models;
namespace city_events.Services.Abstract;
public interface IFavoriteService
{
    FavoriteModel GetFavorite(Guid id);
    FavoriteModel UpdateFavorite(Guid id, FavoriteModel fav);
    void DeleteFavorite(Guid id);
    PageModel<FavoriteModel> GetFavorites(int limit = 20, int offset = 0);
}