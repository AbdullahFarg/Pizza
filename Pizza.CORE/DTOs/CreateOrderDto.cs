using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.DTOs
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }

        public string Address { get; set; }

        public ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}
