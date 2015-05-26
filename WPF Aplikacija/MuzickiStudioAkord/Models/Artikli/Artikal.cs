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
    public abstract class Artikal : INotifyPropertyChanged, IDataErrorInfo
    {
        private int serijskiBroj;
        public int SerijskiBroj
        {
            get { return serijskiBroj; }
            set { serijskiBroj = value; OnPropertyChanged("SerijskiBroj"); }
        }
        
        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
        }

        private double cijena;
        public double Cijena
        {
            get { return cijena; }
            set { cijena = value; OnPropertyChanged("Cijena"); }
        }

        public Specifikacija Spec { get; set; }
        private BitmapImage slika;
        public BitmapImage Slika
        {
            get { return slika; }
            set { slika = value; OnPropertyChanged("Slika"); }
        }

        static readonly string[] validateProperties =
        {
            "SerijskiBroj", "Naziv", "Cijena"
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
                case "SerijskiBroj":
                    error = validirajSerijskiBroj();
                    break;
                case "Naziv":
                    error = validirajNaziv();
                    break;
                case "Cijena":
                    error = validirajCijenu();
                    break;
            }
            return error;
        }
        private string validirajSerijskiBroj()
        {
            if (SerijskiBroj == 0)
                return "Unesite serijski broj";
            return null;
        }
        private string validirajCijenu()
        {
            if (Cijena == 0)
                return "Unesite cijenu";
            return null;
        }

        private string validirajNaziv()
        {
            if (String.IsNullOrEmpty(Naziv))
                return "Unesite naziv";
            return null;
        }


        public Artikal(int serijskiBroj, string naziv, double cijena, Specifikacija spec, BitmapImage slika)
        {
            this.SerijskiBroj = serijskiBroj;
            this.Naziv = naziv;
            this.Spec = spec;
            this.Slika = slika;
        }

        public abstract string dajSpecifikaciju();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public Artikal()
        {
        }
    }
}
