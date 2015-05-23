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
            set { kartica = value; OnPropertyChanged("KreditnaKartica"); }
        }

        private List<Narudzba> narudzbe;

        public List<Narudzba> Narudzbe
        {
            get { return narudzbe; }
            set { narudzbe = value; }
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
            "PotrosackaKarticaID"
        };
        protected override string getValidationError(string property)
        {
            string error = base.getValidationError(property);
            if (property == "PotrosackaKarticaID") error = validirajPotrosackuKarticu();
            return error;

        }
        private string validirajPotrosackuKarticu()
        {
            if (potrosackaKarticaID == 0) return "Unesite broj kartice";
            if (PotrosackaKarticaID < 0 || PotrosackaKarticaID > 9999999) return "Maksimalno 7 cifara";
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
    }
}
