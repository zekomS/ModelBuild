using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelApllication.Entities
{
    public class Kind
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public int? leeftijd { get; set; }
        public ICollection<OuderKind> Ouder { get; set; }
        public Guid id { get; set; }
    }
}
