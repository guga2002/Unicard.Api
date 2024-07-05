using GA.UniCard.Application.Interfaces.BasicOperations;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.Interfaces
{
    public interface IUserService:IGetService<UserDto>
    {
        Task<bool> Register(UserDto user);
        Task<bool> RemoveUser(long id);
        Task<bool> UpdateAsync(long id, UserDto user);
    }
}
