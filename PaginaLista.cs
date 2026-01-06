using Microsoft.EntityFrameworkCore;

namespace BibliotecaISLA
{
    public class PaginaLista<T> : List<T>
    {
        public int PaginaIndex { get; private set; }
        public int TotalPaginas { get; private set; }

        public PaginaLista(List<T> items, int contar, int indexPagina, int tamanhoPagina)
        {
            PaginaIndex = indexPagina;
            TotalPaginas = (int)Math.Ceiling(contar / (double)tamanhoPagina);
            this.AddRange(items);
        }

        public bool HaPaginasAntes => (PaginaIndex > 1);
        public bool HaPaginasDepois => (PaginaIndex < TotalPaginas);

        public static async Task<PaginaLista<T>> CreateAsync(
            IQueryable<T> source, int indexPagina, int tamanhoPagina)
        {
            var contar = await source.CountAsync();
            var items = await source.Skip((indexPagina - 1) * tamanhoPagina)
                                   .Take(tamanhoPagina)
                                   .ToListAsync();
            return new PaginaLista<T>(items, contar, indexPagina, tamanhoPagina);
        }
    }
}