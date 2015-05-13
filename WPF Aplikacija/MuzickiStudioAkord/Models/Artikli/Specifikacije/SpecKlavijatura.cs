using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class SpecKlavijatura : Specifikacija
    {
        public int BrojTipki { get; set; }
        public string Zvucnik { get; set; }
        public double Tezina { get; set; }
        public string Napajanje { get; set; }
        public SpecKlavijatura(int godinaProizvodnje, string proizvodjac, string model, string materijal, int brojTipki, string zvucnik, double tezina, string napajanje)
            :base(godinaProizvodnje, proizvodjac, model, materijal)
        {
            this.BrojTipki = brojTipki;
            this.Zvucnik = zvucnik;
            this.Tezina = tezina;
            this.Napajanje = napajanje;
        }
    }
}
