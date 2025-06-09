using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.DTOs
{
    public class OrderItemDto
    {
        public int PizzaId { get; set; }

        public string size { get; set; }

        public int Quantity { get; set; }

    }
}
