using FluentValidation;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.FluentValidates
{
    /// <summary>
    /// Validator for the OrderDto class using FluentValidation.
    /// </summary>
    public class OrderDtoValidations : AbstractValidator<OrderDto>
    {
        public OrderDtoValidations()
        {
            // Validation rules for OrderDto properties
            RuleFor(dto => dto.UserId).NotEmpty().WithMessage("User ID is required");
            RuleFor(dto => dto.OrderDate).NotEmpty().WithMessage("Order date is required");
            RuleFor(dto => dto.TotalAmount).GreaterThan(0).WithMessage("Total amount must be greater than 0");
        }
    }
}
