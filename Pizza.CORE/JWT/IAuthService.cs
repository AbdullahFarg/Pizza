using Pizza.CORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.CORE.JWT
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(UserRegisterDto user);

        Task<string?> Login(UserLoginDto user);


    }
}
