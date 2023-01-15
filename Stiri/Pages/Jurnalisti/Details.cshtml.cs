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
    public class DetailsModel : PageModel
    {
        private readonly Stiri.Data.StiriContext _context;

        public DetailsModel(Stiri.Data.StiriContext context)
        {
            _context = context;
        }

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
    }
}
