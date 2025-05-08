using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjektWirtualnyTaksometr.Modele
{
    public class Taryfa
    {
        public int Id { get; set; }
        public string TypTaryfa { get; set; } 
        public decimal CenaZaKm { get; set; }
    }
}
