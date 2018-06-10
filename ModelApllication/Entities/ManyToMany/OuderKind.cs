using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelApllication.Entities
{
    public class OuderKind
    {
        public Kind Kind { get; set; }
        public Ouder Ouder { get; set; }
        public Guid Id { get; set; }
}
}
