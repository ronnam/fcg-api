using System;

namespace GameStore.Domain.Entities
{
    public class Usuario
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Senha { get; private set; }

        public Usuario(string nome, string email, string cpf, string senha)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Senha = senha;
        }

        public void Validar()
        {
            throw new NotImplementedException("As regras de validação de cadastro precisam ser implementadas!");
        }
    }
}
