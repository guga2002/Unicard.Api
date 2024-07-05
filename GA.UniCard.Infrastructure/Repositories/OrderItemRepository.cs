﻿using Dapper;
using GA.UniCard.Domain.Entitites;
using GA.UniCard.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GA.UniCard.Infrastructure.Repositories
{
    public class OrderItemRepository : AbstractRepository, IOrderItemRepository
    {
        public OrderItemRepository(string ConnectionString) : base(ConnectionString)
        {
        }

        public async Task<long> AddAsync(OrderItem item)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = @"
                insert into OrderItems (ProductId, OrderId, Item_Quantity,Item_Price)
                values (@ProductId, @OrderId, @Quantity,@Price);
                select scope_identity();";

                long orderId = await dbConnection.ExecuteScalarAsync<long>(query, new
                {
                    item.ProductId,
                    item.OrderId,
                    item.Quantity,
                    item.Price,
                });

                return orderId;
            }
        }

        public async Task<bool> DeleteAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = "delete from OrderItems where Id = @Id";

                var rowsAffected = await dbConnection.ExecuteAsync(query, new { Id = Id });

                return rowsAffected > 0;
            }
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = "select * from OrderItems";

                var orderitems = await dbConnection.QueryAsync<OrderItem>(query);

                return orderitems;
            }
        }

        public async Task<OrderItem> GetByIdAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = "select * from OrderItems where Id = @Id";

                var orderItem = await dbConnection.QueryFirstOrDefaultAsync<OrderItem>(query, new { Id = Id }) ??
                    throw new ArgumentNullException("No OrderItem found on this Id");
                return orderItem;
            }
        }
    }
}
