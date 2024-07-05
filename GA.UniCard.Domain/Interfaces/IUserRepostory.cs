using GA.UniCard.Domain.Entities;

namespace GA.UniCard.Domain.Interfaces
{
    /// <summary>
    /// Interface for user repository operations, inheriting CRUD operations.
    /// </summary>
    public interface IUserRepository : ICrudRepository<User>
    {
    }
}
