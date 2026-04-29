using GameStore.Domain.Entities;
using System;
using System.Threading.Tasks;
using GameStore.Application.Interfaces;


namespace GameStore.Domain.Services
{
    public class CreateGameService
    {
        private readonly IGameRepository _repository;

        public CreateGameService(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(Game game)
        {
            if (await _repository.ExistsByTitleAsync(game.Title))
            {
                throw new InvalidOperationException("Já existe um jogo com esse nome.");
            }
            await _repository.AddAsync(game);
        }
    }
}
