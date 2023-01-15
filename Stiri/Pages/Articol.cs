namespace Stiri.Models
{
    public class Articol
    {
        public int ID { get; set; }
        public string Titlu { get; set; }
        public DateTime Data { get; set; }
        public string Text_Articol { get; set; }
        public bool Aprobat { get; set; }
        public int JurnalistID { get; set; }
        public Jurnalist Jurnalist { get; set; }  //navigation property
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }  //navigation property

        public ICollection<Categorii_Articole>? Categorii_Articole { get; set; }
    }
}
