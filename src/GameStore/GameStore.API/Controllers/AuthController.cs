using GameStore.Api.DTOs;
using GameStore.Api.DTOS;
using GameStore.API.Security;
using GameStore.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers;

[ApiController]
[Route("auth")]
[Tags("Auth")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly AuthService _authService;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public AuthController(
        UserService userService,
        AuthService authService,
        JwtTokenGenerator jwtTokenGenerator)
    {
        _userService = userService;
        _authService = authService;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    // POST /auth/register
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
    public async Task<IActionResult> Login(LoginRequest request)
    {
        try
        {
            var user = await _authService.AuthenticateAsync(
                request.Email,
                request.Password
            );

            var token = _jwtTokenGenerator.GenerateToken(user);

            return Ok(new { token });
        }
        catch (ArgumentException ex)
        {
            return Unauthorized(new { error = ex.Message });
        }
    }
}
