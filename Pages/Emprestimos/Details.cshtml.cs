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
    public class DetailsModel : PageModel
    {
        private readonly BibliotecaISLA.Data.BibliotecaContext _context;

        public DetailsModel(BibliotecaISLA.Data.BibliotecaContext context)
        {
            _context = context;
        }

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
    }
}
