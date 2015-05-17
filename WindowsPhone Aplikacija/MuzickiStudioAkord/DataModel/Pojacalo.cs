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
        }
    }
}
