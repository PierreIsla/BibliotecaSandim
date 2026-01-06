using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BibliotecaISLA.Data;
using BibliotecaISLA.Models;

namespace BibliotecaSandim.Pages.Emprestimos
{
    public class DeleteModel : PageModel
    {
        private readonly BibliotecaISLA.Data.BibliotecaContext _context;

        public DeleteModel(BibliotecaISLA.Data.BibliotecaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Emprestimo Emprestimo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo.FirstOrDefaultAsync(m => m.EmprestimoID == id);

            if (emprestimo is not null)
            {
                Emprestimo = emprestimo;

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

            var emprestimo = await _context.Emprestimo.FindAsync(id);
            if (emprestimo != null)
            {
                Emprestimo = emprestimo;
                _context.Emprestimo.Remove(Emprestimo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
