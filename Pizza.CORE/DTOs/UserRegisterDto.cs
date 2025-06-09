using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pizza.CORE.DTOs
{
    public class UserRegisterDto
    {
        [MaxLength(50)]
        public string? FistName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required, MaxLength(50)]
        public string? Password { get; set; }
        [Required , MaxLength(20)]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Address { get; set; }

        public string AdminCode { get; set; } = "0000";
    }
}
