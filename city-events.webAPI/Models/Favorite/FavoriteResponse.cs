using FluentValidation;
using FluentValidation.Results;
namespace city_events.webAPI.Models;
public class FavotiteResponses{
    #region Model
    public virtual Guid UserId{get;set;}
    public virtual Guid EventsId{get;set;}
    #endregion
}