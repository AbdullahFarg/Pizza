using Pizza.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.JWT
{
    public interface IJwtService
    {
        string GetJwt(User user);
    }
}
