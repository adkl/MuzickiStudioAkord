using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class SpecPojacalo : Specifikacija
    {
        public string Zvucnik { get; set; }
        public int BrojKanala { get; set; }
        public bool UlazZaSlusalice { get; set; }

        public SpecPojacalo(int godinaProizvodnje, string proizvodjac, string model, string materijal, string zvucnik, int brojkanala, bool ulazZaSlusalice)
            :base(godinaProizvodnje, proizvodjac, model, materijal)
        {
            this.Zvucnik = zvucnik;
            this.BrojKanala = brojkanala;
            this.UlazZaSlusalice = ulazZaSlusalice;
        }
    }
}
