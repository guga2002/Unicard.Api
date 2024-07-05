using Dapper;
using GA.UniCard.Domain.Entities;
using GA.UniCard.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GA.UniCard.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing OrderItem entities using Dapper.
    /// </summary>
    public class OrderItemRepository : AbstractRepository, IOrderItemRepository
    {
        /// <summary>
        /// Controler for inicialize
        /// </summary>
        /// <param name="config"></param>
        public OrderItemRepository(IConfiguration config) : base(config)
        {
        }

        /// <summary>
        /// Adds a new OrderItem asynchronously.
        /// </summary>
        /// <param name="item">The OrderItem to add.</param>
        /// <returns>The Id of the newly added OrderItem.</returns>
        public async Task<long> AddAsync(OrderItem item)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = @"
                insert into OrderItems (ProductId, OrderId, Item_Quantity, Item_Price)
                values (@ProductId, @OrderId, @Quantity, @Price);
                select scope_identity();";

                long orderItemId = await dbConnection.ExecuteScalarAsync<long>(query, new
                {
                    item.ProductId,
                    item.OrderId,
                    item.Quantity,
                    item.Price,
                });

                return orderItemId;
            }
        }

        /// <summary>
        /// Deletes an OrderItem asynchronously.
        /// </summary>
        /// <param name="Id">The Id of the OrderItem to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        public async Task<bool> DeleteAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = "delete from OrderItems where Id = @Id";

                var rowsAffected = await dbConnection.ExecuteAsync(query, new { Id });

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Retrieves all OrderItems asynchronously.
        /// </summary>
        /// <returns>A collection of OrderItems.</returns>
        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = @"SELECT [Id]
                                ,[OrderId]
                                ,[ProductId]
                                ,[Item_Quantity] as Quantity
                                ,[Item_Price] as Price
                                 FROM OrderItems";

                var orderItems = await dbConnection.QueryAsync<OrderItem>(query);

                return orderItems;
            }
        }

        /// <summary>
        /// Retrieves an OrderItem by Id asynchronously.
        /// </summary>
        /// <param name="Id">The Id of the OrderItem to retrieve.</param>
        /// <returns>The OrderItem if found, otherwise throws an exception.</returns>
        public async Task<OrderItem> GetByIdAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = @"SELECT [Id]
                                ,[OrderId]
                                ,[ProductId]
                                ,[Item_Quantity] as Quantity
                                ,[Item_Price] as Price
                                 FROM OrderItems
                                 where Id = @Id";

                var orderItem = await dbConnection.QueryFirstOrDefaultAsync<OrderItem>(query, new { Id });

                if (orderItem == null)
                {
                    throw new ArgumentNullException($"No OrderItem found with Id {Id}");
                }

                return orderItem;
            }
        }

        /// <summary>
        /// Updates an existing OrderItem asynchronously.
        /// </summary>
        /// <param name="Id">The Id of the OrderItem to update.</param>
        /// <param name="item">The updated OrderItem object.</param>
        /// <returns>True if update is successful, otherwise false.</returns>
        public async Task<bool> UpdateAsync(long Id, OrderItem item)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string updateQuery = @"
                update OrderItems
                set 
                    ProductId = @ProductId,
                    OrderId = @OrderId,
                    Item_Quantity = @Quantity,
                    Item_Price = @Price
                where Id = @Id";

                var rowsAffected = await dbConnection.ExecuteAsync(updateQuery, new
                {
                    item.ProductId,
                    item.OrderId,
                    item.Quantity,
                    item.Price,
                    Id
                });

                return rowsAffected > 0;
            }
        }
    }
}
