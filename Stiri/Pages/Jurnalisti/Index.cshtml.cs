using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stiri.Data;
using Stiri.Models;
using Stiri.Models.ViewModels;

namespace Stiri.Pages.Jurnalisti
{
    public class IndexModel : PageModel
    {
        private readonly Stiri.Data.StiriContext _context;

        public IndexModel(Stiri.Data.StiriContext context)
        {
            _context = context;
        }

        public IList<Jurnalist> Jurnalist { get; set; } = default!;

        public ArticoleJurnalistIndexData ArtJurnData { get; set; }

        public int JurnalistID { get; set; }
        public async Task OnGetAsync(int? id)
        {
            //if (_context.Jurnalist != null)
            //{
            //    Jurnalist = await _context.Jurnalist.ToListAsync();
            //}
            ArtJurnData = new ArticoleJurnalistIndexData();
            ArtJurnData.Jurnalisti = await _context.Jurnalist
                .Include(i => i.Articole_Jurnalist)
                .ThenInclude(i => i.Articol)
                .OrderBy(i => i.Nume)
                .ToListAsync();
            if (id != null)
            {
                JurnalistID = id.Value;
                Jurnalist Jurnalist = ArtJurnData.Jurnalisti
                    .Where(i => i.ID == id.Value).Single();

                //ArtJurnData.Articole = 
            }

        }
    }
}
