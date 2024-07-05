using GA.UniCard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GA.UniCard.Domain.Configuration
{
    /// <summary>
    /// Configures the entity framework mapping and seed data for the OrderItem entity.
    /// </summary>
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        /// <summary>
        /// Configures the mapping and seeding of the OrderItem entity.
        /// </summary>
        /// <param name="builder">The entity type builder for the OrderItem entity.</param>
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            Random rand = new Random();

            // Seed data for OrderItems table
            builder.HasData(
                new OrderItem() { Id = 1, OrderId = 1, Price = rand.Next(10, 100), ProductId = 1, Quantity = rand.Next(1, 10) },
                new OrderItem() { Id = 2, OrderId = 2, Price = rand.Next(10, 100), ProductId = 2, Quantity = rand.Next(1, 10) },
                new OrderItem() { Id = 3, OrderId = 3, Price = rand.Next(10, 100), ProductId = 3, Quantity = rand.Next(1, 10) },
                new OrderItem() { Id = 4, OrderId = 4, Price = rand.Next(10, 100), ProductId = 4, Quantity = rand.Next(1, 10) },
                new OrderItem() { Id = 5, OrderId = 5, Price = rand.Next(10, 100), ProductId = 5, Quantity = rand.Next(1, 10) },
                new OrderItem() { Id = 6, OrderId = 3, Price = rand.Next(10, 100), ProductId = 2, Quantity = rand.Next(1, 10) },
                new OrderItem() { Id = 7, OrderId = 6, Price = rand.Next(10, 100), ProductId = 4, Quantity = rand.Next(1, 10) }
            );
        }
    }
}
