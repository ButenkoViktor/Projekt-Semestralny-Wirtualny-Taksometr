using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProjektWirtualnyTaksometr.Modele;

namespace WpfProjektWirtualnyTaksometr.BazaDanych
{
    public class TaksometrDbContext : DbContext
    {
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Kierowca> Kierowcy { get; set; }
        public DbSet<Auto> Auta { get; set; }
        public DbSet<Zlecenie> Zlecenia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=taksometr.db");
        }
    }

}
