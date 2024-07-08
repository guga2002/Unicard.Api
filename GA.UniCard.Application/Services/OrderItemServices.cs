using AutoMapper;
using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.FluentValidates;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using GA.UniCard.Application.StatickFiles;
using GA.UniCard.Domain.Entities;
using GA.UniCard.Domain.Interfaces;

namespace GA.UniCard.Application.Services
{
    /// <summary>
    /// Service class for managing operations related to order items.
    /// </summary>
    public class OrderItemServices : AbstractService, IOrderItemServices
    {
        private readonly OrderItemDtoValidator _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderItemServices"/> class with required dependencies.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for object mapping.</param>
        /// <param name="work">The unit of work instance for data operations.</param>
        public OrderItemServices(IMapper mapper, IUnitOfWork work) : base(mapper, work)
        {
            this._validator = new OrderItemDtoValidator();
        }

        /// <summary>
        /// Adds a new order item asynchronously.
        /// </summary>
        /// <param name="orderItem">The order item DTO to add.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public async Task<bool> AddAsync(OrderItemDto orderItem)
        {
            ArgumentNullException.ThrowIfNull(orderItem);
            var validationResult = _validator.Validate(orderItem);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }
            var order=await work.OrderRepository.GetByIdAsync(orderItem.OrderId);
            var product=await work.ProductRepository.GetByIdAsync(orderItem.ProductId);

            if(product is null) throw new UniCardGeneralException(ErrorKeys.NoProduct);

            if(order is null)throw new UniCardGeneralException(ErrorKeys.NoOrder);

            var mappedOrderItem = mapper.Map<OrderItem>(orderItem) ??
                throw new UniCardGeneralException(ErrorKeys.Mapped);

            var result = await work.OrderItemRepository.AddAsync(mappedOrderItem);
            if (result > 0)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsuccesfullInsert);
        }

        /// <summary>
        /// Deletes an order item asynchronously.
        /// </summary>
        /// <param name="orderId">The ID of the order item to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public async Task<bool> DeleteAsync(long orderId)
        {
            if (orderId < 0)
            {
                throw new UniCardGeneralException(ErrorKeys.InternalServerError);
            }

            var result = await work.OrderItemRepository.DeleteAsync(orderId);
            if (result)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves all order items asynchronously.
        /// </summary>
        /// <returns>A collection of order item DTOs.</returns>
        public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
        {
            var orderItems = await work.OrderItemRepository.GetAllAsync();
            if (!orderItems.Any())
            {
                throw new ItemNotFoundException(ErrorKeys.NoOrder);
            }

            var orderItemsDto = mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
            if (orderItemsDto == null)
            {
                throw new UniCardGeneralException(ErrorKeys.Mapped);
            }

            return orderItemsDto;
        }

        /// <summary>
        /// Retrieves an order item by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the order item to retrieve.</param>
        /// <returns>The order item DTO if found, otherwise throws an exception.</returns>
        public async Task<OrderItemDto> GetByIdAsync(long id)
        {
            var orderItem = await work.OrderItemRepository.GetByIdAsync(id) ??
                throw new ItemNotFoundException(ErrorKeys.NoOrder);

            var orderItemDto = mapper.Map<OrderItemDto>(orderItem) ??
                throw new UniCardGeneralException(ErrorKeys.Mapped);

            return orderItemDto;
        }

        /// <summary>
        /// Updates an existing order item asynchronously.
        /// </summary>
        /// <param name="id">The ID of the order item to update.</param>
        /// <param name="orderItem">The updated order item DTO.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public async Task<bool> UpdateAsync(long id, OrderItemDto orderItem)
        {
            ArgumentNullException.ThrowIfNull(orderItem);
            var validationResult = _validator.Validate(orderItem);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }
            var order = await work.OrderRepository.GetByIdAsync(orderItem.OrderId);
            var product = await work.ProductRepository.GetByIdAsync(orderItem.ProductId);

            if (product is null) throw new UniCardGeneralException(ErrorKeys.NoProduct);

            if (order is null) throw new UniCardGeneralException(ErrorKeys.NoOrder);

            var mappedOrderItem = mapper.Map<OrderItem>(orderItem) ??
                throw new UniCardGeneralException(ErrorKeys.Mapped);

            var result = await work.OrderItemRepository.UpdateAsync(id, mappedOrderItem);
            if (result)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsucessfullUpdate);
        }
    }
}
