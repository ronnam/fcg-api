using GameStore.Domain.Entities;

namespace GameStore.Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByEmailAsync(string email);
    }
}

