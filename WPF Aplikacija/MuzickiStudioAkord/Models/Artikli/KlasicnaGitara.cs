using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MuzickiStudioAkord.Models
{
    public class KlasicnaGitara : Gitara
    {
        public TipKlasicne Tip { get; set; }
        public SpecKlasicna SpecKL { get; set; }
        public KlasicnaGitara(int serijskiBroj, string naziv, double cijena, SpecKlasicna spec, BitmapImage slika, TipKlasicne tip)
            :base(serijskiBroj, naziv, cijena, spec, slika)
        {
            this.Tip = tip;
            this.SpecKL = spec;
        }
        public KlasicnaGitara()
            :base()
        {
            SpecKL = new SpecKlasicna();
            Spec = new SpecKlasicna();
        }
        public override string dajSpecifikaciju()
        {
            return ("Naziv: " + Naziv +
                    "\nGodina Proizvodnje: " + Spec.GodinaProizvodnje +
                    "\nModel: " + Spec.Model +
                    "\nMaterijal:" + Spec.Materijal +
                    "\nProizvodjac: " + Spec.Proizvodjac +
                    "\nMasinica: "+ SpecKL.Masinica +
                    "\nBroj Zica: "  + SpecKL.BrojZica +
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
