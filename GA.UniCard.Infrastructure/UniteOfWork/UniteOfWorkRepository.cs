using GA.UniCard.Domain.Interfaces;
using GA.UniCard.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace GA.UniCard.Infrastructure.UniteOfWork
{
    /// <summary>
    /// Represents a Unit of Work pattern implementation for managing repositories.
    /// </summary>
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkRepository"/> class.
        /// </summary>
        /// <param name="config">The configuration instance.</param>
        public UnitOfWorkRepository(IConfiguration config)
        {
            _config = config;
        }

        private OrderRepository _orderRepository;

        /// <summary>
        /// Gets the repository instance for managing orders.
        /// </summary>
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_config);
                return _orderRepository;
            }
        }

        private OrderItemRepository _orderItemRepository;

        /// <summary>
        /// Gets the repository instance for managing order items.
        /// </summary>
        public IOrderItemRepository OrderItemRepository
        {
            get
            {
                if (_orderItemRepository == null)
                    _orderItemRepository = new OrderItemRepository(_config);
                return _orderItemRepository;
            }
        }

        private ProductRepository _productRepository;

        /// <summary>
        /// Gets the repository instance for managing products.
        /// </summary>
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_config);
                return _productRepository;
            }
        }

        private UserRepository _userRepository;

        /// <summary>
        /// Gets the repository instance for managing users.
        /// </summary>
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_config);
                return _userRepository;
            }
        }
    }
}
