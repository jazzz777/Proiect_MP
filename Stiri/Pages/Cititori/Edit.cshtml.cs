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

namespace Stiri.Pages.Cititori
{
    public class EditModel : PageModel
    {
        private readonly Stiri.Data.StiriContext _context;

        public EditModel(Stiri.Data.StiriContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cititor Cititor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cititor == null)
            {
                return NotFound();
            }

            var cititor =  await _context.Cititor.FirstOrDefaultAsync(m => m.ID == id);
            if (cititor == null)
            {
                return NotFound();
            }
            Cititor = cititor;
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

            _context.Attach(Cititor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CititorExists(Cititor.ID))
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

        private bool CititorExists(int id)
        {
          return _context.Cititor.Any(e => e.ID == id);
        }
    }
}
