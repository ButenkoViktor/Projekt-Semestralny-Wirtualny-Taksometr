using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjektWirtualnyTaksometr.Modele
{
    public  class Klient
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string MiejsceStartu { get; set; }
        public DateTime DataZamowienia { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }

        public List<Przejazd> Przejazdy { get; set; }

    }
}
