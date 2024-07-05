using FluentValidation;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.FluentValidates
{
    public class OrderItemDtoValidator:AbstractValidator<OrderItemDto>
    {
        public OrderItemDtoValidator()
        {
            RuleFor(dto => dto.OrderId).NotEmpty().WithMessage("Order id is required");
            RuleFor(dto => dto.ProductId).NotEmpty().WithMessage("Product id is required");
            RuleFor(dto => dto.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
            RuleFor(dto => dto.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
