namespace GA.UniCard.Domain.Interfaces
{
    public interface ICrudRepostiroey<T> where T : class
    {
        Task Add(T item);
        Task Delete(T item);
        Task<T> GetById(long Id);
        Task<IEnumerable<T>> GetAll();
    }
}
