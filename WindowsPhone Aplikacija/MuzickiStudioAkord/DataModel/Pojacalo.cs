using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
//using System.Windows.Media.Imaging;

namespace MuzickiStudioAkord.Models
{
    public class Pojacalo : Artikal
    {
        public Pojacalo(int serijskiBroj, string naziv, double cijena, SpecPojacalo spec, string slika)
            :base(serijskiBroj, naziv, cijena, spec, slika)
        {
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
                // ne treba da Specifikacija bude u Artiklu nego da svi imaju odvojeno svoje specifikacije i tako ce raditi
                /// ali ja nisam htio jos nista da diram...
                );
        }
    }
}
