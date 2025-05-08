using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjektWirtualnyTaksometr.Modele
{
    public class Przejazd
    {
        public int Id { get; set; }

        public int KlientId { get; set; }
        public Klient Klient { get; set; }

        public int KierowcaId { get; set; }
        public Kierowca Kierowca { get; set; }

        public string PunktStartowy { get; set; }
        public string PunktKoncowy { get; set; }
        public double Kilometry { get; set; }
        public DateTime Data { get; set; }

        public int TaryfaId { get; set; }
        public Taryfa Taryfa { get; set; }

        public decimal Cena { get; set; }
        public RodzajPlatnosci RodzajPlatnosci { get; set; }
        public StatusPrzejazdu Status { get; set; }
    }

    public enum RodzajPlatnosci
    {
        Gotowka,
        Karta
    }

    public enum StatusPrzejazdu
    {
        Oczekujacy,
        WTrakcie,
        Zakonczony
    }
}
