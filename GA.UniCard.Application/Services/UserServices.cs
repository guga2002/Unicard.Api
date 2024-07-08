using AutoMapper;
using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.FluentValidates;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using GA.UniCard.Application.StatickFiles;
using GA.UniCard.Domain.Entities;
using GA.UniCard.Domain.Interfaces;

namespace GA.UniCard.Application.Services
{
    /// <summary>
    /// Service class for managing operations related to users.
    /// </summary>
    public class UserServices : AbstractService, IUserService
    {
        private readonly UserDtoValidations _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserServices"/> class with required dependencies.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for object mapping.</param>
        /// <param name="unitOfWork">The unit of work instance for data operations.</param>
        public UserServices(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _validator = new UserDtoValidations();
        }

        /// <summary>
        /// Retrieves all users asynchronously.
        /// </summary>
        /// <returns>A collection of user DTOs.</returns>
        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await work.UserRepository.GetAllAsync();
            if (!users.Any())
            {
                throw new ItemNotFoundException(ErrorKeys.NoCustomer);
            }

            var userDtos = mapper.Map<IEnumerable<UserDto>>(users);
            if (userDtos == null)
            {
                throw new UniCardGeneralException(ErrorKeys.Mapped);
            }

            return userDtos;
        }

        /// <summary>
        /// Retrieves a user by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user DTO if found, otherwise throws an exception.</returns>
        public async Task<UserDto> GetByIdAsync(long id)
        {
            var user = await work.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new ItemNotFoundException(ErrorKeys.NoCustomer);
            }

            var userDto = mapper.Map<UserDto>(user);
            if (userDto == null)
            {
                throw new UniCardGeneralException(ErrorKeys.Mapped);
            }

            return userDto;
        }

        /// <summary>
        /// Registers a new user asynchronously.
        /// </summary>
        /// <param name="userDto">The user DTO to register.</param>
        /// <returns>True if the registration was successful, otherwise false.</returns>
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
                throw new UniCardGeneralException(ErrorKeys.Mapped);
            }

            var result = await work.UserRepository.AddAsync(user);
            if (result > 0)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsuccesfullInsert);
        }

        /// <summary>
        /// Removes a user asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user to remove.</param>
        /// <returns>True if the removal was successful, otherwise false.</returns>
        public async Task<bool> RemoveUser(long id)
        {
            if (id < 0)
            {
                throw new UniCardGeneralException(ErrorKeys.InternalServerError);
            }

            var result = await work.UserRepository.DeleteAsync(id);
            if (result)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Updates an existing user asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="userDto">The updated user DTO.</param>
        /// <returns>True if the update was successful, otherwise false.</returns>
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
                throw new UniCardGeneralException(ErrorKeys.Mapped);
            }

            var result = await work.UserRepository.UpdateAsync(id, user).ConfigureAwait(false);
            if (result)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsucessfullUpdate);
        }
    }
}
