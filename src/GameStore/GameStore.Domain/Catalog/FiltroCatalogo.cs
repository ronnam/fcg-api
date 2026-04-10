using System;

namespace GameStore.Domain.Catalog
{
    public class FiltroCatalogo
    {
        public int Pagina { get; private set; }
        public int TamanhoPagina { get; private set; }
        public string TermoBusca { get; private set; }

        public FiltroCatalogo(int pagina, int tamanhoPagina, string termoBusca = "")
        {
            Pagina = pagina;
            TamanhoPagina = tamanhoPagina;
            TermoBusca = termoBusca;

            Validar();
        }

        public void Validar()
        {
            throw new NotImplementedException("As regras de paginação precisam ser implementadas!");
        }
    }
}
