using GameStore.Domain.Entities;
using System;
using Xunit;

namespace GameStore.UnitTests.Entities
{
    public class JogoTests
    {
        [Fact]
        public void Deve_Criar_Jogo_Quando_Dados_Forem_Validos()
        {
            // Arrange & Act
            var nome = "C# for beginners: The Game";
            var descricao = "Aprenda a programar jogando.";
            var categoria = "Developer";

            var jogo = new Jogo(nome, descricao, categoria);

            // Assert
            Assert.Equal(nome, jogo.Nome);
            Assert.Equal(descricao, jogo.Descricao);
            Assert.Equal(categoria, jogo.Categoria);
        }

        [Fact]
        public void Nao_Deve_Criar_Jogo_Quando_Nome_For_Vazio_Ou_Nulo()
        {
            // Arrange
            var nomeInvalido = "";
            var descricao = "Aprenda a programar jogando.";
            var categoria = "Developer";

            // Act & Assert
            Action acao = () => new Jogo(nomeInvalido, descricao, categoria);

            Assert.Throws<ArgumentException>(acao);
        }

        [Fact]
        public void Nao_Deve_Criar_Jogo_Quando_Descricao_For_Vazia()
        {
            // Arrange
            var nome = "C# for Beginners";
            var descricaoInvalida = "";
            var categoria = "Developer";

            // Act & Assert
            Action acao = () => new Jogo(nome, descricaoInvalida, categoria);
            Assert.Throws<ArgumentException>(acao);
        }
    }
}
