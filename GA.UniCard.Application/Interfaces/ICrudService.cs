using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.Interfaces
{
    public interface ICrudService<T>where T:class
    {
        Task<bool> AddAsync(T order);
        Task<bool> DeleteAsync(long orderId);
        Task<bool> UpdateAsync(long id, T order);
    }
}
