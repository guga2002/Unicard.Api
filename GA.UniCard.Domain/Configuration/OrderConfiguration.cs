using GA.UniCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GA.UniCard.Domain.Configuration
{
    /// <summary>
    /// Configures the entity framework mapping and seed data for the Order entity.
    /// </summary>
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        /// <summary>
        /// Configures the mapping and seeding of the Order entity.
        /// </summary>
        /// <param name="builder">The entity type builder for the Order entity.</param>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            Random rand = new Random();

            // Seed data for Orders table
            builder.HasData(
                new Order() { OrderDate = DateTime.Now.AddDays(-rand.Next(10, 100)), TotalAmount = rand.Next(100, 1000), UserId = 1, Id = 1 },
                new Order() { OrderDate = DateTime.Now.AddDays(-rand.Next(10, 100)), TotalAmount = rand.Next(100, 1000), UserId = 2, Id = 2 },
                new Order() { OrderDate = DateTime.Now.AddDays(-rand.Next(10, 100)), TotalAmount = rand.Next(100, 1000), UserId = 3, Id = 3 },
                new Order() { OrderDate = DateTime.Now.AddDays(-rand.Next(10, 100)), TotalAmount = rand.Next(100, 1000), UserId = 4, Id = 4 },
                new Order() { OrderDate = DateTime.Now.AddDays(-rand.Next(10, 100)), TotalAmount = rand.Next(100, 1000), UserId = 5, Id = 5 },
                new Order() { OrderDate = DateTime.Now.AddDays(-rand.Next(10, 100)), TotalAmount = rand.Next(100, 1000), UserId = 6, Id = 6 }
            );
        }
    }
}
