using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MuzickiStudioAkord.Models
{
    public abstract class Gitara : Artikal
    {
        public Gitara(int serijskiBroj, string naziv, double cijena, SpecGitara spec, Image slika)
            :base(serijskiBroj, naziv, cijena, spec, slika)
        {
        }
    }
}
