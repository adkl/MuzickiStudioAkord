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
    public class InventoryViewModel : INotifyPropertyChanged
    {
        private Inventory artikliInventory;

        public Inventory ArtikliInventory
        {
            get { return artikliInventory; }
            set { artikliInventory = value;}
        }

        public Artikal noviArtikal { get; set; }
        public ICommand dodajUKorpu { get; set; }
        public ICommand dodajUBazu { get; set; }
        string TipArtikla = string.Empty;


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public InventoryViewModel()
        {
            ArtikliInventory = new Inventory(Resources.BazaPassword);
            dodajUKorpu = new RelayCommand(dodajKorpa);
           
        }
        public InventoryViewModel(string tipArtikla)
        {
            this.TipArtikla = tipArtikla;
            if (tipArtikla == "Elektricna gitara") noviArtikal = new ElektricnaGitara();
            else if (tipArtikla == "Klasicna gitara") noviArtikal = new KlasicnaGitara();
            else if (tipArtikla == "Klavijature") noviArtikal = new Klavijatura();
            else if (tipArtikla == "Pojacalo") noviArtikal = new Pojacalo();
            ArtikliInventory = new Inventory(Resources.BazaPassword);
            dodajUBazu = new RelayCommand(dodajNoviArtikal);
        }
        public void dodajNoviArtikal(object obj)
        {
            if (noviArtikal.IsValid)
            {
                ArtikliInventory.dodajArtikal(noviArtikal);
            }
        }
        private void dodajKorpa(object obj)
        {

        }
    }
}
