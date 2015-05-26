using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MuzickiStudioAkord.Models
{
    public class Pojacalo : Artikal
    {
        public SpecPojacalo SpecPo { get; set; }
        public Pojacalo(int serijskiBroj, string naziv, double cijena, SpecPojacalo spec, BitmapImage slika)
            : base(serijskiBroj, naziv, cijena,spec, slika)
        {
            this.SpecPo = spec;
        }
        public Pojacalo()
            :base()
        {

        }
        public override string dajSpecifikaciju()
        {
            return ("Naziv: " + Naziv +
                      "\nGodina Proizvodnje: " + Spec.GodinaProizvodnje +
                      "\nModel: " + Spec.Model +
                      "\nMaterijal: " + Spec.Materijal +
                      "\nProizvodjac: " + Spec.Proizvodjac +
                      "\nBroj kanala: " + SpecPo.BrojKanala + 
                      "\nZvucnik: " + SpecPo.Zvucnik +
                      "\nUlaz za slusalice: " + SpecPo.UlazZaSlusalice
                 );
        }
    }
}
