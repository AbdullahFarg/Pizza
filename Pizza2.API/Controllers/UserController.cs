using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.CORE.DTOs;
using Pizza.CORE.Iterfaces;

namespace Pizza2.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUseres()
        {
            var temp = await _userRepository.GetAllAsync();
            return Ok(temp);
        }
        [HttpGet ("{id}")]

        public  async Task<IActionResult>  GetUser( int id)
        {
            var user =   await _userRepository.GetById (id);
            if(user == null) 
                return NotFound();
            return Ok(user);
        }
        [HttpGet("email")]
        public async Task<IActionResult> GetUserByEmail(string e)
        {
            var user = await _userRepository.GetByEmailAsync (e);
            if(user == null)
                return NotFound();
            return Ok(user);

        }
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser(int id , [FromBody] UserUpdateDto dto)
        {
            var user = await _userRepository.GetById (id);
            if (user == null)
                return NotFound();
            if(dto.FistName != null) 
                user.FistName = dto.FistName;
            if(dto.LastName !=  null)
                user.LastName = dto.LastName;
            if(dto.Address != null)
                user.Address = dto.Address;
            if(dto.Email != null)
                user.Email = dto.Email;
            return Ok(user);
        }



    }
}
