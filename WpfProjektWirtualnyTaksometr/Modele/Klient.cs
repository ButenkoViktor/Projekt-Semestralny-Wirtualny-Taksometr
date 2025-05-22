using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjektWirtualnyTaksometr.Modele
{
    public class Klient
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string MiejsceStartu { get; set; }
        public string MiejsceOdbioru { get; set; }
        public DateTime? DataZamowienia { get; set; }

        public ICollection<Zlecenie> Zlecenia { get; set; }
    }

}
