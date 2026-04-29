using GameStore.Domain.Entities;
using GameStore.Domain.ValueObjects;
using Xunit;

namespace Tests.Entities
{
    public class UserTests
    {
        [Fact]
        public void Deve_Validar_Solicitacao_De_Cadastro_Com_Dados_Corretos()
        {
            // 1. Arrange (A "Solicitação do Usuário" - Passo 1 do diagrama)
            var name = "User Test";
            var email = Email.Create("test@domain.com");
            var password = "StrongPass123";

            // 2. Act (A ação de validação - Passo 2 do diagrama)
            var user = User.Create(name, email, password);

            // 3. Assert (A confirmação do sucesso - Passo 4 do diagrama)
            Assert.NotNull(user);
            Assert.Equal(name, user.Name);

        }

        [Fact]
        public void Nao_Deve_Criar_Usuario_Quando_Email_For_Invalido()
        {
            // Arrange
            var name = "Usuario Teste";
            var invalidemail = "testinvaliddomain";
            var password = "StrongPass123";

            // Act & Assert
            Action acao = () => User.Create(name, Email.Create(invalidemail), password);

            Assert.Throws<ArgumentException>(acao);
        }

        [Fact]
        public void Nao_Deve_Criar_Usuario_Quando_Senha_For_Vazia()
        {
            // Arrange
            var name = "User Test";
            var email = Email.Create("test@domain.com");
            var emptypass = "";

            // Act & Assert
            Action acao = () => User.Create(name, email, emptypass);

            Assert.Throws<ArgumentException>(acao);
        }
    }
}