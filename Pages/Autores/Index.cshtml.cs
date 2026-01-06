using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BibliotecaISLA.Data;
using BibliotecaISLA.Models;

namespace BibliotecaSandim.Pages.Autores
{
    public class IndexModel : PageModel
    {
        private readonly BibliotecaISLA.Data.BibliotecaContext _context;

        public IndexModel(BibliotecaISLA.Data.BibliotecaContext context)
        {
            _context = context;
        }

        public IList<Autor> Autor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Autor = await _context.Autor.ToListAsync();
        }
    }
}
