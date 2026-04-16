using GameStore.Domain.Entities;
using System.Threading.Tasks;

namespace GameStore.Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByEmailAsync(string email);
    }
}

