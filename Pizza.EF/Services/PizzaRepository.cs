using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Pizza.CORE.DTOs;
using Pizza.CORE.Iterfaces;
using Pizza.CORE.Models;
using Pizza.EF.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.EF.Services
{
    public class PizzaRepository : Repository<pizza>, IPizzaRepository
    {
        public PizzaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<pizza?> GetPizzaAsync(PizzaSummaryDto dto)
        {
            if (dto == null)
                return null;
            var p = await _dbset.FirstOrDefaultAsync(e => e.Name == dto.Name && e.size == dto.size);
            if (p == null)
                return null;
            return p;
        }
        public async Task<IEnumerable<pizza>> FilterPrice(int x)
        {
            var pizzas = await _dbset
                .Where(e => e.Price <= x)
                .ToListAsync();
            if (pizzas.Count == 0) 
                return null;
            return pizzas;
        }
    }
}
