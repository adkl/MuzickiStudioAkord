using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
//using System.Windows.Media.Imaging;

namespace MuzickiStudioAkord.Models
{
    public abstract class Gitara : Artikal
    {

        public Gitara(int serijskiBroj, string naziv, double cijena, string slika)
            :base(serijskiBroj, naziv, cijena, slika)
        {
        }
    }
}
