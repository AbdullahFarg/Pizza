using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.Models
{
    public class pizza
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string size { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        public string? Description { get; set; }
        
        [NotMapped]
        public List<string> AvailableSizes { get; set; } = new();
       
        [MaxLength(250)]
        public string? ImageUrl { get; set; }


    }
}
