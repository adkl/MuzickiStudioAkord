using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MuzickiStudioAkord.Models
{
    public class Klavijatura : Artikal
    {
        public SpecKlavijatura SpecKl { get; set; }
        public Klavijatura(int serijskiBroj, string naziv, double cijena, SpecKlavijatura spec, BitmapImage slika)
            : base(serijskiBroj, naziv, cijena,spec, slika)
        {
            this.SpecKl = spec;
        }
        public Klavijatura()
            :base()
        {
            SpecKl = new SpecKlavijatura();
            Spec = new SpecKlavijatura();
        }
        public override string dajSpecifikaciju()
        {
            return ("Naziv: " + Naziv +
                     "\nGodina Proizvodnje: " + Spec.GodinaProizvodnje +
                     "\nModel: " + Spec.Model +
                     "\nMaterijal:" + Spec.Materijal +
                     "\nProizvodjac: " + Spec.Proizvodjac +
                     "\nBroj tipki :" + SpecKl.BrojTipki +
                     "\nZvucnik: " + SpecKl.Zvucnik +
                     "\nNapajanje: " + SpecKl.Napajanje
                );
        }
    }
}
