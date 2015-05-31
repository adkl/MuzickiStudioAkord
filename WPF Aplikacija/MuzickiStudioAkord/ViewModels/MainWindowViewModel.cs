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
using System.Windows.Data;
using System.Windows.Input;

namespace MuzickiStudioAkord.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region visibilities declaration
        private bool visibilityRadnik;

        public bool VisibilityRadnik
        {
            get { return visibilityRadnik; }
            set { visibilityRadnik = value; OnPropertyChanged("VisibilityRadnik"); }
        }
        private bool visibilityGost;

        public bool VisibilityGost
        {
            get { return visibilityGost; }
            set { visibilityGost = value; OnPropertyChanged("VisibilityGost"); }
        }

        private bool visibilityVlasnik;

        public bool VisibilityVlasnik
        {
            get { return visibilityVlasnik; }
            set { visibilityVlasnik = value; OnPropertyChanged("VisibilityVlasnik"); }
        }
        #endregion

//--------------------------------------------------------------------------------------------------------

        public Uposlenik DodaniUposlenik { get; set; }
        public ICommand DodajRadnika { get; set; }
        public void dodajRadnika(Object parametar)
        {
            Uposlenik u = new Uposlenik(DodaniUposlenik.Ime,
                                        DodaniUposlenik.Prezime,
                                        DodaniUposlenik.Jmbg,
                                        DodaniUposlenik.Adresa,
                                        DodaniUposlenik.BrojTelefona,
                                        DodaniUposlenik.Username,
                                        DodaniUposlenik.Jmbg);

            dbUposlenici.dodaj(u);
            restart();
        }

        private void restart()
        {
            DodaniUposlenik = new Uposlenik();
        }

//-------------------------------------------------------------------------------------------------------

        private bool logiranBiloko;

        public bool LogiranBiloKo
        {
            get { return logiranBiloko; }
            set { logiranBiloko = value;
            OnPropertyChanged("LogiranBiloKo");
            }
        }
        


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
        public bool UlogovanKaoAdmin
        {
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
        public ICommand Logout { get; set; }

        public Vlasnik Admin { get; set; }

        public Uposlenik Radnik { get; set; }


        public void login(Object parametar)
        {
            var vlasnici = dbVlasnici.dajSve();
            var uposlenici = dbUposlenici.dajSve();

            string pw = ((PasswordBox)parametar).Password;
            //Admin.Password = pw;
            string username = LoginUsername;



            foreach (Vlasnik v in vlasnici)
            {
                //if (v.Username == Admin.Username && v.Password == Admin.Password)
                if (v.Username == username && v.Password == pw)
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
                    ((PasswordBox)parametar).Password = "";
                    VisibilityVlasnik = true;
                    VisibilityRadnik = false;
                    VisibilityGost = false;
                    LogiranBiloKo = true;
                    return;
                }
            }
            foreach (Uposlenik u in uposlenici)
            {
                //if (u.Username == Admin.Username && u.Password == Admin.Password)
                if (u.Username == username && u.Password == pw)
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
                    ((PasswordBox)parametar).Password = "";
                    VisibilityGost = false;
                    VisibilityRadnik = true;
                    VisibilityVlasnik = false;
                    LogiranBiloKo = true;
                    return;
                }
            }
            VisibilityGost = true;
            VisibilityRadnik = false;
            VisibilityVlasnik = false;
            System.Windows.Forms.MessageBox.Show("Login podaci neispravni! Pokusajte ponovo");
            //CloseAction();

        }

        public void logout(Object parametar)
        {
            //((TextBlock)parametar).Text = "Gost";
            LoginName = "Gost";
            UlogovanKaoAdmin = false;
            Admin = new Vlasnik();
            Radnik = new Uposlenik();
            VisibilityGost = true;
            VisibilityRadnik = false;
            VisibilityVlasnik = false;
            LogiranBiloKo = false;
        }

//----------------------------------------------------------------------------------------------------------------------------

        public MainWindowViewModel()
        {
            Login = new RelayCommand(login);
            Logout = new RelayCommand(logout);
            DodajRadnika = new RelayCommand(dodajRadnika);
            DodaniUposlenik = new Uposlenik();
            dbVlasnici = new DataBaseVlasnici(Resources.BazaPassword);
            dbUposlenici = new DataBaseUposlenici(Resources.BazaPassword);
            Admin = new Vlasnik();
            Radnik = new Uposlenik();
            LoginName = "Gost";
            VisibilityGost = true;
            VisibilityRadnik = false;
            VisibilityVlasnik = false;
            LogiranBiloKo = false;
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

        public ICommand PasswordChange { get; set; }
    }
}
