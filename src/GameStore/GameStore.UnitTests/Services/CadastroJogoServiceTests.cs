using Moq;
using GameStore.Domain.Entities;
using GameStore.Domain.Repositories;
using GameStore.Domain.Services;
using Xunit;

namespace GameStore.UnitTests.Services
{
    public class CadastroJogoServiceTests
    {
        [Fact]
        public void Nao_Deve_Criar_Jogo_Quando_Ja_Existe_Na_Base_De_Dados()
        {
            // Arrange
            var nomeExistente = "C# for Beginners";
            var mockRepository = new Mock<IJogoRepository>();

            mockRepository.Setup(r => r.ExistePorNome(nomeExistente)).Returns(true);

            var service = new CadastroJogoService(mockRepository.Object);
            var novoJogo = new Jogo(nomeExistente, "Descricao", "Developer");

            // Act & Assert
            var excecao = Assert.Throws<InvalidOperationException>(() => service.Executar(novoJogo));
            Assert.Equal("Já existe um jogo com esse nome.", excecao.Message);
        }
    }
}
