using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Stiri.Models
{
    public class Categorie
    {
        public int ID { get; set; }

        [Display(Name = "Nume categorie")]
        public string Nume_Categorie { get; set; }

        public ICollection<Categorii_Articole>? Categorii_Articole { get; set; } //navigation property
    }
}
