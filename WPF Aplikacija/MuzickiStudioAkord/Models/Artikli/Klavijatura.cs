using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MuzickiStudioAkord.Models
{
    public class Klavijatura : Artikal
    {
        public Klavijatura(int serijskiBroj, string naziv, double cijena, SpecKlavijatura spec, Image slika)
            : base(serijskiBroj, naziv, cijena, spec, slika)
        {
        }
    }
}
