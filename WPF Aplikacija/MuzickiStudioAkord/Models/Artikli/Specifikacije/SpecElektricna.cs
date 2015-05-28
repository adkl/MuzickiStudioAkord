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
            set { vrat = value; OnPropertyChanged("Vrat"); }
        }
        private string most;

        public string Most
        {
            get { return most; }
            set { most = value; OnPropertyChanged("Most"); }
        }
        private string pickup;

        public string PickUp
        {
            get { return pickup; }
            set { pickup = value; OnPropertyChanged("PickUp"); }
        }
        private string elektronika;

        public string Elektronika
        {
            get { return elektronika; }
            set { elektronika = value; OnPropertyChanged("Elektronika"); }
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
        static readonly string[] validateProperties =
        {
            "Vrat", "Most", "PickUp", "Elektronika"
        };
        public override bool IsValid
        {
            get
            {
                if (base.IsValid == false) return false;
                foreach (string property in validateProperties)
                {
                    if (getValidationError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        protected override string getValidationError(string property)
        {
            string error = base.getValidationError(property);
            if (property == "Vrat") error = validirajVrat();
            else if (property == "Most") error = validirajMost();
            else if (property == "PickUp") error = validirajPickUp();
            else if (property == "Elektronika") error = validirajElektroniku();
            return error;

        }

        private string validirajElektroniku()
        {
            if(string.IsNullOrEmpty(Elektronika)) return "Unesite elektroniku gitare";
            return null;
        }

        private string validirajPickUp()
        {
            if (string.IsNullOrEmpty(PickUp)) return "Unesite pickUp gitare";
            return null;
        }

        private string validirajMost()
        {
            if (string.IsNullOrEmpty(Most)) return "Unesite most gitare";
            return null;
        }

        private string validirajVrat()
        {
            if (String.IsNullOrEmpty(Vrat)) return "Unesite tip vrata gitare";
            return null;
        }
        string IDataErrorInfo.Error
        {
            get { return null; }
        }
        //Ponasa se tako da ako se vrati null nema errora ako se vrati neka vrijednost validacija nije uspjela
        string IDataErrorInfo.this[string propertyName]
        {
            get { return getValidationError(propertyName); }
        }
    }
}
