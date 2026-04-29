using GameStore.Api.DTOS;
using GameStore.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers
{
    [ApiController]
    [Route("users")]
    [Tags("User")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            try
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
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}

