namespace GA.UniCard.Domain.Interfaces
{
    public interface ICrudRepostiroey<T> where T : class
    {
        Task<long> AddAsync(T item);
        Task<bool> DeleteAsync(long Id);
        Task<T> GetByIdAsync(long Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> UpdateAsync(long Id,T item);
    }
}
