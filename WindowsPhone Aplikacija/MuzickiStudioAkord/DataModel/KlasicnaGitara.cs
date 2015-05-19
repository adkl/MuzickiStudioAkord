using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Media.Imaging;

namespace MuzickiStudioAkord.Models
{
    public class KlasicnaGitara : Gitara
    {
        public TipKlasicne Tip { get; set; }

        public SpecKlasicna Spec { get; set; }

        public KlasicnaGitara(int serijskiBroj, string naziv, double cijena, SpecKlasicna spec, string slika, TipKlasicne tip)
            :base(serijskiBroj, naziv, cijena, slika)
        {
            this.Tip = tip;
            this.Spec = spec;
            this.Opis = opis();
        }

        public override string opis()
        {
            return ("Naziv: " + Naziv +
                     "\nGodina Proizvodnje: " + Spec.GodinaProizvodnje +
                     "\nModel: " + Spec.Model +
                     "\nMaterijal:" + Spec.Materijal +
                     "\nProizvodjac: " + Spec.Proizvodjac +
                     // napravili smo neki previd oko nasljedjivanja pa mi ne da da povadim ostale atribute iz spec
                     "\nTip klasicne gitare: " + Tip == "Klasicna" ? "Klasicna" : "Akusticna"  
                );
        }
    }
    public enum TipKlasicne
    {
        Klasicna,
        Akusticna
    }
}
