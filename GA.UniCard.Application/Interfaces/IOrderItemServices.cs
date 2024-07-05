﻿using GA.UniCard.Application.Interfaces.BasicOperations;
using GA.UniCard.Application.Models;

namespace GA.UniCard.Application.Interfaces
{
    public interface IOrderItemServices:IGetService<OrderItemDto>,ICrudService<OrderItemDto>
    {
    }
}
