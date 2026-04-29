using GameStore.Application.Interfaces;
using GameStore.Domain.Catalog;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Services
{
    public class GameService
    {
        private readonly IGameRepository _repository;

        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<Game> CreateAsync(string title, string category)
        {
            if (await _repository.ExistsByTitleAsync(title))
                throw new ArgumentException("Game already exists.");

            var game = Game.Create(title, category);

            await _repository.AddAsync(game);

            return game;
        }

        public async Task<IEnumerable<Game>> GetAllAsync(CatalogFilter filter)
        {
            filter.Validate();

            var games = await _repository.GetAllAsync();

            if (!string.IsNullOrEmpty(filter.SearchTerm))
            {
                games = games.Where(g => g.Title.Contains(filter.SearchTerm, StringComparison.OrdinalIgnoreCase));
            }

            return games
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize);
        }
    }
}

