using GameStore.Application.Helpers;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Domain.ValueObjects;
using System.Threading.Tasks;

namespace GameStore.Application.Services
{
    public class AdminUserService
    {
        private readonly IAdminUserRepository _adminUserRepository;

        public AdminUserService(IAdminUserRepository adminUserRepository)
        {
            _adminUserRepository = adminUserRepository;
        }
        public async Task<User> RegisterAsync(
            string name,
            string email,
            string password)
        {
            PasswordValidator.Validate(password);

            var passwordHash = PasswordHasher.Hash(password);
            var emailVo = Email.Create(email);

            var user = User.Create(
                name,
                emailVo,
                passwordHash
            );

            await _adminUserRepository.AddAsync(user);

            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _adminUserRepository.GetAllAsync();
        }
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _adminUserRepository.GetByIdAsync(id);
        }
        public async Task<User> UpdateByAdminAsync(
            Guid userId,
            string role)
        {
            var user = await _adminUserRepository.GetByIdAsync(userId);

            if (user is null)
                throw new NotFoundException("User not found.");


            if (role != "User" && role != "Admin")
                throw new ArgumentException("Invalid role.");

            user.UpdateRole(role);

            await _adminUserRepository.UpdateAsync(user);

            return user;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _adminUserRepository.GetByIdAsync(id);

            if (user is null)
                throw new NotFoundException("User not found.");

            await _adminUserRepository.DeleteAsync(user);
        }
    }
}

