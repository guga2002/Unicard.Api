using FluentValidation;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.FluentValidates
{
    /// <summary>
    /// Validator for the UserDto class using FluentValidation.
    /// </summary>
    public class UserDtoValidations : AbstractValidator<UserDto>
    {
        public UserDtoValidations()
        {
            // Validation rules for UserDto properties
            RuleFor(dto => dto.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(dto => dto.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(dto => dto.Email).NotEmpty().WithMessage("Email is required")
                                      .EmailAddress().WithMessage("Invalid email address");
        }
    }
}
