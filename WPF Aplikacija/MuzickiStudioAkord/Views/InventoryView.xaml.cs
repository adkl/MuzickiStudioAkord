using MuzickiStudioAkord.Models;
using MuzickiStudioAkord.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for KatalogView.xaml
    /// </summary>
    public partial class InventoryView : Page, INotifyPropertyChanged
    {
        InventoryViewModel artikli = new InventoryViewModel();
        

        private List<ArtikalControl> listaKorpa;

        public List<ArtikalControl> ListaKorpa
        {
            get { return listaKorpa; }
            set { listaKorpa = value; OnPropertyChanged("ListaKorpa"); }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public InventoryView()
        {
            InitializeComponent();
            DataContext = artikli;
            ListaKorpa = new List<ArtikalControl>();
            foreach(Artikal item in artikli.ArtikliInventory.Artikli)
            {
                listaKorpa.Add(new ArtikalControl(item.Naziv, item.Slika, item.Cijena.ToString(), item.dajSpecifikaciju()));
                stackpanelArtikli.Children.Add(listaKorpa[listaKorpa.Count-1]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KorpaView kv = new KorpaView(ListaKorpa);
            kv.Show();
        }
    }
}
