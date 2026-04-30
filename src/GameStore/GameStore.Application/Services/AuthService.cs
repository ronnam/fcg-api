using GameStore.Application.Helpers;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace GameStore.Application.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<AuthService> _logger;

    public AuthService(IUserRepository userRepository, ILogger<AuthService> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<User> AuthenticateAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user is null)
        {
           _logger.LogWarning("Authentication failed | Reason=InvalidCredentials | Email={Email}", email);

             throw new ArgumentException("Invalid credentials.");
        }

        if (!PasswordHasher.Verify(password, user.PasswordHash))
        {
           _logger.LogWarning("Authentication failed | Reason=InvalidCredentials | UserId={UserId}", user.Id);
    
                throw new UnauthorizedException("Invalid credentials.");
        }

           _logger.LogInformation("User authenticated successfully | UserId={UserId}", user.Id);

        return user;
    }
}
