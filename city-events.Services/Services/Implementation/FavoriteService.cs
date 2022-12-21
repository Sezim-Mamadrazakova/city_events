using AutoMapper;
using city_events.Entity.Models;
using city_events.Repository;
using city_events.Services.Abstract;
using city_events.Services.Models;

namespace city_events.Services.Implementation;
public class FavoriteService :IFavoriteService{
    private readonly IRepository<Favorites> favoriteRepository;
    private readonly IRepository<User> userRepository;
    private readonly IRepository<Events> eventRepository;
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
    FavoriteModel IFavoriteService.CreateFavorite(FavoriteModel favoriteModel)
    {
      if(favoriteRepository.GetAll(x=>x.Id==favoriteModel.Id).FirstOrDefault()!=null)
      {
        throw new Exception("create not uniqe subject");
      }
      Favorites createFavorite=new Favorites();
      createFavorite.Id=favoriteModel.Id;
      createFavorite.CreationTime=favoriteModel.CreationTime;
      createFavorite.ModificationTime=favoriteModel.ModificationTime;
      createFavorite.UserId=favoriteModel.UserId;
      createFavorite.EventsId=favoriteModel.EventsId;
      createFavorite.User=userRepository.GetAll(x=>x.Id==createFavorite.UserId).FirstOrDefault();
      if(createFavorite.User==null)
        throw new Exception("not found id User");
      createFavorite.Events=eventRepository.GetAll(x=>x.Id==createFavorite.EventsId).FirstOrDefault();
      if(createFavorite.Events==null){
        throw new Exception("not found id Event");
      }
      createFavorite.Events.Favorites.Add(createFavorite);
      createFavorite.User.Favorite.Add(createFavorite);
      favoriteRepository.Save(mapper.Map<Favorites>(createFavorite));
      return favoriteModel;

    }

}