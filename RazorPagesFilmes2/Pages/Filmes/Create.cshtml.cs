using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesFilmes2.Data;
using RazorPagesFilmes2.Model;

namespace RazorPagesFilmes2.Pages.Filmes
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesFilmes2.Data.RazorPagesFilmes2Context _context;

        public CreateModel(RazorPagesFilmes2.Data.RazorPagesFilmes2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Filme Filme { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Filme == null || Filme == null)
            {
                return Page();
            }

            _context.Filme.Add(Filme);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
