using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class Klijent : Osoba, INotifyPropertyChanged, IDataErrorInfo
    {
        private int potrosackaKarticaID;
        public int PotrosackaKarticaID
        {
            get { return potrosackaKarticaID; }
            set { potrosackaKarticaID = value; OnPropertyChanged("PotrosackaKarticaID"); }
        }

        private KreditnaKartica kartica;
        internal KreditnaKartica Kartica
        {
            get { return kartica; }
            set { kartica = value; }
        }

        private List<Narudzba> narudzbe;

        public List<Narudzba> Narudzbe
        {
            get { return narudzbe; }
            set { narudzbe = value; }
        }

        public bool IsValid
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
        static readonly string[] validateProperties =
        {
            "Jmbg", "Email", "BrojTelefona", "Ime", "Prezime", "Adresa", "PotrosackaKarticaID"
        };
        protected override string getValidationError(string property)
        {
            string error = base.getValidationError(property);
            if (property == "PotrosackaKarticaID") error = validirajPotrosackuKarticu();
            return error;

        }
        private string validirajPotrosackuKarticu()
        {
            if (PotrosackaKarticaID < 1000 || PotrosackaKarticaID > 9999) return "Mora biti 4 cifre";
            return null;
        }
        public Klijent(string firstName, string lastName, string jmbg, string adresa, string brTel, int potrosackaID, KreditnaKartica card)
            : base(firstName, lastName, jmbg, adresa, brTel)
        {
            this.PotrosackaKarticaID = potrosackaID;
            this.Kartica = card;
        }
        public Klijent()
            : base()
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
