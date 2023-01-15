namespace Stiri.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string Nume_Categorie { get; set; }

        public ICollection<Categorii_Articole>? Categorii_Articole { get; set; } //navigation property
    }
}
