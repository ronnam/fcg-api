using GameStore.Domain.Entities;
using Xunit;

namespace Tests.Entities
{
    public class UsuarioTests
    {
        [Fact]
        public void Deve_Validar_Solicitacao_De_Cadastro_Com_Dados_Corretos()
        {
            // 1. Arrange (A "Solicitação do Usuário" - Passo 1 do diagrama)
            var nome = "Usuario Teste";
            var email = "teste@dominio.com";
            var cpf = "12345678900";
            var senha = "SenhaForte123";

            // 2. Act (A ação de validação - Passo 2 do diagrama)
            var usuario = new Usuario(nome, email, cpf, senha);

            // 3. Assert (A confirmação do sucesso - Passo 4 do diagrama)
            Assert.NotNull(usuario);
            Assert.Equal(nome, usuario.Nome);

        }

        [Fact]
        public void Nao_Deve_Criar_Usuario_Quando_Cpf_For_Vazio_Ou_Nulo()
        {
            // Arrange
            var nome = "Usuario Teste";
            var email = "teste@dominio.com";
            var cpfInvalido = "";
            var senha = "SenhaForte123";

            // Act & Assert
            Action acao = () => new Usuario(nome, email, cpfInvalido, senha);

            Assert.Throws<ArgumentException>(acao);
        }

        [Fact]
        public void Nao_Deve_Criar_Usuario_Quando_Email_For_Invalido()
        {
            // Arrange
            var nome = "Usuario Teste";
            var emailInvalido = "email-invalido";
            var cpf = "12345678900";
            var senha = "SenhaForte123";
            // Act & Assert
            Action acao = () => new Usuario(nome, emailInvalido, cpf, senha);

            Assert.Throws<ArgumentException>(acao);
        }

        [Fact]
        public void Nao_Deve_Criar_Usuario_Quando_Senha_For_Fraca()
        {
            // Arrange
            var nome = "Usuario Teste";
            var email = "teste@dominio.com";
            var cpf = "12345678900";
            var senhaFraca = "123";

            // Act & Assert
            Action acao = () => new Usuario(nome, email, cpf, senhaFraca);

            Assert.Throws<ArgumentException>(acao);
        }
    }
}