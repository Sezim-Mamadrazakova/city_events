using FluentValidation;
using FluentValidation.Results;

namespace city_events.webAPI.Models;

public class UpdateCityRequest
{
    #region Model
     public string city {get;set;}

    #endregion

    #region Validator
     public class Validator: AbstractValidator<UpdateCityRequest>
     {
        public Validator()
        {
            RuleFor(x=>x.city)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }

     }
     #endregion
}
public static class UpdateCityRequestExtension
{
    public static ValidationResult Validate(this UpdateCityRequest model)
    {
        return new UpdateCityRequest.Validator().Validate(model);
    }
}