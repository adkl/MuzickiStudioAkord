using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Media.Imaging;

namespace MuzickiStudioAkord.Models
{
    public class ElektricnaGitara : Gitara
    {
        public TipElektronika Tip { get; set; }

        public SpecElektricna Spec { get; set; }

        public ElektricnaGitara(int serijskiBroj, string naziv, double cijena, SpecElektricna spec, string slika, TipElektronika tip)
            :base(serijskiBroj, naziv, cijena, slika)
        {
            this.Tip = tip;
            this.Spec = spec;
            this.Opis = opis();
        }

        public override string opis()
        {
            return ( "Naziv: " + Naziv + 
                     "\nGodina Proizvodnje: " + Spec.GodinaProizvodnje +
                     "\nModel: " + Spec.Model +
                     "\nMaterijal:" + Spec.Materijal +
                     "\nProizvodjac: " + Spec.Proizvodjac +
                     "\nBroj zica: " + Spec.BrojZica +
                     "\nElektronika: " + Spec.Elektronika +
                     "\nMost: " + Spec.Most +
                     "\nPickuup: " + Spec.PickUp +
                     "\nVrat: " + Spec.Vrat +
                     // napravili smo neki previd oko nasljedjivanja pa mi ne da da povadim ostale atribute iz spec
                     "\nTip elektricne gitare: " + (Tip == TipElektronika.Elektricna ? "Elektricna" : "Bass")
                   );
        }
    }
    public enum TipElektronika
    {
        Elektricna,
        Bass
    }
}
