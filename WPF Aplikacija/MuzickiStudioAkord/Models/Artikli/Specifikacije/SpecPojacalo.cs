using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MuzickiStudioAkord.Models
{
    public class SpecPojacalo : Specifikacija, IDataErrorInfo
    {
        private string zvucnik;

        public string Zvucnik
        {
            get { return zvucnik; }
            set { zvucnik = value; OnPropertyChanged("Zvucnik"); }
        }

        private int brojKanala;

        public int BrojKanala
        {
            get { return brojKanala; }
            set { brojKanala = value; OnPropertyChanged("BrojKanala"); }
        }

        private bool ulazZaSlusalice;

        public bool UlazZaSlusalice
        {
            get { return ulazZaSlusalice; }
            set { ulazZaSlusalice = value; OnPropertyChanged("UlazZaSlusalice"); }
        }
        static readonly string[] validateProperties =
        {
            "BrojKanala", "Zvucnik", "UlazZaSlusalice"
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
            if (property == "BrojKanala") error = validirajBrojKanala();
            else if (property == "Zvucnik") error = validirajZvucnik();
            else if (property == "UlazZaSlusalice") error = validirajUlazZaSlusalice();
            return error;

        }

        private string validirajUlazZaSlusalice()
        {
            return null;
        }

        private string validirajZvucnik()
        {
            if (string.IsNullOrEmpty(Zvucnik)) return "Unesite zvucnik";
            return null;
        }

        private string validirajBrojKanala()
        {
            if (BrojKanala == 0) return "Unesite broj kanala";
            return null;
        }

        public SpecPojacalo(int godinaProizvodnje, string proizvodjac, string model, string materijal, string zvucnik, int brojkanala, bool ulazZaSlusalice)
            :base(godinaProizvodnje, proizvodjac, model, materijal)
        {
            this.Zvucnik = zvucnik;
            this.BrojKanala = brojkanala;
            this.UlazZaSlusalice = ulazZaSlusalice;
        }
        public SpecPojacalo()
            :base()
        {

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
