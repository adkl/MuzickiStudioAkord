using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class Vlasnik : Osoba
    {
        private string username;
        public string Username
        {
            get { return username; }
        }

        private string validirajUsername()
        {
            if (String.IsNullOrEmpty(Username) || String.IsNullOrWhiteSpace(Username))
                return "Polje za unos korisnickog imena ne moze biti prazno";

            if (username.Length > 10)
                return "Korisnicko ime ne moze imati vise od 10 karaktera";

            return null;

        }

        private string validirajPassword()
        {
            if (String.IsNullOrEmpty(Password) || String.IsNullOrWhiteSpace(Password))
                return "Polje za unos lozinke ne moze biti prazno";

            if (password.Length > 8 || password.Length < 4)
                return "Lozinka ne moze imati vise od 8, niti manje od 4 karaktera";

            return null;
        }

        public bool isValidVlasnik
        {
            get
            {
                foreach (string property in properties)
                {
                    if (getValidationError(property) != null)
                        return false;
                }

                if (!IsValidBase)
                    return false;

                return true;
            }
        }


        private string password;
        public string Password
        {
            get { return username; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public Vlasnik()
        {

        }

        private readonly static string[] properties = { "Username", "Password" };
        string getValidationError(string propertyName)
        {
            string error = null;



            switch (propertyName)
            {
                case "Username":
                    error = validirajUsername();
                    break;
                case "Password":
                    error = validirajPassword();
                    break;
            }
            return error;
        }

        public Vlasnik(string firstName, string lastName, string jmbg, string adresa, string brTel, string username, string password)
            : base(firstName, lastName, jmbg, adresa, brTel)
        {
            this.username = username;
            this.password = password;
        }

        //vlasnikViewModel i DBaseSastanci
    }
}
