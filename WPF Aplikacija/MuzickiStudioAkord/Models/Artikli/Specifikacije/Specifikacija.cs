using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public abstract class Specifikacija : INotifyPropertyChanged, IDataErrorInfo
    {
        private int godinaProizvodnje;

        public int GodinaProizvodnje
        {
            get { return godinaProizvodnje; }
            set { godinaProizvodnje = value; OnPropertyChanged("GodinaProizvodnje"); }
        }

        private string proizvodjac;

        public string Proizvodjac
        {
            get { return proizvodjac; }
            set { proizvodjac = value; OnPropertyChanged("Proizvodjac"); }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; OnPropertyChanged("Model"); }
        }

        private string materijal;

        public string Materijal
        {
            get { return materijal; }
            set { materijal = value; OnPropertyChanged("Materijal"); }
        }
        static readonly string[] validateProperties =
        {
            "GodinaProizvodnje", "Proizvodjac", "Model", "Materijal"
        };
        public virtual bool IsValid
        {
            get
            {
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

        string IDataErrorInfo.Error
        {
            get { return null; }
        }
        //Ponasa se tako da ako se vrati null nema errora ako se vrati neka vrijednost validacija nije uspjela
        string IDataErrorInfo.this[string propertyName]
        {
            get { return getValidationError(propertyName); }
        }
        protected virtual string getValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "GodinaProizvodnje":
                    error = validirajGodinaProizvodje();
                    break;
                case "Proizvodjac":
                    error = validirajProizvodjac();
                    break;
                case "Model":
                    error = validirajModel();
                    break;
                case "Materijal":
                    error = validirajMaterijal();
                    break;
            }
            return error;
        }

        private string validirajGodinaProizvodje()
        {
            if (GodinaProizvodnje <= 0)
                return "Unesite godinu proizvodnje";
            return null;
        }

        private string validirajModel()
        {
            if (String.IsNullOrEmpty(Model))
                return "Unesite model";
            return null;
        }

        private string validirajProizvodjac()
        {
            if (String.IsNullOrEmpty(Proizvodjac))
                return "Unesite proizvodjac";
            return null;
        }

        private string validirajMaterijal()
        {
            if (String.IsNullOrEmpty(Materijal))
                return "Unesite materijal";
            return null;
        }
        public Specifikacija(int godinaProizvodnje, string proizvodjac, string model, string materijal)
        {
            this.GodinaProizvodnje = godinaProizvodnje;
            this.Proizvodjac = proizvodjac;
            this.Model = model;
            this.Materijal = materijal;
        }
        public Specifikacija()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
