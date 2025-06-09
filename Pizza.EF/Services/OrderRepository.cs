using Microsoft.EntityFrameworkCore;
using Pizza.CORE.DTOs;
using Pizza.CORE.Iterfaces;
using Pizza.CORE.Models;
using Pizza.EF.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.EF.Services
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Order?> GetByOrderId(int id)
        {
            return await _dbset
                 .Include(o => o.OrderItems)
                     .ThenInclude(oi => oi.Pizza)   
                 .Include(o => o.Customer)
                 .FirstOrDefaultAsync(o => o.Id == id);

        }
        public async Task CreateOrderAsync(CreateOrderDto dto)
        {
            
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var order = new Order
            {
                Address = dto.Address,
                CustomerId = dto.CustomerId,
                OrderItems = new List<OrderItem>()
            };
            decimal sum = 0;
            foreach (var item in dto.OrderItems)
            {
                var pizza = await _context.Pizzas.FindAsync(item.PizzaId);
                if (pizza == null)
                    throw new Exception($"Pizza with ID {item.PizzaId} not found.");
                decimal price = pizza.Price;
                sum += price * item.Quantity;

                var orderItem = new OrderItem
                {
                    PizzaId = item.PizzaId,
                    Quantity = item.Quantity,
                    Size = item.size,
                    TotalPrice = price * item.Quantity
                    
                };
                sum += orderItem.TotalPrice;
                order.OrderItems.Add(orderItem);
                
            }
            order.TotalPrice = sum;
            await _dbset.AddAsync(order);
            await SaveChangesAsync();
        }

    }
}
