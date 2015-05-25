using MuzickiStudioAkord.DAL;
using MuzickiStudioAkord.Models;
using MuzickiStudioAkord.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MuzickiStudioAkord.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string loginUsername;
        public string LoginUsername
        {
            get
            {
                return loginUsername;
            }
            set
            {
                loginUsername = value;
                OnPropertyChanged("LoginUsername");
            }
        }
        private string loginName;
        public string LoginName
        {
            get
            {
                return loginName;
            }
            set
            {
                loginName = value;
                OnPropertyChanged("LoginName");
            }
        }

        private bool ulogovanKaoAdmin = false;
        public bool UlogovanKaoAdmin {
            get { return ulogovanKaoAdmin; }
            set 
            { 
                ulogovanKaoAdmin = value; 
                OnPropertyChanged("UlogovanKaoAdmin"); 
            } 
        }
        public DataBaseVlasnici dbVlasnici { get; set; }
        public DataBaseUposlenici dbUposlenici { get; set; }
        public ICommand Login { get; set; }

        public Vlasnik Admin { get; set; }

        public Uposlenik Radnik { get; set; }

        public Action CloseAction { get; set; }

        public void login(Object parametar)
        {
            dbVlasnici = new DataBaseVlasnici(Resources.BazaPassword);
            dbUposlenici = new DataBaseUposlenici(Resources.BazaPassword);
            var vlasnici = dbVlasnici.dajSve();
            var uposlenici = dbUposlenici.dajSve();

            string pw = ((PasswordBox)parametar).Password;
            //Admin.Password = pw;
            string username = LoginUsername;
            


            foreach (Vlasnik v in vlasnici)
            {
                //if (v.Username == Admin.Username && v.Password == Admin.Password)
                if(v.Username == username && v.Password == pw)
                {
                    Admin.Ime = v.Ime;
                    Admin.Prezime = v.Prezime;
                    Admin.Jmbg = v.Jmbg;
                    Admin.Adresa = v.Adresa;
                    Admin.DatumRodjenja = v.DatumRodjenja;
                    Admin.BrojTelefona = v.BrojTelefona;
                    Admin.Email = v.Email;
                    Admin.Password = v.Password;
                    Admin.Username = v.Username;
                    UlogovanKaoAdmin = true;
                    LoginName = Admin.Ime;
                    return;
                }
            }
            foreach (Uposlenik u in uposlenici)
            {
                //if (u.Username == Admin.Username && u.Password == Admin.Password)
                if(u.Username == username && u.Password == pw)
                {
                    Radnik.Ime = u.Ime;
                    Radnik.Prezime = u.Prezime;
                    Radnik.Jmbg = u.Jmbg;
                    Radnik.Adresa = u.Adresa;
                    Radnik.DatumRodjenja = u.DatumRodjenja;
                    Radnik.BrojTelefona = u.BrojTelefona;
                    Radnik.Email = u.Email;
                    Radnik.Password = u.Password;
                    Radnik.Username = u.Username;
                    UlogovanKaoAdmin = false;
                    LoginName = Radnik.Ime;
                    return;
                }
            }
            System.Windows.Forms.MessageBox.Show("Login podaci neispravni! Pokusajte ponovo");
            //CloseAction();

        }

        public MainWindowViewModel()
        {
            Login = new RelayCommand(login);
            Admin = new Vlasnik();
            Radnik = new Uposlenik();
            
        }


        #region INPC implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
