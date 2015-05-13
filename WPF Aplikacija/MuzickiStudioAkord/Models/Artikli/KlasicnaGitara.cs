using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MuzickiStudioAkord.Models
{
    public class KlasicnaGitara : Gitara
    {
        public TipKlasicne Tip { get; set; }

        public KlasicnaGitara(int serijskiBroj, string naziv, double cijena, SpecKlasicna spec, Image slika, TipKlasicne tip)
            :base(serijskiBroj, naziv, cijena, spec, slika)
        {
            this.Tip = tip;
        }
    }
    public enum TipKlasicne
    {
        Klasicne,
        Akusticne
    }
}
