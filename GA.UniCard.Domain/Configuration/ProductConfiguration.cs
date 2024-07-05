using GA.UniCard.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GA.UniCard.Domain.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Random rand = new Random();
            builder.HasData(
                new Product() {Id=1,Price=rand.Next(10,100),ProductName="Milk",Description="THe milk is  good produce in mountins"},
                new Product() { Id = 2, Price = rand.Next(10, 100), ProductName = "Apple", Description = "The Apple is  good produce in mountins" },
                new Product() { Id = 3, Price = rand.Next(10, 100), ProductName = "Banana", Description = "THe Banana is  good produce in mountins" },
                new Product() { Id = 4, Price = rand.Next(10, 100), ProductName = "Bread", Description = "THe Bread is  good produce in mountins" },
                new Product() { Id = 5, Price = rand.Next(10, 100), ProductName = "Gold", Description = "THe Gold is  good produce in mountins" },
                new Product() { Id = 6, Price = rand.Next(10, 100), ProductName = "Fish", Description = "THe Fish is  good produce in mountins" },
                new Product() { Id = 7, Price = rand.Next(10, 100), ProductName = "Beans", Description = "THe Beans is  good produce in mountins" },
                new Product() { Id = 8, Price = rand.Next(10, 100), ProductName = "Suggar", Description = "THe Suggar is  good produce in mountins" }
                );
        }
    }
}
