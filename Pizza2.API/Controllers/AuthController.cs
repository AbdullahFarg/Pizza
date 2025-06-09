using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza.CORE.DTOs;
using Pizza.CORE.JWT;

namespace Pizza.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            if (result == false)
                return BadRequest("This Email is used for anther account");

            return Ok("Registration successful");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var result = await _authService.Login(dto);

            if (result == null)
                return BadRequest("Invalid email or password");
            return Ok(result);
        }
        
    }
}
