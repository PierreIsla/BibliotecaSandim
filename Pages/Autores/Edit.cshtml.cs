using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaISLA.Data;
using BibliotecaISLA.Models;

namespace BibliotecaSandim.Pages.Autores
{
    public class EditModel : PageModel
    {
        private readonly BibliotecaISLA.Data.BibliotecaContext _context;

        public EditModel(BibliotecaISLA.Data.BibliotecaContext context)
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

            var autor =  await _context.Autor.FirstOrDefaultAsync(m => m.AutorID == id);
            if (autor == null)
            {
                return NotFound();
            }
            Autor = autor;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Autor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(Autor.AutorID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AutorExists(int id)
        {
            return _context.Autor.Any(e => e.AutorID == id);
        }
    }
}
