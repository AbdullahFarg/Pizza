using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.CORE.DTOs;
using Pizza.CORE.Iterfaces;
using Pizza.CORE.Models;

namespace Pizza2.API.Controllers
{
    //[Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [Authorize(Roles= "Customer,Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteOrder){id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var o = await _orderRepository.GetByOrderId(id);
            if(o == null) 
                return NotFound();
            _orderRepository.Delete(o);
            return Ok("Deleted successfully");
        }
        [Authorize(Roles = "Customer,Admin")]
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
        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("GetOrderById/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var o = await _orderRepository.GetByOrderId(id);
            if (o == null)
                return NotFound("This order not found!");
            return Ok(o);
        }
        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("GetOrderByUserId/{id}")]
        public async Task<IActionResult> GetOrderByUserId(int id)
        {
            var o = await _orderRepository.GetByUserId(id);
            if (o == null)
                return NotFound("This order not found!");
            return Ok(o);
        }
        [Authorize(Roles = "Customer,Admin")]
        [HttpGet("GetOrderStatus/{id}")]
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetOrderStatus(int id)
        {
            try
            {
                var status = await _orderRepository.GetOrderStatus(id);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllOrdersByStatus/{status}")]
        public async Task<IActionResult> GetAllOrdersByStatus(string status)
        {
            var orders = await _orderRepository.GetAllAsync();
            var filteredOrders = orders.Where(o => o.Status.ToString().Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
            if (filteredOrders.Count == 0)
                return NotFound("No orders found with the specified status.");
            return Ok(filteredOrders);
        }

        // update order status
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateOrderStatus/{id}")]
        public async Task<IActionResult> UpdateOrderStatus(int id, OrderStatus status)
        {
            var order = await _orderRepository.GetByOrderId(id);
            if (order == null)
                return NotFound("Order not found.");

            order.Status = status;
            _orderRepository.Update(id, order);
            return Ok("Order status updated successfully.");
        }


    }

}
