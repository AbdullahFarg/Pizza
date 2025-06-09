using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.Models
{
    public enum OrderStatus
    {
        New,
        Preparing,
        Delivering,
        Delivered,
        Cancelled
    }

    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        [Required, MaxLength(250)]
        public string Address { get; set; }

        [Required]
        public OrderStatus Status { get; set; } = OrderStatus.New;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User Customer { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        [NotMapped]
        public decimal TotalPrice { get; set; }
    }

}
