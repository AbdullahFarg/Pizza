using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? FistName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string Role { get; set; } = "Customer";

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
