using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Media.Imaging;

namespace MuzickiStudioAkord.Models
{
    public class Klavijatura : Artikal
    {
        public SpecKlavijatura Spec { get; set; }
        public Klavijatura(int serijskiBroj, string naziv, double cijena, SpecKlavijatura spec, string slika)
            : base(serijskiBroj, naziv, cijena, slika)
        {
            this.Spec = spec;
            this.Opis = opis();
        }

        public override string opis()
        {
            return ("Naziv: " + Naziv +
                     "\nGodina Proizvodnje: " + Spec.GodinaProizvodnje +
                     "\nModel: " + Spec.Model +
                     "\nMaterijal:" + Spec.Materijal +
                     "\nProizvodjac: " + Spec.Proizvodjac
                // napravili smo neki previd oko nasljedjivanja pa mi ne da da povadim ostale atribute iz spec
                     
                );
        }
    }
}
