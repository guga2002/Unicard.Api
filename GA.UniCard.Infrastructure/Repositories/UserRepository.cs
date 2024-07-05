using Dapper;
using GA.UniCard.Domain.Entitites;
using GA.UniCard.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA.UniCard.Infrastructure.Repositories
{
    public class UserRepository : AbstractRepository, IUserRepostory
    {
        public UserRepository(string ConnectionString) : base(ConnectionString)
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

                long orderId = await dbConnection.ExecuteScalarAsync<long>(query, new
                {
                    item.Email,
                    item.Password,
                    item.UserName,
                });
                return orderId;
            }
        }

        public async Task<bool> DeleteAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = "delete from Users where Id = @Id";

                var rowsAffected = await dbConnection.ExecuteAsync(query, new { Id = Id });

                return rowsAffected > 0;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = "select * from Users";

                var orders = await dbConnection.QueryAsync<User>(query);

                return orders;
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
    }
}
