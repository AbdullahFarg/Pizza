using Microsoft.EntityFrameworkCore;
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
    public class UserRepository :Repository<User> ,  IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbset.FirstOrDefaultAsync(u => u.Email == email);
        }
       
    }
}
