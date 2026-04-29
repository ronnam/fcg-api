using Moq;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GameStore.Domain.Entities;
using GameStore.Application.Interfaces;
using GameStore.Application.Services;
using GameStore.Domain.Services;
using GameStore.Domain.Catalog;

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

        [Fact]
        public async Task Deve_Retornar_Lista_De_Jogos_Quando_Existirem_No_Catalogo()
        {
            // Arrange
            var mockRepository = new Mock<IGameRepository>();

            var games = new List<Game>
            {
                Game.Create("C# for Beginners", "Developer"),
                Game.Create("C# level hard", "Senior")
            };

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(games);

            var service = new GameService(mockRepository.Object);
            var filter = new CatalogFilter(1, 10);

            // Act
            var resultado = await service.GetAllAsync(filter);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
        }
    }
}
