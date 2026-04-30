using GameStore.Application.Helpers;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<User> RegisterAsync(string name,string email,string password)
        {
            try
            {
                PasswordValidator.Validate(password);

                var passwordHash = PasswordHasher.Hash(password);
                var emailVo = Email.Create(email);

                var user = User.Create(
                    name,
                    emailVo,
                    passwordHash
                );

                await _userRepository.AddAsync(user);

                _logger.LogInformation(
                    "User registered successfully | UserId={UserId} | Email={Email}",
                    user.Id,
                    user.Email.Value
                );

                return user;
            }
            catch (DbUpdateException)
            {
                throw new ConflictException("Email already registered.");
            }
        }
        public async Task<User> UpdateUserAsync(
            Guid userId,
            string email,
            string password)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user is null)
            {
               _logger.LogWarning("Attempt to update non-existing user | UserId={UserId}", userId);

                throw new NotFoundException("User not found.");
            }

            PasswordValidator.Validate(password);

            user.UpdateEmail(Email.Create(email));
            user.UpdatePassword(PasswordHasher.Hash(password));

            await _userRepository.UpdateAsync(user);

            return user;
        }
    }
}
