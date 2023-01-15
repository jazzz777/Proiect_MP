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
    public class DeleteModel : PageModel
    {
        private readonly Stiri.Data.StiriContext _context;

        public DeleteModel(Stiri.Data.StiriContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Articol Articol { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Articol == null)
            {
                return NotFound();
            }

            var articol = await _context.Articol
                .Include(b => b.Jurnalist)   //pt leg.intre tabele 
                .Include(b => b.Categorie)  //pt leg.intre tabele 
                .FirstOrDefaultAsync(m => m.ID == id);

            if (articol == null)
            {
                return NotFound();
            }
            else 
            {
                Articol = articol;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Articol == null)
            {
                return NotFound();
            }
            var articol = await _context.Articol.FindAsync(id);

            if (articol != null)
            {
                Articol = articol;
                _context.Articol.Remove(Articol);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
