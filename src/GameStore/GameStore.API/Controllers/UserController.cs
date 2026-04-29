using GameStore.Api.DTOs;
using GameStore.Api.DTOS;
using GameStore.Application.Services;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateUserByAdmin(Guid id, UpdateUserByAdminRequest request)
        {
            try
            {
                var user = await _userService.UpdateByAdminAsync(
                    id,
                    request.Name,
                    request.Email,
                    request.Role
                );

                return Ok(new
                {
                    user.Id,
                    user.Name,
                    Email = user.Email.Value,
                    user.Role
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }

            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("me")]
        public async Task<IActionResult> UpdateMe(UpdateMyUserRequest request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim is null)
                return Unauthorized();

            var userId = Guid.Parse(userIdClaim.Value);

            var updatedUser = await _userService.UpdateMeAsync(
                userId,
                request.Email,
                request.Password
            );

            return Ok(new
            {
                updatedUser.Id,
                updatedUser.Name,
                Email = updatedUser.Email.Value
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}

