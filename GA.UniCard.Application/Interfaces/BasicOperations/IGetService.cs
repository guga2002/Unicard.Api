namespace GA.UniCard.Application.Interfaces.BasicOperations
{
    public interface IGetService<T>where T : class
    {
        Task<T> GetByIdAsync(long Id);

        Task<IEnumerable<T>> GetAllAsync();
    }
}
