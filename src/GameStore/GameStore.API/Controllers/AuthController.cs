using GameStore.Api.DTOS.Users;
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
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var user = await _userService.RegisterAsync(
            request.Name,
            request.Email,
            request.Password
        );

        return CreatedAtAction(nameof(Register),
        new { id = user.Id },
        new
        {
            user.Id,
            user.Name,
            Email = user.Email.Value
        });
    }

    // POST /auth/login
    [HttpPost("login")]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<IActionResult> Login(LoginRequest request)
    {

            var user = await _authService.AuthenticateAsync(
                request.Email,
                request.Password
            );

            var token = _jwtTokenGenerator.GenerateToken(user);

            return Ok(new { token });
        
    }
}
