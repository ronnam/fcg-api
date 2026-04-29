using GameStore.Domain.Entities;
using System;
using Xunit;

namespace GameStore.UnitTests.Entities
{
    public class GameTests
    {
        [Fact]
        public void Deve_Criar_Jogo_Quando_Dados_Forem_Validos()
        {
            // Arrange & Act
            var title = "C# for beginners: The Game";;
            var category = "Developer";

            var game = Game.Create(title, category);

            // Assert
            Assert.Equal(title, game.Title);
            Assert.Equal(category, game.Category);
        }

        [Fact]
        public void Nao_Deve_Criar_Jogo_Quando_Nome_For_Vazio_Ou_Nulo()
        {
            // Arrange
            var invalidName = "";
            var category = "Developer";

            // Act & Assert
            Action acao = () => Game.Create(invalidName, category);

            Assert.Throws<ArgumentException>(acao);
        }
    }
}
