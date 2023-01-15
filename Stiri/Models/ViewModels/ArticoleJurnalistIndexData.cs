using System.Security.Policy;

namespace Stiri.Models.ViewModels
{
    public class ArticoleJurnalistIndexData
    {
        public IEnumerable<Jurnalist> Jurnalisti { get; set; }
        public IEnumerable<Articol> Articole { get; set; }
    }
}
