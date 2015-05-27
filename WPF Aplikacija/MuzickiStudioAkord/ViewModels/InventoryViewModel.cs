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
    public class InventoryViewModel
    {
        public Artikal noviArtikal { get; set; }
        public ICommand dodajUKorpu { get; set; }
        public ICommand dodajUBazu { get; set; }
        public Inventory ArtikliInventory { get; set; }
        string TipArtikla = String.Empty;


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
         //   if (noviArtikal.IsValid /*&& noviArtikal.Spec.IsValid*/)
          //  {
            ArtikliInventory.dodajArtikal(noviArtikal);
            
          //  }
        }
        private void dodajKorpa(object obj)
        {

        }
    }
}
