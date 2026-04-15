using GameStore.Domain.Entities;
using GameStore.Infrastructure.Persistence;
using GameStore.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Repositories
{

    public class GameRepository : IGameRepository
    {
        private readonly GameStoreDbContext _context;

        public GameRepository(GameStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByTitleAsync(string title)
        {
            return await _context.Games.AnyAsync(g => g.Title == title);
        }
    }
}
