using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stiri.Data;
using Stiri.Models;

namespace Stiri.Pages.Articole
{
    public class IndexModel : PageModel
    {
        private readonly Stiri.Data.StiriContext _context;

        public IndexModel(Stiri.Data.StiriContext context)
        {
            _context = context;
        }

        public IList<Articol> Articol { get;set; } = default!;
        
        public async Task OnGetAsync()
        {
            if (_context.Articol != null)
            {
                Articol = await _context.Articol
                .Include(a => a.Categorie)
                .Include(a => a.Jurnalist).ToListAsync();
            }
        }
    }
}
