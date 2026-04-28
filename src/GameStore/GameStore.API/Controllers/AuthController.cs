using GameStore.Api.DTOS;
using GameStore.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers
{

    [ApiController]
    [Route("auth")]
    [Tags("Auth")]
    public class AuthController(UserService userService) : ControllerBase
    {
        private readonly UserService _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var user = await _userService.RegisterAsync(
                request.Name,
                request.Email,
                request.Password
            );

            return Ok(new
            {
                user.Id,
                user.Name,
                Email = user.Email.Value
            });
        }

        // POST /auth/login
        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok("Login endpoint (JWT later)");
        }
    }
}

