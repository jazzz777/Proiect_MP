using System.Runtime.Serialization;

namespace Stiri.Models
{
    public class Articole_Jurnalist
    {
        public int ID { get; set; }
        public int ArticolID { get; set; }
        public Articol Articol { get; set; }
        public int JurnalistID { get; set; }
        public Jurnalist Jurnalist { get; set; }
  
    }
}
