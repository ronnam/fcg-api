using GameStore.Domain.Entities;

namespace GameStore.Domain.Repositories
{
    public interface IJogoRepository
    {
        bool ExistePorNome(string nome);
        void Adicionar(Jogo jogo);
    }
}
