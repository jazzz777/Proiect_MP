using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stiri.Data;
using Stiri.Models;

namespace Stiri.Pages.Cititori
{
    public class CreateModel : PageModel
    {
        private readonly Stiri.Data.StiriContext _context;

        public CreateModel(Stiri.Data.StiriContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cititor Cititor { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cititor.Add(Cititor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
