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
        public Inventory ArtikliInventory { get; set; }
        public InventoryViewModel()
        {
            ArtikliInventory = new Inventory(Resources.BazaPassword);
            dodajUKorpu = new RelayCommand(dodajKorpa);
        }
        public InventoryViewModel(string tipArtikla)
        {
            if (tipArtikla == "Elektricna gitara") noviArtikal = new ElektricnaGitara();
            else if (tipArtikla == "Klasicna gitara") noviArtikal = new KlasicnaGitara();
            else if (tipArtikla == "Klavijature") noviArtikal = new Klavijatura();
            else if (tipArtikla == "Pojacalo") noviArtikal = new Pojacalo();
        }
        private void dodajKorpa(object obj)
        {

        }
    }
}
