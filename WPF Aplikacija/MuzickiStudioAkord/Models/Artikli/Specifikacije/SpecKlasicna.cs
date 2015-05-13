using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class SpecKlasicna : SpecGitara
    {
        public string Vrat { get; set; }
        public string Most { get; set; }
        public string PickUp { get; set; }
        public string Elektronika { get; set; }

        public SpecKlasicna(int godinaProizvodnje, string proizvodjac, string model, string materijal, int brojZica, string masinica, string vrat, string most, string pickup, string elektronika)
            : base(godinaProizvodnje, proizvodjac, model, materijal, brojZica)
        {
            this.Vrat = vrat;
            this.Most = most;
            this.PickUp = pickup;
            this.Elektronika = elektronika;
        }
    }
}
