using MuzickiStudioAkord.DAL;
using MuzickiStudioAkord.Models;
using MuzickiStudioAkord.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MuzickiStudioAkord.ViewModels
{
    public class KorpaViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private DataBaseKlijenti dbKlijenti;
        public Klijent KupovinaKlijent { get; set; }
        public KreditnaKartica KupovinaKartica { get; set; }
        private bool zavrsio;

        public bool Zavrsio
        {
            get { return zavrsio; }
            set { zavrsio = value; OnPropertyChanged("Zavrsio"); }
        }

        public ICommand KupovinaNoviKlijent { get; set; }
        public ICommand KupovinaStariKlijent { get; set; }
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }


        public KorpaViewModel()
        {
            dbKlijenti = new DataBaseKlijenti(Resources.BazaPassword);
            Username = String.Empty;
            Password = String.Empty;
            KupovinaKlijent = new Klijent();
            KupovinaKartica = new KreditnaKartica();
            KupovinaNoviKlijent = new RelayCommand(potvrdiNoviKlijent);
            KupovinaStariKlijent = new RelayCommand(potvrdiStariKlijent);
            Zavrsio = false;
        }

        private void potvrdiStariKlijent(object obj)
        {
            KupovinaKlijent.Kartica = KupovinaKartica;
            if (dbKlijenti.daLiPostoji(Username, Password))
            {
                System.Windows.MessageBox.Show("Kupovina uspjesna!", "Kupovina", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Asterisk);
                Zavrsio = true;

            }
            else System.Windows.MessageBox.Show("Klijent ne postoji. Molimo izaberite da ste novi klijent i izvsite registraciju!", "Kupovina", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }

        private void potvrdiNoviKlijent(object obj)
        {
            Random r = new Random();
            int potrosacka = r.Next(1111, 9999999);
            while (dbKlijenti.postojiPotrosacka(potrosacka) == false)
                potrosacka = r.Next(1111, 9999999);

            KupovinaKlijent.PotrosackaKarticaID = potrosacka;
            if (KupovinaKlijent.IsValid && KupovinaKartica.IsValid)
            {
                KupovinaKlijent.Kartica = KupovinaKartica;
                if (dbKlijenti.dodaj(KupovinaKlijent))
                {
                    System.Windows.MessageBox.Show("Kupovina uspjesna!" + Environment.NewLine + "Vasa potrosacka kartica: " + potrosacka, "Kupovina", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Asterisk);
                    Zavrsio = true;
                }
                else
                {
                    System.Windows.MessageBox.Show("Kupovina nije uspjela. Korisnik vec postoji.", "Kupovina", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Asterisk);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Kupovina nije uspjela. Pokusajte ponovo.", "Kupovina", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Asterisk);
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

        protected string getValidationError(string propertyName)
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

        private string validirajUsername()
        {
            if (Username == String.Empty) return "Unesite username";
            return null;
        }

        private string validirajPassword()
        {
            if (Password == String.Empty) return "Unesite password";
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
