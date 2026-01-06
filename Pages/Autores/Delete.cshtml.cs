using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BibliotecaISLA.Data;
using BibliotecaISLA.Models;

namespace BibliotecaSandim.Pages.Autores
{
    public class DeleteModel : PageModel
    {
        private readonly BibliotecaISLA.Data.BibliotecaContext _context;

        public DeleteModel(BibliotecaISLA.Data.BibliotecaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Autor Autor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor.FirstOrDefaultAsync(m => m.AutorID == id);

            if (autor is not null)
            {
                Autor = autor;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor.FindAsync(id);
            if (autor != null)
            {
                Autor = autor;
                _context.Autor.Remove(Autor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
