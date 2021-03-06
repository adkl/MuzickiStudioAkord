﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class Vlasnik : Osoba, INotifyPropertyChanged, IDataErrorInfo
    {
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }

        private string validirajUsername()
        {
            if (String.IsNullOrEmpty(Username) || String.IsNullOrWhiteSpace(Username))
                return "Polje za unos korisnickog imena ne moze biti prazno";
            if (Username.Length > 18)
                return "Korisnicko ime ne moze imati vise od 18 karaktera";

            return null;

        }

        private string validirajPassword()
        {
            if (String.IsNullOrEmpty(Password) || String.IsNullOrWhiteSpace(Password))
                return "Polje za unos passworda ne moze biti prazno";

            if (Password.Length > 32 || password.Length < 4)
                return "Lozinka ne moze imati vise od 32, niti manje od 4 karaktera";

            return null;
        }

        public override bool IsValid
        {
            get
            {
                if (!base.IsValid) return false; 
                foreach (string property in properties)
                {
                    if (getValidationError(property) != null)
                        return false;
                }
                return true;
            }
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

        public Vlasnik()
        {

        }

        private readonly static string[] properties = { "Username", "Password" };

        protected override string getValidationError(string propertyName)
        {
            string error = base.getValidationError(propertyName);
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
