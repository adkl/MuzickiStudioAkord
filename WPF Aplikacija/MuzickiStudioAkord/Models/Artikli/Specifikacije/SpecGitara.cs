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
            set { brojZica = value; OnPropertyChanged("BrojZica"); }
        }
        static readonly string[] validateProperties =
        {
            "BrojZica"
        };
        protected override string getValidationError(string property)
        {
            string error = base.getValidationError(property);
            if (property == "BrojZica") error = validirajBrojZica();
            return error;

        }

        private string validirajBrojZica()
        {
            if (BrojZica == 0) return "Broj zica nije validan (4,5,6,12)";
            return null;
        }
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
        string IDataErrorInfo.Error
        {
            get { return null; }
        }
        //Ponasa se tako da ako se vrati null nema errora ako se vrati neka vrijednost validacija nije uspjela
        string IDataErrorInfo.this[string propertyName]
        {
            get { return getValidationError(propertyName); }
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
