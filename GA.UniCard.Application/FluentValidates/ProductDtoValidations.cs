using FluentValidation;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.FluentValidates
{
    /// <summary>
    /// Validator for the ProductDto class using FluentValidation.
    /// </summary>
    public class ProductDtoValidations : AbstractValidator<ProductDto>
    {
        /// <summary>
        /// Controller  for define Rules for vaidations
        /// </summary>
        public ProductDtoValidations()
        {
            RuleFor(dto => dto.ProductName).NotEmpty().WithMessage("Product name is required");
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(dto => dto.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
