using MuzickiStudioAkord.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class Inventory : INotifyPropertyChanged
    {
        private ObservableCollection<Artikal> artikli;
        public ObservableCollection<Artikal> Artikli
        {
            get { return artikli; }
            set { artikli = value; OnPropertyChanged("listaArtikala"); }
        }
        
        private DataBaseArtikli baza;
        public DataBaseArtikli Baza
        {
            get { return baza; }
            set { baza = value; }
        }
        public Inventory(string password, string server = "db4free.net", string username = "studioakord", string database = "muzickistudio")
        {
            this.Baza = new DataBaseArtikli(password, server, username, database);
            this.Artikli = baza.dajSve();
        }
        //ovaj je konstruktor ako imas bas neke posebne artikle koji ti samo trebaju xD
        public Inventory(ObservableCollection<Artikal> _artikli)
        {
            this.Artikli = _artikli;
        }
        public void osvjeziInventory()
        {
            Artikli.Clear();
            Artikli = baza.dajSve();
        }
        public bool dodajArtikal(Artikal artikal)
        {
            if (baza.dodaj(artikal))
            {
                Artikli.Add(artikal);
                return true;
            }
            return false;
        }
        public bool obrisiArtikal(Artikal artikal)
        {
            if (baza.obrisi(artikal))
            {
                Artikli.Remove(artikal);
                return true;
            }
            return false;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
