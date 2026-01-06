using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BibliotecaISLA.Data;
using BibliotecaISLA.Models;

namespace BibliotecaISLA.Pages.Livros
{
    public class IndexModel : PageModel
    {
        private readonly BibliotecaContext _context;

        public IndexModel(BibliotecaContext context)
        {
            _context = context;
        }

        public string OrdenacaoTitulo { get; set; }
        public string OrdenacaoAno { get; set; }
        public string OrdenacaoAutor { get; set; }
        public string FiltroCorrente { get; set; }
        public string OrdenacaoCorrente { get; set; }
        
        public PaginaLista<Livro> Livros { get; set; }

        public async Task OnGetAsync(string ordenacao, string filtroCorrente,
                                     string filtroTexto, int? indexPagina)
        {
            OrdenacaoCorrente = ordenacao;
            OrdenacaoTitulo = string.IsNullOrEmpty(ordenacao) ? "titulo_desc" : "";
            OrdenacaoAno = ordenacao == "Ano" ? "ano_desc" : "Ano";
            OrdenacaoAutor = ordenacao == "Autor" ? "autor_desc" : "Autor";

            if (filtroTexto != null)
            {
                indexPagina = 1;
            }
            else
            {
                filtroTexto = filtroCorrente;
            }

            FiltroCorrente = filtroTexto;

            IQueryable<Livro> livroIQ = from l in _context.Livro
                                        .Include(l => l.Autor)
                                        select l;

            if (!string.IsNullOrEmpty(filtroTexto))
            {
                livroIQ = livroIQ.Where(l => l.Titulo.Contains(filtroTexto)
                                          || l.Autor.Nome.Contains(filtroTexto)
                                          || l.ISBN.Contains(filtroTexto));
            }

            switch (ordenacao)
            {
                case "titulo_desc":
                    livroIQ = livroIQ.OrderByDescending(l => l.Titulo);
                    break;
                case "Ano":
                    livroIQ = livroIQ.OrderBy(l => l.AnoPublicacao);
                    break;
                case "ano_desc":
                    livroIQ = livroIQ.OrderByDescending(l => l.AnoPublicacao);
                    break;
                case "Autor":
                    livroIQ = livroIQ.OrderBy(l => l.Autor.Nome);
                    break;
                case "autor_desc":
                    livroIQ = livroIQ.OrderByDescending(l => l.Autor.Nome);
                    break;
                default:
                    livroIQ = livroIQ.OrderBy(l => l.Titulo);
                    break;
            }

            int tamanhoPagina = 5;
            Livros = await PaginaLista<Livro>.CreateAsync(
                livroIQ.AsNoTracking(), indexPagina ?? 1, tamanhoPagina);
        }
    }
}