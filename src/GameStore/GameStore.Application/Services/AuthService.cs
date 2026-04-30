using GameStore.Application.Helpers;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;

namespace GameStore.Application.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> AuthenticateAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        if (user is null)
            throw new ArgumentException("Invalid credentials.");

        if (!PasswordHasher.Verify(password, user.PasswordHash))
            throw new UnauthorizedException("Invalid credentials.");

        return user;
    }
}
