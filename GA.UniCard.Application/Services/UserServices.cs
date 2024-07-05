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
    public class UserServices : AbstractService, IUserService
    {
        private readonly UserDtoValidations _validator;

        public UserServices(IMapper mapper, IUniteOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _validator = new UserDtoValidations();
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await work.UserRepostory.GetAllAsync();
            if (!users.Any())
            {
                throw new ItemNotFoundException(ErrorKeys.NoCustommer);
            }

            var userDtos = mapper.Map<IEnumerable<UserDto>>(users);
            if (userDtos == null)
            {
                throw new UniCardGeneralException(ErrorKeys.mapped);
            }

            return userDtos;
        }

        public async Task<UserDto> GetByIdAsync(long id)
        {
            var user = await work.UserRepostory.GetByIdAsync(id);
            if (user == null)
            {
                throw new ItemNotFoundException(ErrorKeys.NoCustommer);
            }

            var userDto = mapper.Map<UserDto>(user);
            if (userDto == null)
            {
                throw new UniCardGeneralException(ErrorKeys.mapped);
            }

            return userDto;
        }

        public async Task<bool> Register(UserDto userDto)
        {
            var validationResult = _validator.Validate(userDto);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var user = mapper.Map<User>(userDto);
            if (user == null)
            {
                throw new UniCardGeneralException(ErrorKeys.mapped);
            }

            var result = await work.UserRepostory.AddAsync(user);
            if (result > 0)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsuccesfullInsert);
        }

        public async Task<bool> RemoveUser(long id)
        {
            if (id < 0)
            {
                throw new UniCardGeneralException(ErrorKeys.InternalServerError);
            }

            var result = await work.UserRepostory.DeleteAsync(id);
            if (result)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync(long id, UserDto userDto)
        {
            var validationResult = _validator.Validate(userDto);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var user = mapper.Map<User>(userDto);
            if (user == null)
            {
                throw new UniCardGeneralException(ErrorKeys.mapped);
            }

            var result = await work.UserRepostory.UpdateAsync(id, user).ConfigureAwait(false);
            if (result)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsucessfullUpdate);
        }
    }
}
