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
    public abstract class Osoba 
    {
        private string ime;
        public string Ime
        {
            get { return ime; }
            set
            {
                if ( !String.IsNullOrEmpty(value.ToString()) )
                    ime = value;
                else
                    throw new Exception("Prazno ime");
            }
        }

        private string prezime;
        public string Prezime
        {
            get { return prezime; }
            set
            {
                if ( !String.IsNullOrEmpty(value.ToString()) )
                    prezime = value;
                else
                    throw new Exception("Prazno prezime");
            }


        }

        private bool validirajJmbg(string pJmbg)
        {
            if (pJmbg.Length != 13)
                return false;

            foreach (char x in pJmbg)
            {
                if (x < '0' || x > '9') return false ;

            }

            int a = pJmbg[0] - '0'; int h = pJmbg[7] - '0'; int d = pJmbg[3] - '0'; int k = pJmbg[10] - '0';
            int g = pJmbg[6] - '0'; int c = pJmbg[2] - '0'; int j = pJmbg[9] - '0';
            int b = pJmbg[1] - '0'; int i = pJmbg[8] - '0'; int e = pJmbg[4] - '0';
            if ((11 - ((7 * (a + g) + 6 * (b + h) + 5 * (c + i) + 4 * (d + j) + 3 * (e + k)
                + 2 * (pJmbg[5] - '0' + pJmbg[11] - '0')) % 11)) != pJmbg[12] - '0')
                return false;

            return true;
        }

        private string jmbg;
        public string Jmbg
        {
            get
            {
                return jmbg;
            }
            set
            {
                if (validirajJmbg(value.ToString()))
                    jmbg = value;
                else
                    throw new Exception("Nevalidan JMBG");
            }
        }

        private string adresa;
        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; } 
        }

        private bool IsValidEmail(string pEmail)
        {
            if (String.IsNullOrEmpty(pEmail))
                return false;
            if ( !pEmail.Contains('@') || !pEmail.Contains('.') )
                return false;
            //najmanje 3 karaktera prije @ u mail-u
            if (pEmail.Substring(0, pEmail.IndexOf('@')).Length < 3)
                return false;
            //najmanje 5 karaktera poslije @ u mail-u
            if (pEmail.Substring(pEmail.IndexOf('@'), pEmail.Length - pEmail.IndexOf('@')).Length < 5)
                return false;
            //dodati provjeru nedozvoljenih znakova
            
            return true;
        }        

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                if (IsValidEmail(value.ToString()))
                    email = value;
                else
                    throw new Exception("Nevalidan Email");

            }
        }

        private string brojTelefona;

        public string BrojTelefona
        {
            get { return brojTelefona; }
            set { brojTelefona = value; }
        }

        private DateTime datumRodjenja;
        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; }
        }

        public Osoba(string firstName, string lastName, string jmbg, string adresa, string brTel)
        { 
            try
            {
                this.Ime = firstName;
                this.Prezime = lastName;
                this.Jmbg = jmbg;
                this.Adresa = adresa;
                this.DatumRodjenja = new DateTime(Int32.Parse("1" + Jmbg.Substring(4,3)),
                                                  Int32.Parse(Jmbg.Substring(2,2)), 
                                                  Int32.Parse(Jmbg.Substring(0,2)));
                this.BrojTelefona = brTel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Osoba()
        {

        }








    }
}
