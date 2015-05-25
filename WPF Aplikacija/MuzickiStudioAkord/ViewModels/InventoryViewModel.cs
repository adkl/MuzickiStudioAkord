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
        public ICommand dodajUKorpu { get; set; }
        public Inventory ListaArtikala { get; set; }
        public InventoryViewModel()
        {
            ListaArtikala = new Inventory(Resources.BazaPassword);
            dodajUKorpu = new RelayCommand(dodajKorpa);
        }

        private void dodajKorpa(object obj)
        {

        }
    }
}
