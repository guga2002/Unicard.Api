using FluentValidation;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.FluentValidates
{
    /// <summary>
    /// Validator for the OrderItemDto class using FluentValidation.
    /// </summary>
    public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
    {
        /// <summary>
        /// Controller  for define Rules for vaidations
        /// </summary>
        public OrderItemDtoValidator()
        {
            RuleFor(dto => dto.OrderId).NotEmpty().WithMessage("Order ID is required");
            RuleFor(dto => dto.ProductId).NotEmpty().WithMessage("Product ID is required");
            RuleFor(dto => dto.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
            RuleFor(dto => dto.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
