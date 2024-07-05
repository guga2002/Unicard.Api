using GA.UniCard.Application.Interfaces.BasicOperations;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.Interfaces
{
    public interface IOrderService:IGetService<OrderDto>,ICrudService<OrderDto>
    {
    }
}
