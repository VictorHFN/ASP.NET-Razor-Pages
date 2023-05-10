using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesFilmes2.Model;

namespace RazorPagesFilmes2.Data
{
    public class RazorPagesFilmes2Context : DbContext
    {
        public RazorPagesFilmes2Context (DbContextOptions<RazorPagesFilmes2Context> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesFilmes2.Model.Filme> Filme { get; set; } = default!;
    }
}
