using System;

namespace GameStore.Domain.Catalog
{
    public class CatalogFilter
    {
        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public string SearchTerm { get; private set; }

        public CatalogFilter(int page, int pageSize, string searchTerm = "")
        {
            Page = page;
            PageSize = pageSize;
            SearchTerm = searchTerm;

            Validate();
        }

        public void Validate()
        {
            if (Page < 1)
                throw new ArgumentException("A página deve ser maior ou igual a 1.");

            if (PageSize < 1 || PageSize > 50)
                throw new ArgumentException("O tamanho da página deve ser entre 1 e 50.");
        }
    }
}
