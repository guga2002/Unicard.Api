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
    public class OrderItemServices : AbstractService, IOrderItemServices
    {
        private readonly OrderItemDtoValidator _validator;
        public OrderItemServices(IMapper mapper, IUniteOfWork work) : base(mapper, work)
        {
            this._validator = new OrderItemDtoValidator();
        }

        public async Task<bool> AddAsync(OrderItemDto orderitem)
        {
            var validationResult = _validator.Validate(orderitem);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var MappedorderItem = mapper.Map<OrderItem>(orderitem) ??
                throw new UniCardGeneralException(ErrorKeys.mapped);

            var result = await work.OrderItemRepository.AddAsync(MappedorderItem);
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

            var result = await work.OrderItemRepository.DeleteAsync(orderId);
            if (result)
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
        {
            var orderItems = await work.OrderItemRepository.GetAllAsync();
            if (!orderItems.Any())
            {
                throw new ItemNotFoundException(ErrorKeys.NoOrder);
            }

            var OrderitemsDto = mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
            if (OrderitemsDto == null)
            {
                throw new UniCardGeneralException(ErrorKeys.mapped);
            }

            return OrderitemsDto;
        }

        public async Task<OrderItemDto> GetByIdAsync(long Id)
        {
            var OrderItem = await work.OrderItemRepository.GetByIdAsync(Id) ??
                throw new ItemNotFoundException(ErrorKeys.NoOrder);
            var orderitemDto = mapper.Map<OrderItemDto>(OrderItem)??
                throw new UniCardGeneralException(ErrorKeys.mapped);
            return orderitemDto;
        }

        public async Task<bool> UpdateAsync(long id, OrderItemDto orderItem)
        {
            var validationResult = _validator.Validate(orderItem);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var MapepdOrderItem = mapper.Map<OrderItem>(orderItem) ??
                throw new UniCardGeneralException(ErrorKeys.mapped);
            var result = await work.OrderItemRepository.UpdateAsync(id, MapepdOrderItem);
            if (result)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsucessfullUpdate);
        }
    }
}
