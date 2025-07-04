﻿using Pizza.CORE.DTOs;
using Pizza.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.Iterfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetByUserId(int id);
        Task CreateOrderAsync(CreateOrderDto dto);
        Task<Order?> GetByOrderId(int id);
        Task<string> GetOrderStatus(int id);
    }
}
