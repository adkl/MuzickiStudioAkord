using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class Uposlenik : Osoba
    {
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string validirajUsername()
        {
            if (String.IsNullOrEmpty(Username) || String.IsNullOrWhiteSpace(Username))
                return "Polje za unos korisnickog imena ne moze biti prazno";

            if(username.Length > 18)
                return "Korisnicko ime ne moze imati vise od 10 karaktera";

            return null;

        }


        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private string validirajPassword()
        {
            if (String.IsNullOrEmpty(Password) || String.IsNullOrWhiteSpace(Password))
                return "Polje za unos lozinke ne moze biti prazno";

            if (password.Length > 32 || password.Length < 4)
                return "Lozinka ne moze imati vise od 32, niti manje od 4 karaktera";

            return null;
        }

        //povezan na : uposlenikViewModel i DBaseSastanci

        public Uposlenik(string firstName, string lastName, string jmbg, string adresa, string brTel, string username, string password) 
            :base(firstName, lastName, jmbg, adresa, brTel)
        {
            this.Username = username;
            this.Password = password;
        }


        private readonly static string[] properties = {"Username", "Password"};
        protected override string  getValidationError(string propertyName)
        {
            string error = null;

            switch (propertyName)
            {
                case "Username" :
                    error = validirajUsername();
                    break;
                case "Password":
                    error = validirajPassword();
                    break;
            }
            return error;
        }

        public bool isValidUposlenik
        {
            get
            {
                foreach (string property in properties)
                {
                    if (getValidationError(property) != null)
                        return false;
                }

                return true;
            }
        }

        public Uposlenik()
        {

        }

    }
}
