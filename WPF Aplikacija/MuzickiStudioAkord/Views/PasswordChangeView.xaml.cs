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
        }
        //ovdje malo narusavamo MVVM ali nemam izbora, jer nisam uspio implementirati multi-binding na button confirm
       

        
    }
}
