using FluentValidation;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.FluentValidates
{
    /// <summary>
    /// Validator for the UserDto class using FluentValidation.
    /// </summary>
    public class UserDtoValidations : AbstractValidator<UserDto>
    {
        /// <summary>
        /// Controller  for define Rules for vaidations
        /// </summary>
        public UserDtoValidations()
        {
            RuleFor(dto => dto.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(dto => dto.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(dto => dto.Email).NotEmpty().WithMessage("Email is required")
                                      .EmailAddress().WithMessage("Invalid email address");
        }
    }
}
