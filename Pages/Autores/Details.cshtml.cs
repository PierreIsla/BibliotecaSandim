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
    public class DetailsModel : PageModel
    {
        private readonly BibliotecaISLA.Data.BibliotecaContext _context;

        public DetailsModel(BibliotecaISLA.Data.BibliotecaContext context)
        {
            _context = context;
        }

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
    }
}
