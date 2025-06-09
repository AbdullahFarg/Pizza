using Microsoft.AspNetCore.Identity;
using Pizza.CORE.DTOs;
using Pizza.CORE.Iterfaces;
using Pizza.CORE.JWT;
using Pizza.CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.EF.Services
{
    public class AuthService : IAuthService
    {

        private readonly IRepository<User> _userRepository;
        private readonly IJwtService _JwtService;

        private readonly PasswordHasher<User> _hasher;

        public AuthService(IRepository<User> userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _JwtService = jwtService;
            _hasher = new PasswordHasher<User>();
        }
        public async Task<bool> RegisterAsync(UserRegisterDto user)
        {
            var db = await _userRepository.GetAllAsync();
            if(db.Any(u => u.Email == user.Email))
                return false;

            var TempUser = new User { Email = user.Email  , FistName = user.FistName ,
                         LastName = user.LastName , Address = user.Address , Password= user.Password , PhoneNumber = user.PhoneNumber };

            if(user.Password != null) 
                TempUser.Password = _hasher.HashPassword(TempUser , user.Password);
            if (user.AdminCode == "1111")
                TempUser.Role = "Admin";
            else
                TempUser.Role = "Customer";
            await _userRepository.AddAsync(TempUser);
            await _userRepository.SaveChangesAsync();
            return true;

        }
        public async Task<string?> Login(UserLoginDto dto)
        {
            var user = (await _userRepository.GetAllAsync()).FirstOrDefault(u=> u.Email == dto.Email);
            if(user == null) return null;

            if(user.Password == null || dto.Password == null)
                return null;
            var passwordhash =  _hasher.VerifyHashedPassword(user, user.Password , dto.Password);
            if(passwordhash == PasswordVerificationResult.Failed)
                return null;

            var token = _JwtService.GetJwt(user);
            return token;
        }

       
    }
}
