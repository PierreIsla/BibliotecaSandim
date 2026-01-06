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

namespace BibliotecaSandim.Pages.Emprestimos
{
    public class EditModel : PageModel
    {
        private readonly BibliotecaISLA.Data.BibliotecaContext _context;

        public EditModel(BibliotecaISLA.Data.BibliotecaContext context)
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

            var emprestimo =  await _context.Emprestimo.FirstOrDefaultAsync(m => m.EmprestimoID == id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            Emprestimo = emprestimo;
           ViewData["LivroID"] = new SelectList(_context.Livro, "LivroID", "Titulo");
           ViewData["MembroID"] = new SelectList(_context.Membro, "MembroID", "Email");
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

            _context.Attach(Emprestimo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmprestimoExists(Emprestimo.EmprestimoID))
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

        private bool EmprestimoExists(int id)
        {
            return _context.Emprestimo.Any(e => e.EmprestimoID == id);
        }
    }
}
