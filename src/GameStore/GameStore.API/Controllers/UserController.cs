using GameStore.Api.DTOS;
using GameStore.Application.Services;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();

            var response = users.Select(u => new
            {
                u.Id,
                u.Name,
                Email = u.Email.Value,
                u.Role
            });

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user is null)
                return NotFound();

            return Ok(new
            {
                user.Id,
                user.Name,
                Email = user.Email.Value,
                user.Role
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user is null)
                return NotFound();

            _userService.DeleteUser(id);

            return Ok();
        }
    }
}

