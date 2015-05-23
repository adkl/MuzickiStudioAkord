using MuzickiStudioAkord.DAL;
using MuzickiStudioAkord.Models;
using MuzickiStudioAkord.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MuzickiStudioAkord.ViewModels
{
    enum LogiranKao
    {
        Gost, Uposlenik, Vlasnik
    }
    public class MainWindowViewModel
    {
        public bool UlogovanKaoAdmin { get; set; }
        public DataBaseVlasnici dbVlasnici { get; set; }
        public DataBaseUposlenici dbUposlenici { get; set; }
        public ICommand Login { get; set; }

        public Vlasnik Admin { get; set; }

        public Uposlenik Radnik { get; set; }

        public Action CloseAction { get; set; }

        public void login(Object parametar)
        {
            var vlasnici = dbVlasnici.dajSve();
            var uposlenici = dbUposlenici.dajSve();


            foreach (Vlasnik v in vlasnici)
            {
                if (v.Username == Admin.Username && v.Password == Admin.Password)
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
                    return;
                }
            }
            foreach (Uposlenik u in uposlenici)
            {
                if (u.Username == Admin.Username && u.Password == Admin.Password)
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
                    UlogovanKaoAdmin = true;
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
            dbVlasnici = new DataBaseVlasnici(Resources.BazaPassword);
            dbUposlenici = new DataBaseUposlenici(Resources.BazaPassword);
        }


    }
}
