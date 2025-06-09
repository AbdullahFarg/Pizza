using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.DTOs
{
    public class PizzaDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string size { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        public string? Description { get; set; }
        [MaxLength(250)]
        public string? ImageUrl { get; set; }
    }
}
