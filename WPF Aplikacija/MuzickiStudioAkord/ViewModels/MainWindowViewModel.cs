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
    public class MainWindowViewModel
    {
        public string LoginUserName { get; set; }
        public string LoginPassWord { get; set; }
        public DataBaseVlasnici dbVlasnici { get; set; }
        public ICommand Login { get; set; }

        public Vlasnik Admin {get;set;}

        public Uposlenik Radnik { get; set; }

        public Action CloseAction { get; set; }

        public void login(Object parametar)
        {
            if (Admin.IsValid)
            {
                foreach (var item in dbVlasnici.dajSve())
                {

                }
                CloseAction();
            }
        }

        public MainWindowViewModel()
        {
            Login = new RelayCommand(login);
            Admin = new Vlasnik();
            Radnik = new Uposlenik();
            dbVlasnici = new DataBaseVlasnici(Resources.BazaPassword);
           

        }


    }
}
