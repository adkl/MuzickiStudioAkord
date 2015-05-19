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


        public ElektricnaGitara(int serijskiBroj, string naziv, double cijena, SpecElektricna spec, string slika, TipElektronika tip)
            :base(serijskiBroj, naziv, cijena, spec, slika)
        {
            this.Tip = tip;
            this.Opis = opis();
        }

        public override string opis()
        {
            return ( "Naziv: " + Naziv + 
                     "\nGodina Proizvodnje: " + Spec.GodinaProizvodnje +
                     "\nModel: " + Spec.Model +
                     "\nMaterijal:" + Spec.Materijal +
                     "\nProizvodjac: " + Spec.Proizvodjac +
                     // napravili smo neki previd oko nasljedjivanja pa mi ne da da povadim ostale atribute iz spec
                     "\nTipElektronika: " + (Tip == TipElektronika.Elektricna ? "Elektricna" : "Bass")
                   );
        }
    }
    public enum TipElektronika
    {
        Elektricna,
        Bass
    }
}
