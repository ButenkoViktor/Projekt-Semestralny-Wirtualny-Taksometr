using Microsoft.EntityFrameworkCore;
using WpfProjektWirtualnyTaksometr.Modele;
using Microsoft.EntityFrameworkCore;
using WpfProjektWirtualnyTaksometr.Modele;

namespace WpfProjektWirtualnyTaksometr.BazaDanych
{
    public class TaksometrDbContext : DbContext
    {
        public DbSet<Klient> Klient { get; set; }
        public DbSet<Kierowca> Kierowca { get; set; }
        public DbSet<Auto> Auto { get; set; }
        public DbSet<Zlecenie> Zlecenie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=taksometr.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klient>().ToTable("Klient");
            modelBuilder.Entity<Kierowca>().ToTable("Kierowca");
            modelBuilder.Entity<Auto>().ToTable("Auto");
            modelBuilder.Entity<Zlecenie>().ToTable("Zlecenie");

            modelBuilder.Entity<Zlecenie>()
                        .HasOne(z => z.Klient)
                        .WithMany()
                        .HasForeignKey(z => z.KlientId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Zlecenie>()
                        .HasOne(z => z.Kierowca)
                        .WithMany()
                        .HasForeignKey(z => z.KierowcaId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Zlecenie>()
                        .Property(z => z.Status)
                        .HasConversion<string>();
        }

        public void EnsureCreated()
        {
            this.Database.EnsureCreated();
        }
    }
}