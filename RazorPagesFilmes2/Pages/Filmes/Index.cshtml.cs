using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesFilmes2.Data;
using RazorPagesFilmes2.Model;

namespace RazorPagesFilmes2.Pages.Filmes
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesFilmes2.Data.RazorPagesFilmes2Context _context;

        public IndexModel(RazorPagesFilmes2.Data.RazorPagesFilmes2Context context)
        {
            _context = context;
        }

        public IList<Filme> Filme { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Filme != null)
            {
                Filme = await _context.Filme.ToListAsync();
            }
        }
    }
}
