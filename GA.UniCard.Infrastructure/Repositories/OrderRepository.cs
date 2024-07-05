using Dapper;
using GA.UniCard.Domain.Entities;
using GA.UniCard.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GA.UniCard.Infrastructure.Repositories
{
    /// <summary>
    /// Order repository implementation
    /// </summary>
    public class OrderRepository : AbstractRepository, IOrderRepository
    {
        /// <summary>
        /// Consftructor for inicialize
        /// </summary>
        /// <param name="config"></param>
        public OrderRepository(IConfiguration config) : base(config)
        {
        }

        /// <summary>
        /// Adds a new Order asynchronously.
        /// </summary>
        /// <param name="item">The Order to add.</param>
        /// <returns>The Id of the newly added Order.</returns>
        public async Task<long> AddAsync(Order item)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

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

        /// <summary>
        /// Deletes an Order asynchronously.
        /// </summary>
        /// <param name="Id">The Id of the Order to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        public async Task<bool> DeleteAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = "delete from orders where Id = @Id";

                var rowsAffected = await dbConnection.ExecuteAsync(query, new { Id });

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Retrieves all Orders asynchronously.
        /// </summary>
        /// <returns>A collection of Orders.</returns>
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = @"SELECT [Id]
                                ,[UserId]
                                ,[Ordering_Date] as OrderDate
                                ,[Total_Amount] as TotalAmount
                                 FROM  [Orders]";

                var orders = await dbConnection.QueryAsync<Order>(query);

                return orders;
            }
        }

        /// <summary>
        /// Retrieves an Order by Id asynchronously.
        /// </summary>
        /// <param name="Id">The Id of the Order to retrieve.</param>
        /// <returns>The Order if found, otherwise throws an exception.</returns>
        public async Task<Order> GetByIdAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = @"SELECT [Id]
                              ,[UserId]
                              ,[Ordering_Date] as OrderDate
                              ,[Total_Amount] as TotalAmount
                               FROM  [Orders]
                               where Id = @Id";

                var order = await dbConnection.QueryFirstOrDefaultAsync<Order>(query, new { Id });

                if (order == null)
                {
                    throw new ArgumentNullException($"No Order found with Id {Id}");
                }

                return order;
            }
        }

        /// <summary>
        /// Updates an existing Order asynchronously.
        /// </summary>
        /// <param name="Id">The Id of the Order to update.</param>
        /// <param name="item">The updated Order object.</param>
        /// <returns>True if update is successful, otherwise false.</returns>
        public async Task<bool> UpdateAsync(long Id, Order item)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string updateQuery = @"
                update Orders
                set 
                    Ordering_Date = @OrderDate,
                    UserId = @UserId,
                    Total_Amount = @TotalAmount
                where Id = @Id";

                var rowsAffected = await dbConnection.ExecuteAsync(updateQuery, new
                {
                    item.OrderDate,
                    item.UserId,
                    item.TotalAmount,
                    Id
                });

                return rowsAffected > 0;
            }
        }
    }
}
