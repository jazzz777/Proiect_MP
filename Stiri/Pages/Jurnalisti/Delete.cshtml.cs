using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stiri.Data;
using Stiri.Models;

namespace Stiri.Pages.Jurnalisti
{
    public class DeleteModel : PageModel
    {
        private readonly Stiri.Data.StiriContext _context;

        public DeleteModel(Stiri.Data.StiriContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Jurnalist Jurnalist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Jurnalist == null)
            {
                return NotFound();
            }

            var jurnalist = await _context.Jurnalist.FirstOrDefaultAsync(m => m.ID == id);

            if (jurnalist == null)
            {
                return NotFound();
            }
            else 
            {
                Jurnalist = jurnalist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Jurnalist == null)
            {
                return NotFound();
            }
            var jurnalist = await _context.Jurnalist.FindAsync(id);

            if (jurnalist != null)
            {
                Jurnalist = jurnalist;
                _context.Jurnalist.Remove(Jurnalist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
