using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjektWirtualnyTaksometr.Modele
{
    public class Pojazd
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string NumerRejestracyjny { get; set; }
        public string VIN { get; set; }

        public int KierowcaId { get; set; }
        public Kierowca Kierowca { get; set; }
    }
}
