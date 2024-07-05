using GA.UniCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GA.UniCard.Domain.Configuration
{
    /// <summary>
    /// Configuration for the Product entity using Entity Framework Core.
    /// </summary>
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Configures the Product entity.
        /// </summary>
        /// <param name="builder">The entity type builder used to configure the entity.</param>
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Random rand = new Random();

            // Seed data for Products
            builder.HasData(
                new Product() { Id = 1, Price = rand.Next(10, 100), ProductName = "Milk", Description = "The milk is good produce in mountains" },
                new Product() { Id = 2, Price = rand.Next(10, 100), ProductName = "Apple", Description = "The Apple is good produce in mountains" },
                new Product() { Id = 3, Price = rand.Next(10, 100), ProductName = "Banana", Description = "The Banana is good produce in mountains" },
                new Product() { Id = 4, Price = rand.Next(10, 100), ProductName = "Bread", Description = "The Bread is good produce in mountains" },
                new Product() { Id = 5, Price = rand.Next(10, 100), ProductName = "Gold", Description = "The Gold is good produce in mountains" },
                new Product() { Id = 6, Price = rand.Next(10, 100), ProductName = "Fish", Description = "The Fish is good produce in mountains" },
                new Product() { Id = 7, Price = rand.Next(10, 100), ProductName = "Beans", Description = "The Beans is good produce in mountains" },
                new Product() { Id = 8, Price = rand.Next(10, 100), ProductName = "Sugar", Description = "The Sugar is good produce in mountains" }
            );
        }
    }
}
