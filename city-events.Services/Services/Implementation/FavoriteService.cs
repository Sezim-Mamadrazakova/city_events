using AutoMapper;
using city_events.Entity.Models;
using city_events.Repository;
using city_events.Services.Abstract;
using city_events.Services.Models;

namespace city_events.Services.Implementation;
public class FavoriteService :IFavoriteService{
    private readonly IRepository<Favorites> favoriteRepository;
    private readonly IMapper mapper;
    public FavoriteService(IRepository<Favorites> favoriteRepository, IMapper mapper)
    {
        this.favoriteRepository= favoriteRepository;
        this.mapper = mapper;
    }

    public void DeleteFavorite(Guid id)
    {
        var favoriteToDelete = favoriteRepository.GetById(id);
        if (favoriteToDelete == null)
        {
            throw new Exception("Contact not found"); //   реализовать service exeption class const
        }

        favoriteRepository.Delete(favoriteToDelete);
    }

    public FavoriteModel GetFavorite(Guid id)
    {
        var favorite= favoriteRepository.GetById(id);
         if (favorite == null)
        {
            throw new Exception("Contact not found"); //   реализовать service exeption class const
        }
        return mapper.Map<FavoriteModel>(favorite);
    }

    public PageModel<FavoriteModel> GetFavorites(int limit = 20, int offset = 0)
    {
        var favorite = favoriteRepository.GetAll();
        int totalCount = favorite.Count();
        var chunk = favorite.OrderBy(x => x.UserId).Skip(offset).Take(limit);

        return new PageModel<FavoriteModel>()
        {
           
            Items = mapper.Map<IEnumerable<FavoriteModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public FavoriteModel UpdateFavorite(Guid id, FavoriteModel favorite)
    {
        var existingFavorite = favoriteRepository.GetById(id);
        if (existingFavorite == null)
        {
            throw new Exception("Contact not found");
        }

        existingFavorite.UserId = favorite.UserId;
        existingFavorite.EventsId = favorite.EventsId;

        existingFavorite = favoriteRepository.Save(existingFavorite);
        return mapper.Map<FavoriteModel>(existingFavorite);
    }

}