using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BibliotecaISLA.Data;
using BibliotecaISLA.Models;

namespace BibliotecaSandim.Pages.Livros
{
    public class CreateModel : PageModel
    {
        private readonly BibliotecaISLA.Data.BibliotecaContext _context;

        public CreateModel(BibliotecaISLA.Data.BibliotecaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AutorID"] = new SelectList(_context.Autor, "AutorID", "Nome");
            return Page();
        }

        [BindProperty]
        public Livro Livro { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Livro.Add(Livro);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
