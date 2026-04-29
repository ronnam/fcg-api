using Moq;
using GameStore.Domain.Entities;
using GameStore.Domain.Services;
using Xunit;
using GameStore.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace GameStore.UnitTests.Services
{
    public class CadastroJogoServiceTests
    {
        [Fact]
        public void Deve_Validar_Cadastro_De_Jogo_Com_Dados_Corretos()
        {
            // Arrange
            var title = "C# for Beginners";
            var category = "Developer";

            // Act
            var game = Game.Create(title, category);

            // Assert
            Assert.NotNull(game);
            Assert.Equal(title, game.Title);
            Assert.Equal(category, game.Category);
        }

        [Fact]
        public async Task Nao_Deve_Criar_Jogo_Quando_Ja_Existe_Na_Base_De_Dados()
        {
            // Arrange
            var nomeExistente = "C# for Beginners";
            var mockRepository = new Mock<IGameRepository>();

            mockRepository.Setup(r => r.ExistsByTitleAsync(nomeExistente)).ReturnsAsync(true);

            var service = new CreateGameService(mockRepository.Object);
            var newGame = Game.Create(nomeExistente, "Developer");

            // Act & Assert
            var excecao = await Assert.ThrowsAsync<InvalidOperationException>(() => service.Execute(newGame));
            Assert.Equal("Já existe um jogo com esse nome.", excecao.Message);
        }
    }
}
