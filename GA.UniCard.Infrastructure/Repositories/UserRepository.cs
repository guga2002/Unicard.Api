using Dapper;
using GA.UniCard.Domain.Entities;
using GA.UniCard.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GA.UniCard.Infrastructure.Repositories
{
    /// <summary>
    /// User repository Implementation
    /// </summary>
    public class UserRepository : AbstractRepository, IUserRepository
    {
        /// <summary>
        /// Constructor for User Repository
        /// </summary>
        /// <param name="config"></param>
        public UserRepository(IConfiguration config) : base(config)
        {
        }

        /// <summary>
        /// Adds a new User asynchronously.
        /// </summary>
        /// <param name="item">The User to add.</param>
        /// <returns>The Id of the newly added User.</returns>
        public async Task<long> AddAsync(User item)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = @"
                insert into Users (Email, Password, User_Name,PersonId)
                values (@Email, @Password, @UserName,@PersonId);
                select scope_identity();";

                long userId = await dbConnection.ExecuteScalarAsync<long>(query, new
                {
                    item.Email,
                    item.Password,
                    item.UserName,
                    item.PersonId,
                });

                return userId;
            }
        }

        /// <summary>
        /// Deletes a User asynchronously.
        /// </summary>
        /// <param name="Id">The Id of the User to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        public async Task<bool> DeleteAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = @"delete from Users where Id = @Id";

                var rowsAffected = await dbConnection.ExecuteAsync(query, new { Id });

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Retrieves all Users asynchronously.
        /// </summary>
        /// <returns>A collection of Users.</returns>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = @"SELECT [Id]
                               ,[User_Name] as UserName
                               ,[Password]
                               ,[Email]
                               ,PersonId
                                FROM Users";

                var users = await dbConnection.QueryAsync<User>(query);

                return users;
            }
        }

        /// <summary>
        /// Retrieves a User by Id asynchronously.
        /// </summary>
        /// <param name="Id">The Id of the User to retrieve.</param>
        /// <returns>The User if found, otherwise throws an exception.</returns>
        public async Task<User> GetByIdAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = "select * from Users where Id = @Id";

                var user = await dbConnection.QueryFirstOrDefaultAsync<User>(query, new { Id });

                if (user == null)
                {
                    throw new ArgumentNullException($"No user found with Id {Id}");
                }

                return user;
            }
        }

        /// <summary>
        /// Updates an existing User asynchronously.
        /// </summary>
        /// <param name="Id">The Id of the User to update.</param>
        /// <param name="item">The updated User object.</param>
        /// <returns>True if update is successful, otherwise false.</returns>
        public async Task<bool> UpdateAsync(long Id, User item)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string updateQuery = @"
                update Users
                set 
                    User_Name = @UserName,
                    Email = @Email,
                    Password = @Password,
                    PersonId =@PersonId,
                where Id = @Id";

                var rowsAffected = await dbConnection.ExecuteAsync(updateQuery, new
                {
                    item.UserName,
                    item.Email,
                    item.Password,
                    item.PersonId,
                    Id
                });

                return rowsAffected > 0;
            }
        }
    }
}
