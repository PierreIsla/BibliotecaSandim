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

namespace BibliotecaSandim.Pages.Livros
{
    public class EditModel : PageModel
    {
        private readonly BibliotecaISLA.Data.BibliotecaContext _context;

        public EditModel(BibliotecaISLA.Data.BibliotecaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Livro Livro { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro =  await _context.Livro.FirstOrDefaultAsync(m => m.LivroID == id);
            if (livro == null)
            {
                return NotFound();
            }
            Livro = livro;
           ViewData["AutorID"] = new SelectList(_context.Autor, "AutorID", "Nome");
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

            _context.Attach(Livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(Livro.LivroID))
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

        private bool LivroExists(int id)
        {
            return _context.Livro.Any(e => e.LivroID == id);
        }
    }
}
