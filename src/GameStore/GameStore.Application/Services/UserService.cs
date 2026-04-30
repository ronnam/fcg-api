using GameStore.Application.Helpers;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
                throw new NotFoundException("User not found.");

            PasswordValidator.Validate(password);

            user.UpdateEmail(Email.Create(email));
            user.UpdatePassword(PasswordHasher.Hash(password));

            await _userRepository.UpdateAsync(user);

            return user;
        }
    }
}
