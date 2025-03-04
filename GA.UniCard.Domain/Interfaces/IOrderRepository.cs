﻿using GA.UniCard.Domain.Entities;

namespace GA.UniCard.Domain.Interfaces
{
    /// <summary>
    /// Interface for order repository operations, inheriting CRUD operations.
    /// </summary>
    public interface IOrderRepository : ICrudRepository<Order>
    {
    }
}
