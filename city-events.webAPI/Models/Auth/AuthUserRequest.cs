using FluentValidation;
using FluentValidation.Results;

namespace city_events.webAPI.Models;
public abstract class AuthUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }

    public class Validator : AbstractValidator<AuthUserRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Email)
                .MaximumLength(25).WithMessage("Length must be not great than 25")
                .MinimumLength(5).WithMessage("Length must be not less than 5");

            RuleFor(x => x.Password)
                .MaximumLength(16).WithMessage("Length must be not great than 16")
                .MinimumLength(7).WithMessage("Length must be not less than 7");
        }
    }
}

public static class AuthUserRequestExtension
{
    public static ValidationResult Validate(this AuthUserRequest model)
    {
        return new AuthUserRequest.Validator().Validate(model);
    }
}