using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class Klijent : Osoba
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
            set { kartica = value;}
        }

        private List<Narudzba> narudzbe;

        public List<Narudzba> Narudzbe
        {
            get { return narudzbe; }
            set { narudzbe = value; }
        }
        static readonly string[] validateProperties =
        {
            "PotrosackaKarticaID"
        };
        public bool IsValidKlijent
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
        string getValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "PotrosackaKarticaID":
                    error = validirajPotrosackuKarticu();
                    break;
            }
            return error;
        }
        private string validirajPotrosackuKarticu()
        {
            if (String.IsNullOrEmpty(PotrosackaKarticaID.ToString()))
                return "Unesite potrosacku karticu";
            if (PotrosackaKarticaID.ToString().Length != 7)
                return "Mora imati 7 cifara";
            return null;
        }
        public Klijent(string firstName, string lastName, string jmbg, string adresa, string brTel, int potrosackaID, KreditnaKartica card)
            : base(firstName, lastName, jmbg, adresa, brTel)
        {
            PotrosackaKarticaID = potrosackaID;
            kartica = card;
        }
        public Klijent()
            : base()
        {

        }

    }
}
