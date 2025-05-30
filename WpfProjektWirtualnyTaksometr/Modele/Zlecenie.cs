using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjektWirtualnyTaksometr.Modele
{
    public class Zlecenie
    {
        public int Id { get; set; }
        public int KlientId { get; set; }
        public int KierowcaId { get; set; }
        public string AdresPoczatkowy { get; set; }
        public string AdresKoncowy { get; set; }
        public double Kilometraz { get; set; }
        public string Taryfa { get; set; }
        public DateTime Data { get; set; }
        public decimal Cena { get; set; }
        public StatusZlecenia Status { get; set; }

        public Klient Klient { get; set; }
        public Kierowca Kierowca { get; set; }
    }
}