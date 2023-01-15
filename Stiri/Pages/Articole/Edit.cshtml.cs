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

namespace Stiri.Pages.Articole
{
    public class EditModel : ArticoleJurnalistPageModel //PageModel
    {
        private readonly Stiri.Data.StiriContext _context;

        public EditModel(Stiri.Data.StiriContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Articol Articol { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Articol == null)
            {
                return NotFound();
            }

            var articol =  await _context.Articol
                .Include(b => b.Jurnalist)   
                .Include(b => b.Categorie)
                .Include(b => b.Articole_Jurnalist)
                .Include(b => b.Categorii_Articole)  
                .FirstOrDefaultAsync(m => m.ID == id);
            if (articol == null)
            {
                return NotFound();
            }
            Articol = articol;
            ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID", "Nume_Categorie");
            ViewData["JurnalistID"] = new SelectList(_context.Set<Jurnalist>(), "ID", "Nume_Intreg");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //_context.Attach(Articol).State = EntityState.Modified;

            try
            {

                //adaug articol.id si articol.jurnalistID in Articole_jurnalist +++
                var newArticol = await _context.Articol
                .Include(b => b.Jurnalist)   
                .Include(b => b.Categorie)
                .Include(b => b.Articole_Jurnalist)
                .Include(b => b.Categorii_Articole)
                .FirstOrDefaultAsync(m => m.ID == id);

                if (newArticol == null) 
                { return NotFound(); }

                if (await TryUpdateModelAsync<Articol>(
                            newArticol,
                            "Articol",
                            i => i.Titlu, i => i.Data,
                            i => i.Text_Articol, i => i.Aprobat, 
                            i => i.JurnalistID, i => i.CategorieID))
                {
                    // update Articole_Jurnalist
                    Upd_Articole_Jurnalisti(_context, newArticol);
                    // update Categorii_Articole
                    Upd_Categorii_Articole(_context, newArticol);

                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }

                //await _context.SaveChangesAsync();
                return Page();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticolExists(Articol.ID))
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

        private bool ArticolExists(int id)
        {
          return _context.Articol.Any(e => e.ID == id);
        }
    }
}
