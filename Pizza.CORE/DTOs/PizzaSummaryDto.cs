using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.DTOs
{
    public   class PizzaSummaryDto
    {
        public string Name { get; set; }

        public string size { get; set; }
       

    }
}
