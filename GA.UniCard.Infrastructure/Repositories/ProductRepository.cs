using Dapper;
using GA.UniCard.Domain.Entitites;
using GA.UniCard.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace GA.UniCard.Infrastructure.Repositories
{
    public class ProductRepository : AbstractRepository, IProductRepository
    {
        public ProductRepository(string ConnectionString) : base(ConnectionString)
        {
        }

        public async Task<long> AddAsync(Product item)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = @"
                insert into Products (Product_Name, Product_Price, Product_Description)
                values (@ProductName, @Price, @Description);
                select scope_identity();";

                long orderId = await dbConnection.ExecuteScalarAsync<long>(query, new
                {
                    item.ProductName,
                    item.Price,
                    item.Description,
                });
                return orderId;
            }
        }

        public async Task<bool> DeleteAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = "delete from Products where Id = @Id";

                var rowsAffected = await dbConnection.ExecuteAsync(query, new { Id = Id });

                return rowsAffected > 0;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = "select * from Products";

                var orders = await dbConnection.QueryAsync<Product>(query);

                return orders;
            }
        }

        public async Task<Product> GetByIdAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(this.ConnectionString))
            {
                dbConnection.Open();

                string query = "select * from Products where Id = @Id";

                var user = await dbConnection.QueryFirstOrDefaultAsync<Product>(query, new { Id = Id }) ??
                    throw new ArgumentNullException("No product found on this Id");

                return user;
            }
        }
    }
}
