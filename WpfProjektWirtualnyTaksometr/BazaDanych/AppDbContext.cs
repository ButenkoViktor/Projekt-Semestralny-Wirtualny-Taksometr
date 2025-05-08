using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProjektWirtualnyTaksometr.Modele;

namespace WpfProjektWirtualnyTaksometr.BazaDanych
{
    public class AppDbContext : DbContext
    {
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Kierowca> Kierowcy { get; set; }
        public DbSet<Pojazd> Pojazdy { get; set; }
        public DbSet<Taryfa> Taryfy { get; set; }
        public DbSet<Przejazd> Przejazdy { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Przejazd>()
                .HasOne(p => p.Klient)
                .WithMany(k => k.Przejazdy)
                .HasForeignKey(p => p.KlientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Przejazd>()
                .HasOne(p => p.Kierowca)
                .WithMany(k => k.Przejazdy)
                .HasForeignKey(p => p.KierowcaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
