using Pizza.CORE.DTOs;
using Pizza.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.Iterfaces
{
    public interface IPizzaRepository : IRepository<pizza>
    {
        Task<pizza?> GetPizzaAsync(PizzaSummaryDto dto);
        Task<IEnumerable<pizza>> FilterPrice(int x);
    }
}
