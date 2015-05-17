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
        }
    }
    public enum TipElektronika
    {
        Elektricna,
        Bass
    }
}
