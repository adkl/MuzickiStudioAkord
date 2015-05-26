using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MuzickiStudioAkord.Models
{
    public abstract class Gitara : Artikal, INotifyPropertyChanged, IDataErrorInfo
    {
        public SpecGitara SpecGitara { get; set; }
        public Gitara(int serijskiBroj, string naziv, double cijena, SpecGitara spec, BitmapImage slika)
            :base(serijskiBroj, naziv, cijena,spec, slika)
        {
            this.SpecGitara = spec;
        }
        public Gitara()
            :base()
        {

        }
    }
}
