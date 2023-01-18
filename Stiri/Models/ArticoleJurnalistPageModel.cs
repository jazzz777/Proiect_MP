using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualBasic;
using Stiri.Data;
using System.Runtime.InteropServices;

namespace Stiri.Models
{
    public class ArticoleJurnalistPageModel:PageModel
    {
        //public List<Articole_Jurnalist> Articole_Jurnalist;

        // update pe tabela Articole_jurnalist
        public void Upd_Articole_Jurnalisti(StiriContext context, Articol articol)
        {
            if (articol.ID == null)
            {
                return;
            }
            //old
            var oldArticol = new Articol();
            oldArticol.Articole_Jurnalist = new List<Articole_Jurnalist>();
            foreach (var jurn in articol.Articole_Jurnalist)
            {
                Articole_Jurnalist remArtJurn
                    = articol
                    .Articole_Jurnalist
                    .SingleOrDefault(i => i.JurnalistID == jurn.JurnalistID);
                //remove
                context.Remove(remArtJurn);
            }

            // new
            var newArticol = new Articol();
            newArticol.Articole_Jurnalist = new List<Articole_Jurnalist>();
            //Add
            newArticol.Articole_Jurnalist.Add(
                new Articole_Jurnalist
                {
                    ArticolID = articol.ID,
                    JurnalistID = articol.JurnalistID
                });
            articol.Articole_Jurnalist = newArticol.Articole_Jurnalist;
        }

        // update tabela Categorii_Articole
        public void Upd_Categorii_Articole(StiriContext context, Articol articol)
        {
            if (articol.ID == null)
            {
                return;
            }
            //old
            var oldArticol = new Articol();
            oldArticol.Categorii_Articole = new List<Categorii_Articole>();
            foreach (var cat in articol.Categorii_Articole)
            {
                Categorii_Articole remCatArt
                    = articol
                    .Categorii_Articole
                    .SingleOrDefault(i => i.CategorieID == cat.CategorieID);
                //remove
                context.Remove(remCatArt);
            }

            // new
            var newArticol = new Articol();
            newArticol.Categorii_Articole = new List<Categorii_Articole>();
            //Add
            newArticol.Categorii_Articole.Add(
                new Categorii_Articole
                {
                    ArticolID = articol.ID,
                    CategorieID = articol.CategorieID
                });
            articol.Categorii_Articole = newArticol.Categorii_Articole;
        }

    }
}
