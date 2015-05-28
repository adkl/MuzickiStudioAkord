using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MuzickiStudioAkord.Models
{
    public class ElektricnaGitara : Gitara, INotifyPropertyChanged, IDataErrorInfo
    {
        public TipElektronika Tip { get; set; }

        public SpecElektricna SpecEl { get; set; }

        public ElektricnaGitara(int serijskiBroj, string naziv, double cijena, SpecElektricna spec, BitmapImage slika, TipElektronika tip)
            :base(serijskiBroj, naziv, cijena, spec, slika)
        {
            this.Tip = tip;
            this.SpecEl = spec;
        }
        public ElektricnaGitara()
            :base()
        {
            SpecEl = new SpecElektricna();
            Spec = new SpecElektricna();
        }
        protected override string getValidationError(string property)
        {
            string error = base.getValidationError(property);
            return error;
        }
        public override string dajSpecifikaciju()
        {
            return ("Naziv: " + Naziv +
                     "\nGodina Proizvodnje: " + Spec.GodinaProizvodnje +
                     "\nModel: " + Spec.Model +
                     "\nMaterijal:" + Spec.Materijal +
                    "\nProizvodjac: " + Spec.Proizvodjac +
                     "\nBroj zica: " + SpecEl.BrojZica +
                     "\nElektronika: " + SpecEl.Elektronika +
                     "\nMost: " + SpecEl.Most +
                     "\nPickuup: " + SpecEl.PickUp +
                     "\nVrat: " + SpecEl.Vrat +
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
