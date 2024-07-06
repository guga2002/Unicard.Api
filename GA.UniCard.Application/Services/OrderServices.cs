using AutoMapper;
using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.FluentValidates;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using GA.UniCard.Application.StaticFiles;
using GA.UniCard.Domain.Entities;
using GA.UniCard.Domain.Interfaces;

namespace GA.UniCard.Application.Services
{
    /// <summary>
    /// Service class for managing operations related to orders.
    /// </summary>
    public class OrderServices : AbstractService, IOrderService
    {
        private readonly OrderDtoValidations _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderServices"/> class with required dependencies.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for object mapping.</param>
        /// <param name="work">The unit of work instance for data operations.</param>
        public OrderServices(IMapper mapper, IUnitOfWork work) : base(mapper, work)
        {
            this._validator = new OrderDtoValidations();
        }

        /// <summary>
        /// Adds a new order asynchronously.
        /// </summary>
        /// <param name="order">The order DTO to add.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public async Task<bool> AddAsync(OrderDto order)
        {
            var validationResult = _validator.Validate(order);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var user= await work.UserRepository.GetByIdAsync(order.UserId);
            if (user is null) throw new UniCardGeneralException(ErrorKeys.NoCustomer);


            var mappedOrder = mapper.Map<Order>(order) ??
                throw new UniCardGeneralException(ErrorKeys.Mapped);

            var result = await work.OrderRepository.AddAsync(mappedOrder);
            if (result > 0)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsuccesfullInsert);
        }

        /// <summary>
        /// Deletes an order asynchronously.
        /// </summary>
        /// <param name="orderId">The ID of the order to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public async Task<bool> DeleteAsync(long orderId)
        {
            if (orderId < 0)
            {
                throw new UniCardGeneralException(ErrorKeys.InternalServerError);
            }

            var result = await work.OrderRepository.DeleteAsync(orderId);
            if (result)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves all orders asynchronously.
        /// </summary>
        /// <returns>A collection of order DTOs.</returns>
        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await work.OrderRepository.GetAllAsync();
            if (!orders.Any())
            {
                throw new ItemNotFoundException(ErrorKeys.NoOrder);
            }

            var ordersDto = mapper.Map<IEnumerable<OrderDto>>(orders);
            if (ordersDto == null)
            {
                throw new UniCardGeneralException(ErrorKeys.Mapped);
            }

            return ordersDto;
        }

        /// <summary>
        /// Retrieves an order by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the order to retrieve.</param>
        /// <returns>The order DTO if found, otherwise throws an exception.</returns>
        public async Task<OrderDto> GetByIdAsync(long id)
        {
            var order = await work.OrderRepository.GetByIdAsync(id) ??
                throw new ItemNotFoundException(ErrorKeys.NoOrder);

            var orderDto = mapper.Map<OrderDto>(order);
            if (orderDto == null)
            {
                throw new UniCardGeneralException(ErrorKeys.Mapped);
            }

            return orderDto;
        }

        /// <summary>
        /// Updates an existing order asynchronously.
        /// </summary>
        /// <param name="id">The ID of the order to update.</param>
        /// <param name="order">The updated order DTO.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public async Task<bool> UpdateAsync(long id, OrderDto order)
        {
            var validationResult = _validator.Validate(order);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var user = await work.UserRepository.GetByIdAsync(order.UserId);
            if (user is null) throw new UniCardGeneralException(ErrorKeys.NoCustomer);

            var mappedOrder = mapper.Map<Order>(order) ??
                throw new UniCardGeneralException(ErrorKeys.Mapped);

            var result = await work.OrderRepository.UpdateAsync(id, mappedOrder);
            if (result)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsucessfullUpdate);
        }
    }
}
