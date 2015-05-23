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
        Gost,Uposlenik,Vlasnik
    }
    public class MainWindowViewModel
    {
        public string LoginUserName { get; set; }
        public string LoginPassWord { get; set; }
        public DataBaseVlasnici dbVlasnici { get; set; }
        public DataBaseUposlenici dbUposlenici { get; set; }
        public ICommand Login { get; set; }

        public Vlasnik Admin {get;set;}

        public Uposlenik Radnik { get; set; }

        public Action CloseAction { get; set; }

        public void login(Object parametar)
        {
            var vlasnici = dbVlasnici.dajSve();
            var uposlenici = dbUposlenici.dajSve();
         
 
                //foreach (Vlasnik v in vlasnici)
                //{
                //    if (v.Username == Admin.Username && v.Password == Admin.Password)
                //    {
                //        Admin = new Vlasnik(v.Ime, v.Prezime, v.Jmbg, v.Adresa, v.BrojTelefona, v.Username, v.Password);
                //    }
                //}
                foreach (Uposlenik u in uposlenici)
                {
                    if (u.Username == Admin.Username && u.Password == Admin.Password)
                    {
                        Uposlenik Radnik = new Uposlenik(u.Ime, u.Prezime, u.Jmbg, u.Adresa, u.BrojTelefona, u.Username, u.Password);
                    }
                }
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
