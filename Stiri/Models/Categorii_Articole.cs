namespace Stiri.Models
{
    public class Categorii_Articole
    {
        public int ID { get; set; }
        public int ArticolID { get; set; }
        public Articol? Articol { get; set; }
        public int CategorieID { get; set; }
        public Categorie? Categorie { get; set;}
    }
}
