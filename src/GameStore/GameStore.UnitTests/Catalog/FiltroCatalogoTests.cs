using GameStore.Domain.Catalog;
using System;
using Xunit;
{
    
}


namespace GameStore.UnitTests.Catalog
{
    public class FiltroCatalogoTests
    {
        [Fact]
        public void Deve_Criar_Filtro_Quando_Paginacao_E_Termo_Forem_Validos()
        {
            // Arrange & Act
            var pagina = 1;
            var tamanhoPagina = 20;
            var termoBusca = "Zelda";

            var filtro = new FiltroCatalogo(pagina, tamanhoPagina, termoBusca);

            // Assert
            Assert.Equal(1, filtro.Pagina);
            Assert.Equal(20, filtro.TamanhoPagina);
            Assert.Equal("Zelda", filtro.TermoBusca);
        }

        [Fact]
        public void Nao_Deve_Criar_Filtro_Quando_Pagina_For_Menor_Ou_Igual_A_Zero()
        {
            // Arrange 
            var paginaValida = 0;
            var tamanhoPagina = 20;


            // Act & Assert
            Action acao = () => new FiltroCatalogo(paginaValida, tamanhoPagina, "Mario");

            Assert.Throws<ArgumentException>(acao);
        }

        [Fact]
        public void Nao_Deve_Criar_Filtro_Quando_Tamanho_Da_Pagina_For_Maior_Que_O_Limite()
        {
            // Arrange (Proteção contra pedir 1 milhão de registros de uma vez)
            var pagina = 1;
            var tamanhoInvalido = 101; // Estou supondo que o limite seja 100 por página.

            // Act & Assert
            Action acao = () => new FiltroCatalogo(pagina, tamanhoInvalido, "RPG");

            Assert.Throws<ArgumentException>(acao);
        }
    }
}
