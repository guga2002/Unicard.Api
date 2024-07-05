using FluentValidation;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.FluentValidates
{
    public class ProductDtoValidations:AbstractValidator<ProductDto>
    {
        public ProductDtoValidations()
        {
            RuleFor(dto => dto.ProductName).NotEmpty().WithMessage("Product name is required");
            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(dto => dto.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
