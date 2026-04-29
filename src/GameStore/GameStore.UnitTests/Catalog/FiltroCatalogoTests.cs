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
            var page = 1;
            var PageSize = 20;
            var searchTerm = "Zelda";

            var filter = new CatalogFilter(page, PageSize, searchTerm);

            // Assert
            Assert.Equal(1, filter.Page);
            Assert.Equal(20, filter.PageSize);
            Assert.Equal("Zelda", filter.SearchTerm);
        }

        [Fact]
        public void Nao_Deve_Criar_Filtro_Quando_Pagina_For_Menor_Ou_Igual_A_Zero()
        {
            // Arrange 
            var PageValidate = 0;
            var PageSize = 20;


            // Act & Assert
            Action action = () => new CatalogFilter(PageValidate, PageSize, "Mario");

            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void Nao_Deve_Criar_Filtro_Quando_Tamanho_Da_Pagina_For_Maior_Que_O_Limite()
        {
            // Arrange (Proteção contra pedir 1 milhão de registros de uma vez)
            var page = 1;
            var InvalidSize = 101; // Estou supondo que o limite seja 100 por página.

            // Act & Assert
            Action action = () => new CatalogFilter(page, InvalidSize, "RPG");

            Assert.Throws<ArgumentException>(action);
        }
    }
}
