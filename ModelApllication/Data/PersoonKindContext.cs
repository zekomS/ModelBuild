using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelApllication.Entities;

namespace ModelApllication.Data
{
    public class PersoonKindContext : DbContext
    {
        public PersoonKindContext(DbContextOptions<PersoonKindContext> options) : base(options)
        {

        }
        public DbSet<OuderKind> OurderKinderen { get; set; }
        public DbSet<Kind> Kinderen { get; set; }
        public DbSet<Ouder> Ouders { get; set; }
    }
}
