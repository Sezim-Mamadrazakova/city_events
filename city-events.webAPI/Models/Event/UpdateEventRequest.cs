using FluentValidation;
using FluentValidation.Results;

namespace city_events.webAPI.Models;

public class UpdateEventRequest
{
    #region Model
    public string EventName {get;set;}
    public string EventPlace{get;set;}
    public DateTime DateStart{get;set;}
    public DateTime DateFinish{get;set;}

    #endregion

    #region Validator
     public class Validator: AbstractValidator<UpdateEventRequest>
     {
        public Validator()
        {
            RuleFor(x=>x.EventName)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x=>x.EventPlace)
                .MaximumLength(255).WithMessage("Length must be less than 256");
            RuleFor(x=>x.DateStart)
                .InclusiveBetween(DateTime.MinValue,DateTime.Today).WithMessage("Length must be less than 256");
            RuleFor(x=>x.DateFinish)
                .InclusiveBetween(DateTime.MinValue,DateTime.Today).WithMessage("Length must be less than 256");
        }

     }
     #endregion
}
public static class UpdateEventRequestExtension
{
    public static ValidationResult Validate(this UpdateEventRequest model)
    {
        return new UpdateEventRequest.Validator().Validate(model);
    }
}