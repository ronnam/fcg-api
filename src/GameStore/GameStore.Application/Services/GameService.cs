using GameStore.Application.Interfaces;
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
    }
}

