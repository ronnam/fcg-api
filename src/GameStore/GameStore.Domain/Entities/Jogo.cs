using System;

namespace GameStore.Domain.Entities
{
    public class Jogo
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Categoria { get; private set; }

        public Jogo(string nome, string descricao, string categoria) 
        {
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;

            Validar();
        }

        public void Validar()
        {
            throw new NotImplementedException("As validações da entidade Jogo precisam ser implementadas!");
        }
    }
}
