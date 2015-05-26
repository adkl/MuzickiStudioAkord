using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class SpecElektricna : SpecGitara, INotifyPropertyChanged, IDataErrorInfo
    {
        private string vrat;

        public string Vrat
        {
            get { return vrat; }
            set { vrat = value; }
        }
        private string most;

        public string Most
        {
            get { return most; }
            set { most = value; }
        }
        private string pickup;

        public string PickUp
        {
            get { return pickup; }
            set { pickup = value; }
        }
        private string elektronika;

        public string Elektronika
        {
            get { return elektronika; }
            set { elektronika = value; }
        }
        

        public SpecElektricna(int godinaProizvodnje, string proizvodjac, string model, string materijal, int brojZica, string vrat, string most, string pickup, string elektronika)
            : base(godinaProizvodnje, proizvodjac, model, materijal, brojZica)
        {
            this.Vrat = vrat;
            this.Most = most;
            this.PickUp = pickup;
            this.Elektronika = elektronika;
        }
        public SpecElektricna()
            :base()
        {

        }
    }
}
