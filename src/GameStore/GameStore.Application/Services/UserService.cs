using GameStore.Application.Helpers;
using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Domain.ValueObjects;
using System.Threading.Tasks;

namespace GameStore.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            await _userRepository.AddAsync(user);

            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
        public async Task<User> UpdateByAdminAsync(
            Guid userId,
            string name,
            string email,
            string role)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user is null)
                throw new ArgumentException("User not found.");


            if (role != "User" && role != "Admin")
                throw new ArgumentException("Invalid role.");

            user.UpdateName(name);
            user.UpdateEmail(Email.Create(email));
            user.UpdateRole(role);

            await _userRepository.UpdateAsync(user);

            return user;
        }
        public void DeleteUser(Guid id)
        {
            _userRepository.Delete(id);

        }
    }
}

