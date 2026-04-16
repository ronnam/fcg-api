using GameStore.Application.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Repositories
{
    public class UserRepository(GameStoreDbContext context) : IUserRepository
    {
        private readonly GameStoreDbContext _context = context;

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Email)
                .FirstOrDefaultAsync(u => u.Email.Value == email);
        }
    }
}
