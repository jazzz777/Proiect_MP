using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Stiri.Models
{
    public class Jurnalist
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        [Display(Name = "Nume:")]
        public string? Nume_Intreg
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }

        public ICollection<Articole_Jurnalist>? Articole_Jurnalist { get; set; }
    }
}
