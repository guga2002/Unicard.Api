namespace GA.UniCard.Domain.Interfaces
{
    /// <summary>
    /// Interface for the Unit of Work pattern, providing access to repositories for various entities.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Repository for orders.
        /// </summary>
        public IOrderRepository OrderRepository { get; }

        /// <summary>
        /// Repository for order items.
        /// </summary>
        public IOrderItemRepository OrderItemRepository { get; }

        /// <summary>
        /// Repository for users.
        /// </summary>
        public IUserRepository UserRepository { get; }

        /// <summary>
        /// Repository for products.
        /// </summary>
        public IProductRepository ProductRepository { get; }
    }
}
