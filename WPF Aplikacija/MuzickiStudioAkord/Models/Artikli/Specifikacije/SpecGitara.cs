using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public abstract class SpecGitara : Specifikacija, INotifyPropertyChanged, IDataErrorInfo
    {
        private int brojZica;

        public int BrojZica
        {
            get { return brojZica; }
            set { brojZica = value; }
        }

        public SpecGitara(int godinaProizvodnje, string proizvodjac, string model, string materijal, int brojZica)
            : base(godinaProizvodnje, proizvodjac, model, materijal)
        {
            this.BrojZica = brojZica;
        }
        public SpecGitara()
            :base()
        {

        }
    }
}
