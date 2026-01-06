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
    public class IndexModel : PageModel
    {
        private readonly BibliotecaISLA.Data.BibliotecaContext _context;

        public IndexModel(BibliotecaISLA.Data.BibliotecaContext context)
        {
            _context = context;
        }

        public IList<Membro> Membro { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Membro = await _context.Membro.ToListAsync();
        }
    }
}
