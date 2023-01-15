using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stiri.Data;
using Stiri.Models;

namespace Stiri.Pages.Jurnalisti
{
    public class EditModel : PageModel
    {
        private readonly Stiri.Data.StiriContext _context;

        public EditModel(Stiri.Data.StiriContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Jurnalist Jurnalist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Jurnalist == null)
            {
                return NotFound();
            }

            var jurnalist =  await _context.Jurnalist.FirstOrDefaultAsync(m => m.ID == id);
            if (jurnalist == null)
            {
                return NotFound();
            }
            Jurnalist = jurnalist;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Jurnalist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JurnalistExists(Jurnalist.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JurnalistExists(int id)
        {
          return _context.Jurnalist.Any(e => e.ID == id);
        }
    }
}
