using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stiri.Data;
using Stiri.Models;

namespace Stiri.Pages.Articole
{
    public class CreateModel : ArticoleJurnalistPageModel //PageModel
    {
        private readonly Stiri.Data.StiriContext _context;

        public CreateModel(Stiri.Data.StiriContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID", "Nume_Categorie");
            ViewData["JurnalistID"] = new SelectList(_context.Set<Jurnalist>(), "ID", "Nume_Intreg");
            //adaug in Articole_jurnalisti
            //var articol = new Articol();
            //articol.Articole_Jurnalist = new List<Articole_Jurnalist>();
            //Add_Articole_Jurnalisti(_context, articol);
            return Page();
        }
            
        [BindProperty]
        public Articol Articol { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
                      if (!ModelState.IsValid)
                        {
                            return Page();
                        }

                      //adaug articol.id si articol.jurnalistID in Articole_jurnalist +++
                      var newArticol = new Articol();

                      // Articole_jurnalist
                      newArticol.Articole_Jurnalist = new List<Articole_Jurnalist>();
                      var art_jur = new Articole_Jurnalist
                      {
                          ArticolID= Articol.ID,
                          JurnalistID= Articol.JurnalistID
                      };
                      newArticol.Articole_Jurnalist.Add(art_jur);
                      //back to orig.
                      Articol.Articole_Jurnalist = newArticol.Articole_Jurnalist;

                      // Categorii_Articole
                      newArticol.Categorii_Articole = new List<Categorii_Articole>();
                      var cat_art = new Categorii_Articole
                      {
                          ArticolID= Articol.ID,
                          CategorieID= Articol.CategorieID
                      };
                      newArticol.Categorii_Articole.Add(cat_art);
                      //back to orig.
                      Articol.Categorii_Articole = newArticol.Categorii_Articole;

                      //adaug articol.id si articol.jurnalistID in Articole_jurnalist ---

                      _context.Articol.Add(Articol);
                      await _context.SaveChangesAsync();
                      return RedirectToPage("./Index");

        }
    }
}
