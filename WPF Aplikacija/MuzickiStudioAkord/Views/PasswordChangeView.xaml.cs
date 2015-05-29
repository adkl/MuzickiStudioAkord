using MuzickiStudioAkord.DAL;
using MuzickiStudioAkord.Models;
using MuzickiStudioAkord.ViewModels;
using MuzickiStudioAkord.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MuzickiStudioAkord.Views
{
    /// <summary>
    /// Interaction logic for PasswordChangeView.xaml
    /// </summary>
    public partial class PasswordChangeView : Page
    {
        public Osoba logiraniKorisnik { get; set; }
        public DataBaseVlasnici dbVlasnici { get; set; }
        public DataBaseUposlenici dbUposlenici { get; set; }
        public PasswordChangeView()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            dbVlasnici = new DataBaseVlasnici(MuzickiStudioAkord.Properties.Resources.BazaPassword);
            dbUposlenici = new DataBaseUposlenici(MuzickiStudioAkord.Properties.Resources.BazaPassword);
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            string username = textBoxUsername.Text;
            string oldPw = passwordBoxOldPassword.Password;
            string newPw = passwordBoxNewPassword.Password;

            foreach (Vlasnik v in dbVlasnici.dajSve())
            {
                if (v.Username == username)
                {
                    //ovdje treba promijeniti pw u bazi
                    Vlasnik vl = new Vlasnik(v.Ime, v.Prezime, v.Jmbg, v.Adresa, v.BrojTelefona, v.Username, newPw);
                    dbVlasnici.obrisi(v);
                    dbVlasnici.dodaj(vl);
                    System.Windows.Forms.MessageBox.Show("Password uspjesno promijenjen");
                    textBoxUsername.Text = String.Empty;
                    passwordBoxNewPassword.Password = String.Empty;
                    passwordBoxOldPassword.Password = String.Empty;
                    return;
                }
            }

            foreach (Uposlenik u in dbUposlenici.dajSve())
            {
                if (u.Username == username)
                {
                    Uposlenik u1 = new Uposlenik(u.Ime, u.Prezime, u.Jmbg, u.Adresa, u.BrojTelefona, u.Username, newPw);
                    dbUposlenici.obrisi(u);
                    dbUposlenici.dodaj(u1);
                    System.Windows.Forms.MessageBox.Show("Password uspjesno promijenjen");
                    textBoxUsername.Text = String.Empty;
                    passwordBoxNewPassword.Password = String.Empty;
                    passwordBoxOldPassword.Password = String.Empty;
                    return;
                }
            }
        }
        //ovdje malo narusavamo MVVM ali nemam izbora, jer nisam uspio implementirati multi-binding na button confirm
       

        
    }
}
