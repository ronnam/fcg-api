using GameStore.Domain.Entities;

namespace GameStore.Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);

        Task DeleteAsync(Guid id);

    }
}

