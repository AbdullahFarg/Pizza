using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.CORE.DTOs;
using Pizza.CORE.Iterfaces;
using Pizza.CORE.Models;

namespace Pizza2.API.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost("createOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            await _orderRepository.CreateOrderAsync(dto);
            return Ok("Order is Created successfully");
        }
        [HttpGet("getAllOrder")]
        public async Task<IActionResult> GetAllOrders()
        {
            var temp = await _orderRepository.GetAllAsync();
            return Ok(temp);
        }
        
        [HttpDelete("DeleteOrder){id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var o = await _orderRepository.GetByOrderId(id);
            if(o == null) 
                return NotFound();
            _orderRepository.Delete(o);
            return Ok("Deleted successfully");
        }
        [HttpPut("updateOrder")]
        public async Task<IActionResult> UpdateOrder(int id , CreateOrderDto dto)
        {
            var o = await _orderRepository.GetByOrderId(id);
            if (o == null)
                return NotFound();
            o.Address = dto.Address;
            o.CustomerId = dto.CustomerId;
            o.OrderItems = dto.OrderItems
             .Select(oi => new OrderItem
             {
                 PizzaId = oi.PizzaId,
                 Quantity = oi.Quantity,
                 Size = oi.size,
             })
             .ToList();
            _orderRepository.Update(id , o);
            return Ok(o);
        }
    }

}
