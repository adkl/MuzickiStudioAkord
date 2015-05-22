using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public abstract class Osoba : INotifyPropertyChanged, IDataErrorInfo
    {
        private string ime;
        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChanged("Ime"); }
        }

        private string prezime;
        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; OnPropertyChanged("Prezime"); }


        }

        private string validirajJmbg()
        {
            if (String.IsNullOrEmpty(Jmbg))
                return "Unesite JMBG";
            if (Jmbg.Length != 13)
                return "JMBG mora imati 13 cifara";

            foreach (char x in Jmbg)
            {
                if (x < '0' || x > '9') return "JMBG ne smije sadrzavati slova";

            }

            int a = Jmbg[0] - '0'; int h = Jmbg[7] - '0'; int d = Jmbg[3] - '0'; int k = Jmbg[10] - '0';
            int g = Jmbg[6] - '0'; int c = Jmbg[2] - '0'; int j = Jmbg[9] - '0';
            int b = Jmbg[1] - '0'; int i = Jmbg[8] - '0'; int e = Jmbg[4] - '0';
            if ((11 - ((7 * (a + g) + 6 * (b + h) + 5 * (c + i) + 4 * (d + j) + 3 * (e + k)
                + 2 * (Jmbg[5] - '0' + Jmbg[11] - '0')) % 11)) != Jmbg[12] - '0')
                return "JMBG nije validan";

            return null;
        }

        private string jmbg;
        public string Jmbg
        {
            get { return jmbg;}
            set { jmbg = value; OnPropertyChanged("Jmbg"); }
        }

        private string adresa;
        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; OnPropertyChanged("Adresa"); }
        }

        private string validirajEmail()
        {
            if (String.IsNullOrEmpty(Email))
                return "Unesite Email";
            if (!Email.Contains('@') || !Email.Contains('.'))
                return "Email nije validan";
            //najmanje 3 karaktera prije @ u mail-u
            if (Email.Substring(0, Email.IndexOf('@')).Length < 3)
                return "Email nije validan";
            //najmanje 3 karaktera poslije @ u mail-u
            if (Email.Substring(Email.IndexOf('@'), Email.Length - Email.IndexOf('@')).Length < 3)
                return "Email nije validan";
            //dodati provjeru nedozvoljenih znakova

            return null;
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        private string brojTelefona;

        public string BrojTelefona
        {
            get { return brojTelefona; }
            set { brojTelefona = value; OnPropertyChanged("BrojTelefona"); }
        }

        private DateTime datumRodjenja;
        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value;}
        }

        public Osoba(string firstName, string lastName, string jmbg, string adresa, string brTel)
        {
                this.Ime = firstName;
                this.Prezime = lastName;
                this.Jmbg = jmbg;
                this.Adresa = adresa;
                this.DatumRodjenja = new DateTime(Int32.Parse("1" + Jmbg.Substring(4, 3)),
                                                  Int32.Parse(Jmbg.Substring(2, 2)),
                                                  Int32.Parse(Jmbg.Substring(0, 2)));
                this.BrojTelefona = brTel;
        }

        public Osoba()
        {

        }
        static readonly string[] validateProperties =
        {
            "Jmbg", "Email", "BrojTelefona", "Ime", "Prezime", "Adresa"
        };
        public bool IsValidBase
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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

        string getValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Jmbg":
                    error = validirajJmbg();
                    break;
                case "Email":
                    error = validirajEmail();
                    break;
                case "BrojTelefona":
                    error = validirajBrojTelefona();
                    break;
                case "Ime":
                    error = validirajIme();
                    break;
                case "Prezime":
                    error = validirajPrezime();
                    break;
                case "Adresa":
                    error = validirajAdresa();
                    break;
            }
            return error;
        }

        private string validirajAdresa()
        {
            if (String.IsNullOrEmpty(Adresa))
                return "Unesite adresu";
            return null;
        }

        private string validirajPrezime()
        {
            if (String.IsNullOrEmpty(Prezime))
                return "Unesite prezime";
            foreach (char x in Prezime)
            {
                if (x >= '0' && x <= '9') return "Nije validno prezime";

            }
            return null;
        }

        private string validirajIme()
        {
            if (String.IsNullOrEmpty(Ime))
                return "Unesite Ime";
            foreach (char x in Ime)
            {
                if (x >= '0' && x <= '9') return "Nije validno ime";

            }
            return null;
        }

        private string validirajBrojTelefona()
        {
            if (String.IsNullOrEmpty(BrojTelefona))
                return "Unesite broj telefona";

            foreach (char x in BrojTelefona)
            {
                if (x < '0' || x > '9') return "Nije validan broj telefona";

            }
            return null;
        }
    }
}
