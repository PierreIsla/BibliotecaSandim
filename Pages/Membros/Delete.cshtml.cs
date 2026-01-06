using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BibliotecaISLA.Data;
using BibliotecaISLA.Models;

namespace BibliotecaSandim.Pages.Membros
{
    public class DeleteModel : PageModel
    {
        private readonly BibliotecaISLA.Data.BibliotecaContext _context;

        public DeleteModel(BibliotecaISLA.Data.BibliotecaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Membro Membro { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membro = await _context.Membro.FirstOrDefaultAsync(m => m.MembroID == id);

            if (membro is not null)
            {
                Membro = membro;

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

            var membro = await _context.Membro.FindAsync(id);
            if (membro != null)
            {
                Membro = membro;
                _context.Membro.Remove(Membro);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
