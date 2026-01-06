using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BibliotecaISLA.Data;
using BibliotecaISLA.Models;

namespace BibliotecaSandim.Pages.Livros
{
    public class DetailsModel : PageModel
    {
        private readonly BibliotecaISLA.Data.BibliotecaContext _context;

        public DetailsModel(BibliotecaISLA.Data.BibliotecaContext context)
        {
            _context = context;
        }

        public Livro Livro { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Livro = await _context.Livro
                .Include(l => l.Autor)
                .Include(l => l.Emprestimos)
                    .ThenInclude(e => e.Membro)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.LivroID == id);

            if (Livro == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
