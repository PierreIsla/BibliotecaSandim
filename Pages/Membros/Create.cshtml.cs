using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BibliotecaISLA.Data;
using BibliotecaISLA.Models;

namespace BibliotecaSandim.Pages.Membros
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
            return Page();
        }

        [BindProperty]
        public Membro Membro { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Membro.Add(Membro);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
