using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stiri.Models;

namespace Stiri.Data
{
    public class StiriContext : DbContext
    {
        public StiriContext (DbContextOptions<StiriContext> options)
            : base(options)
        {
        }

        public DbSet<Stiri.Models.Categorie> Categorie { get; set; } = default!;

        public DbSet<Stiri.Models.Cititor> Cititor { get; set; }

        public DbSet<Stiri.Models.Jurnalist> Jurnalist { get; set; }

        public DbSet<Stiri.Models.Articol> Articol { get; set; }
    }

}
