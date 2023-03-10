using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stiri.Data;
using Stiri.Models;

namespace Stiri.Pages.Cititori
{
    public class DetailsModel : PageModel
    {
        private readonly Stiri.Data.StiriContext _context;

        public DetailsModel(Stiri.Data.StiriContext context)
        {
            _context = context;
        }

      public Cititor Cititor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cititor == null)
            {
                return NotFound();
            }

            var cititor = await _context.Cititor.FirstOrDefaultAsync(m => m.ID == id);
            if (cititor == null)
            {
                return NotFound();
            }
            else 
            {
                Cititor = cititor;
            }
            return Page();
        }
    }
}
