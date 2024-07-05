using Dapper;
using GA.UniCard.Domain.Entities;
using GA.UniCard.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GA.UniCard.Infrastructure.Repositories
{
    /// <summary>
    /// Product repository 
    /// </summary>
    public class ProductRepository : AbstractRepository, IProductRepository
    { 
        /// <summary>
        /// Constructor for Product Class , for inicialize fields
        /// </summary>
        /// <param name="config"></param>
        public ProductRepository(IConfiguration config) : base(config)
        {
        }

        /// <summary>
        /// Adds a new Product asynchronously.
        /// </summary>
        /// <param name="item">The Product to add.</param>
        /// <returns>The Id of the newly added Product.</returns>
        public async Task<long> AddAsync(Product item)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = @"
                insert into Products (Product_Name, Product_Price, Product_Description)
                values (@ProductName, @Price, @Description);
                select scope_identity();";

                long productId = await dbConnection.ExecuteScalarAsync<long>(query, new
                {
                    item.ProductName,
                    item.Price,
                    item.Description,
                });

                return productId;
            }
        }

        /// <summary>
        /// Deletes a Product asynchronously.
        /// </summary>
        /// <param name="Id">The Id of the Product to delete.</param>
        /// <returns>True if deletion is successful, otherwise false.</returns>
        public async Task<bool> DeleteAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = "delete from Products where Id = @Id";

                var rowsAffected = await dbConnection.ExecuteAsync(query, new { Id });

                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Retrieves all Products asynchronously.
        /// </summary>
        /// <returns>A collection of Products.</returns>
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = @"SELECT [Id]
                                ,[Product_Name] as ProductName
                                ,[Product_Description] as Description
                                ,[Product_Price] as Price
                                  FROM Products";

                var products = await dbConnection.QueryAsync<Product>(query);

                return products;
            }
        }

        /// <summary>
        /// Retrieves a Product by Id asynchronously.
        /// </summary>
        /// <param name="Id">The Id of the Product to retrieve.</param>
        /// <returns>The Product if found, otherwise throws an exception.</returns>
        public async Task<Product> GetByIdAsync(long Id)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string query = @"SELECT [Id]
                                ,[Product_Name] as ProductName
                                ,[Product_Description] as Description
                                ,[Product_Price] as Price
                                 FROM Products 
								 where Id = @Id";

                var product = await dbConnection.QueryFirstOrDefaultAsync<Product>(query, new { Id });

                if (product == null)
                {
                    throw new ArgumentNullException($"No product found with Id {Id}");
                }

                return product;
            }
        }

        /// <summary>
        /// Updates an existing Product asynchronously.
        /// </summary>
        /// <param name="Id">The Id of the Product to update.</param>
        /// <param name="item">The updated Product object.</param>
        /// <returns>True if update is successful, otherwise false.</returns>
        public async Task<bool> UpdateAsync(long Id, Product item)
        {
            using (var dbConnection = new SqlConnection(ConnectionString))
            {
                await dbConnection.OpenAsync();

                string updateQuery = @"
                update Products
                set 
                    Product_Price = @Price,
                    Product_Name = @ProductName,
                    Product_Description = @Description
                where Id = @Id";

                var rowsAffected = await dbConnection.ExecuteAsync(updateQuery, new
                {
                    item.Price,
                    item.ProductName,
                    item.Description,
                    Id
                });

                return rowsAffected > 0;
            }
        }
    }
}
