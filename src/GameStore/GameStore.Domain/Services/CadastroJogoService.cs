using GameStore.Domain.Entities;
using GameStore.Domain.Repositories;
using System;

namespace GameStore.Domain.Services
{
    public class CadastroJogoService
    {
        private readonly IJogoRepository _repository;

        public CadastroJogoService(IJogoRepository repository)
        {
            _repository = repository;
        }

        public void Executar(Jogo jogo)
        {
            if (_repository.ExistePorNome(jogo.Nome))
            {
                throw new InvalidOperationException("Já existe um jogo com esse nome.");
            }
            _repository.Adicionar(jogo);
        }
    }
}
