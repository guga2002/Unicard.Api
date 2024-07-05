using Dapper;
using GA.UniCard.Domain.Entitites;
using GA.UniCard.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GA.UniCard.Infrastructure.Repositories
{
    public class OrderRepository : AbstractRepository, IOrderRepository
    {
        public OrderRepository(string ConnectionString) : base(ConnectionString)
        {
        }

        public async Task<long> AddAsync(Order item)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = @"
                insert into orders (UserId, Ordering_Date, Total_Amount)
                values (@UserId, @OrderDate, @TotalAmount);
                select scope_identity();";

                long orderId = await dbConnection.ExecuteScalarAsync<long>(query, new
                {
                    item.UserId,
                    item.OrderDate,
                    item.TotalAmount,
                });

                return orderId;
            }
        }

        public async Task<bool> DeleteAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = "delete from orders where Id = @Id";

                var rowsAffected = await dbConnection.ExecuteAsync(query, new { Id = Id });

                return rowsAffected > 0;
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = "select * from Orders";

                var orders = await dbConnection.QueryAsync<Order>(query);

                return orders;
            }
        }

        public async Task<Order> GetByIdAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = "select * from orders where Id = @Id";

                var order = await dbConnection.QueryFirstOrDefaultAsync<Order>(query, new { Id = Id }) ??
                    throw new ArgumentNullException("No Order found on this Id");
                return order;
            }
        }
    }
}
