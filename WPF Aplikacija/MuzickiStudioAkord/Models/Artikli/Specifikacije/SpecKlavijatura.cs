using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class SpecKlavijatura : Specifikacija, IDataErrorInfo
    {
        private int brojTipki;

        public int BrojTipki
        {
            get { return brojTipki; }
            set { brojTipki = value; OnPropertyChanged("BrojTipki"); }
        }

        private string zvucnik;

        public string Zvucnik
        {
            get { return zvucnik; }
            set { zvucnik = value; OnPropertyChanged("Zvucnik"); }
        }
        private double tezina;

        public double Tezina
        {
            get { return tezina; }
            set { tezina = value; OnPropertyChanged("Tezina"); }
        }


        private string napajanje;

        public string Napajanje
        {
            get { return napajanje; }
            set { napajanje = value; OnPropertyChanged("Napajanje"); }
        }


        public SpecKlavijatura(int godinaProizvodnje, string proizvodjac, string model, string materijal, int brojTipki, string zvucnik, double tezina, string napajanje)
            : base(godinaProizvodnje, proizvodjac, model, materijal)
        {
            this.BrojTipki = brojTipki;
            this.Zvucnik = zvucnik;
            this.Tezina = tezina;
            this.Napajanje = napajanje;
        }
        public SpecKlavijatura()
            : base()
        {

        }


        static readonly string[] validateProperties =
        {
            "BrojTipki", "Zvucnik", "Tezina", "Napajanje"
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
            if (property == "BrojTipki") error = validirajBrojTipki();
            else if (property == "Zvucnik") error = validirajZvucnik();
            else if (property == "Tezina") error = validirajTezinu();
            else if (property == "Napajanje") error = validirajNapajanje();
            return error;

        }

        private string validirajNapajanje()
        {
            if (string.IsNullOrEmpty(Napajanje)) return "Unesite napajanje";
            return null;
        }

        private string validirajTezinu()
        {
            if (Tezina == 0) return "Unesite tezinu";
            return null;
        }

        private string validirajZvucnik()
        {
            if (string.IsNullOrEmpty(Zvucnik)) return "Unesite zvucnik";
            return null;
        }

        private string validirajBrojTipki()
        {
            if (BrojTipki == 0) return "Unesite tezinu";
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
