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
    public class DetailsModel : PageModel
    {
        private readonly BibliotecaISLA.Data.BibliotecaContext _context;

        public DetailsModel(BibliotecaISLA.Data.BibliotecaContext context)
        {
            _context = context;
        }

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
    }
}
