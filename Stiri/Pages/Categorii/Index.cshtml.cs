using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stiri.Data;
using Stiri.Models;
using Stiri.Models.ViewModels;

namespace Stiri.Pages.Categorii
{
    public class IndexModel : PageModel
    {
        private readonly Stiri.Data.StiriContext _context;

        public IndexModel(Stiri.Data.StiriContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get; set; } = default!;

        public CategoriiArticoleIndexData CatArtData { get; set; }

        public int CategorieID { get; set; }

        public async Task OnGetAsync(int? id)
        {
                //if (_context.Categorie != null)
                //{
                //    Categorie = await _context.Categorie.ToListAsync();
                //}

                CatArtData = new CategoriiArticoleIndexData();
                CatArtData.Categorii = await _context.Categorie
                    .Include(i => i.Categorii_Articole)
                    .ThenInclude(i => i.Articol)
                    .OrderBy(i => i.Nume_Categorie)
                    .ToListAsync();
                if (id != null)
                {
                    CategorieID = id.Value;
                    Categorie Categorie = CatArtData.Categorii
                        .Where(i => i.ID == id.Value).Single();

                    //ArtJurnData.Articole = 
                }

        }
    }
}
