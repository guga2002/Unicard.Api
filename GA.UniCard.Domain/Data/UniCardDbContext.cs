using GA.UniCard.Domain.Configuration;
using GA.UniCard.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GA.UniCard.Domain.Data
{
    /// <summary>
    /// Represents the database context for UniCard application, derived from DbContext.
    /// </summary>
    public class UniCardDbContext : IdentityDbContext<Person>
    {
        /// <summary>
        /// Initializes a new instance of the UniCardDbContext class.
        /// </summary>
        /// <param name="options">The DbContextOptions to be used by the context.</param>
        public UniCardDbContext(DbContextOptions<UniCardDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet of Users in the database.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of OrderItems in the database.
        /// </summary>
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of Orders in the database.
        /// </summary>
        public virtual DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of Products in the database.
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// Configures the model for the UniCardDbContext using the provided modelBuilder.
        /// </summary>
        /// <param name="modelBuilder">The ModelBuilder instance to configure the context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
