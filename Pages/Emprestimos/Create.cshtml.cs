using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BibliotecaISLA.Data;
using BibliotecaISLA.Models;

namespace BibliotecaSandim.Pages.Emprestimos
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
        ViewData["LivroID"] = new SelectList(_context.Livro, "LivroID", "Titulo");
        ViewData["MembroID"] = new SelectList(_context.Membro, "MembroID", "Email");
            return Page();
        }

        [BindProperty]
        public Emprestimo Emprestimo { get; set; } = default!;

               public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Emprestimo.Add(Emprestimo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
