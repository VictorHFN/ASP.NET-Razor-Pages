﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IList<Filme> Filme { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string TermoBusca { get; set; }


        [BindProperty(SupportsGet = true)]
        public string FilmeGenero { get; set; }

        public SelectList Generos { get; set; }


        public async Task OnGetAsync()
        {
            var filmes = from m in _context.Filme
                         select m;

            if(!string.IsNullOrWhiteSpace(TermoBusca))
            {
                filmes = filmes.Where(f => f.Titulo.Contains(TermoBusca));
            }

            if (!string.IsNullOrWhiteSpace(FilmeGenero))
            {
                filmes = filmes.Where(f => f.Genero == FilmeGenero);
            }

            Generos = new SelectList(await _context.Filme.Select(o => o.Genero).Distinct().ToListAsync());
            Filme = await filmes.ToListAsync();

           

            if (_context.Filme != null)
            {
                Filme = await filmes.ToListAsync();
            }
        }
    }
}
