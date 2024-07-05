using Dapper;
using GA.UniCard.Domain.Entitites;
using GA.UniCard.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GA.UniCard.Infrastructure.Repositories
{
    public class UserRepository : AbstractRepository, IUserRepostory
    {
        public UserRepository(IConfiguration Config) : base(Config)
        {
        }

        public async Task<long> AddAsync(User item)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = @"
                insert into Users (Email, Password, User_Name)
                values (@Email, @Password, @UserName);
                select scope_identity();";

                long userId = await dbConnection.ExecuteScalarAsync<long>(query, new
                {
                    item.Email,
                    item.Password,
                    item.UserName,
                });
                return userId;
            }
        }

        public async Task<bool> DeleteAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = @"SELECT [Id]
                              ,[User_Name] as UserName
                              ,[Password]
                              ,[Email]
                              FROM [Users]
                              where Id = @Id";

                var rowsAffected = await dbConnection.ExecuteAsync(query, new { Id = Id });

                return rowsAffected > 0;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = @"SELECT [Id]
                               ,[User_Name] as UserName
                               ,[Password]
                               ,[Email]
                                FROM [Users]";

                var users = await dbConnection.QueryAsync<User>(query);

                return users;
            }
        }

        public async Task<User> GetByIdAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = "select * from Users where Id = @Id";

                var user = await dbConnection.QueryFirstOrDefaultAsync<User>(query, new { Id = Id }) ??
                    throw new ArgumentNullException("No User found on this Id");

                return user;
            }
        }

        public async Task<bool> UpdateAsync(long Id, User item)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string updateQuery = @"
                update Users
                set 
                    User_Name = @UserName,
                    Email = @Email,
                    Password = @Password
                where Id = @Id";

                long rowsAffected = await dbConnection.ExecuteAsync(updateQuery, new
                {
                    item.UserName,
                    item.Email,
                    item.Password,
                    Id
                });
                return rowsAffected > 0;
            }
        }
    }
}
