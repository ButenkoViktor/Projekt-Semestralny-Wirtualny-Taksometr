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

            // === Enum conversions ===
            modelBuilder.Entity<Kierowca>()
                .Property(k => k.statusKierowcy)
                .HasConversion<int>();

            modelBuilder.Entity<Przejazd>()
                .Property(p => p.Status)
                .HasConversion<int>();

            // === Relacje ===
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

            // === Dane testowe ===

            modelBuilder.Entity<Klient>().HasData(
                new Klient { Id = 1, Imie = "Jan", Nazwisko = "Kowalski", Telefon = "123456789", Email = "jan@gmail.pl", MiejsceStartu = "Warszawa" },
                new Klient { Id = 2, Imie = "Anna", Nazwisko = "Nowak",  Telefon = "987654321", Email = "anna@gmail.pl", MiejsceStartu = "Krakow" }
            );

            modelBuilder.Entity<Taryfa>().HasData(
                new Taryfa { Id = 1, TypTaryfa = "Dzien", CenaZaKm = 3.5m },
                new Taryfa { Id = 2, TypTaryfa = "Noc", CenaZaKm = 6.0m },
                new Taryfa { Id = 3, TypTaryfa = "Swieto", CenaZaKm = 8.4m }
            );

            modelBuilder.Entity<Kierowca>().HasData(
                new Kierowca { Id = 1, Imie = "Marek Nowicki", Telefon = "111222333", Email = "marek@taksometr.pl", statusKierowcy = StatusKierowcy.Dostepny },
                new Kierowca { Id = 2, Imie = "Piotr Zielinski", Telefon = "444555666", Email = "piotr@taksometr.pl", statusKierowcy = StatusKierowcy.Zajety }
            );

            modelBuilder.Entity<Pojazd>().HasData(
                new Pojazd { Id = 1, Marka = "Toyota", Model = "Corolla", VIN = "BR41491BT521F43W3", NumerRejestracyjny = "WX12345", KierowcaId = 1 },
                new Pojazd { Id = 2, Marka = "BMW", Model = "X5", VIN = "BR41221DT121F43W3", NumerRejestracyjny = "KR98765", KierowcaId = 2 }
            );

            modelBuilder.Entity<Przejazd>().HasData(
                new Przejazd
                {
                    Id = 1,
                    KlientId = 1,
                    KierowcaId = 1,
                    PunktStartowy = "Plac Zbawiciela",
                    PunktKoncowy = "Dworzec Centralny",
                    Kilometry = 5.2m,
                    Data = new DateTime(2025, 5, 14, 12, 0, 0),
                    TaryfaId = 1,
                    Cena = 13.00m,
                    RodzajPlatnosci = RodzajPlatnosci.Gotowka,
                    Status = StatusPrzejazdu.Zakonczony
                }
            );
        }
    }
}
