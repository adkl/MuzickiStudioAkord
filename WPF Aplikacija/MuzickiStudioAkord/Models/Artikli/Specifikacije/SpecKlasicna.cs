using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class SpecKlasicna : SpecGitara, INotifyPropertyChanged, IDataErrorInfo
    {
        private string masinica;

        public string Masinica
        {
            get { return masinica; }
            set { masinica = value; OnPropertyChanged("Masinica"); }
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
        static readonly string[] validateProperties =
        {
           "Masinica"
        };
        protected override string getValidationError(string property)
        {
            string error = base.getValidationError(property);
            if (property == "Masinica") error = validirajMasinica();
            return error;

        }

        private string validirajMasinica()
        {

            if (string.IsNullOrEmpty(Masinica)) return "Unesite masinicu gitare";
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
        public SpecKlasicna(int godinaProizvodnje, string proizvodjac, string model, string materijal, int brojZica, string masinica)
            : base(godinaProizvodnje, proizvodjac, model, materijal, brojZica)
        {
            this.Masinica = masinica;
        }
        public SpecKlasicna()
            :base()
        {

        }
    }
}
