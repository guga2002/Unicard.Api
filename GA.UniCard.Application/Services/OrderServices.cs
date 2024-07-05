using AutoMapper;
using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.FluentValidates;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using GA.UniCard.Application.StatickFiles;
using GA.UniCard.Domain.Entitites;
using GA.UniCard.Domain.Interfaces;

namespace GA.UniCard.Application.Services
{
    public class OrderServices : AbstractService, IOrderService
    {
        private readonly OrderDtoValidations _validator;
        public OrderServices(IMapper mapper, IUniteOfWork work) : base(mapper, work)
        {
            this._validator = new OrderDtoValidations();
        }

        public async Task<bool> AddAsync(OrderDto order)
        {

            var validationResult = _validator.Validate(order);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var MappedOrder = mapper.Map<Order>(order)??
                throw new UniCardGeneralException(ErrorKeys.mapped);

            var result = await work.OrderRepository.AddAsync(MappedOrder);
            if (result > 0)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsuccesfullInsert);
        }

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

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var Orders = await work.OrderRepository.GetAllAsync();
            if (!Orders.Any())
            {
                throw new ItemNotFoundException(ErrorKeys.NoOrder);
            }

            var OrdersDto = mapper.Map<IEnumerable<OrderDto>>(Orders);
            if (OrdersDto == null)
            {
                throw new UniCardGeneralException(ErrorKeys.mapped);
            }

            return OrdersDto;
        }

        public async Task<OrderDto> GetByIdAsync(long Id)
        {
            var Order = await work.OrderRepository.GetByIdAsync(Id)??
                throw new ItemNotFoundException(ErrorKeys.NoOrder);
            var orderDto = mapper.Map<OrderDto>(Order);
            if (orderDto == null)
            {
                throw new UniCardGeneralException(ErrorKeys.mapped);
            }

            return orderDto;
        }

        public async Task<bool> UpdateAsync(long id, OrderDto order)
        {
            var validationResult = _validator.Validate(order);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var MapepdOrder = mapper.Map<Order>(order)??
                throw new UniCardGeneralException(ErrorKeys.mapped);
            var result = await work.OrderRepository.UpdateAsync(id, MapepdOrder);
            if (result)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsucessfullUpdate);
        }
    }
}
