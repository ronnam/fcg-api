using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace GameStore.Application.Interfaces
{
    public interface IGameRepository
    {
        Task AddAsync(Game game);
        Task<bool> ExistsByTitleAsync(string title);
        Task<IEnumerable<Game>> GetAllAsync();
    }
}
