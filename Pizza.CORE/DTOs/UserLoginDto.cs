using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.DTOs
{
    public class UserLoginDto
    {
        
        [Required]
        public string? Email { get; set; }
        [Required, MaxLength(50)]
        public string? Password { get; set; }
    }
}
