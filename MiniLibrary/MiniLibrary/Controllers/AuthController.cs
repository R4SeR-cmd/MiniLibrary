using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MiniLibrary.BLL.DTOs;
using MiniLibrary.BLL.Services.Interfaces;

namespace MiniLibrary.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCredentialsDTO dto)
        {
            var token = await _authService.RegisterAsync(dto);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserCredentialsDTO dto)
        {
            var token = await _authService.LoginAsync(dto);
            return Ok(new { token });
        }



       

    }
}
