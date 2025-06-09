using Pizza.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.Iterfaces
{
    public interface IUserRepository :IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
