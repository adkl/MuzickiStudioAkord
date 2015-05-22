using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class Narudzba: INotifyPropertyChanged
    {
        private  int brojNarudzbe = 0;
        public  int BrojNarudzbe
        {
            get { return brojNarudzbe; }
            set { brojNarudzbe = value; OnPropertyChanged("BrojNarudzbe"); }
        }
        private DateTime vrijemeNarudzbe;
        public DateTime VrijemeNarudzbe
        {
            get { return vrijemeNarudzbe; }
            set { vrijemeNarudzbe = value; OnPropertyChanged("VrijemeNarudzbe"); }
        }
        //Ne moze obicni list za datgrid mora bit ObservableColection inace se ne bi update polja kad bi doali novu stavku
        private ObservableCollection<Artikal> listaArtikala;
        public ObservableCollection<Artikal> ListaArtikala
        {
            get { return listaArtikala; }
            set { value = listaArtikala; OnPropertyChanged("ListaArtikala"); }
        }
        private NacinPlacanja tipPlacanja;
        public NacinPlacanja TipPlacanja
        {
            get { return tipPlacanja; }
            set { tipPlacanja = value; OnPropertyChanged("TipPlacanja"); }
        }
        private Klijent kupac;
        public Klijent Kupac
        {
            get { return kupac; }
            set { kupac = value; OnPropertyChanged("Kupac"); }
        }
        public Narudzba(int _brojNarudzbe, DateTime _vrijemeNarudzbe, NacinPlacanja _tipPlacanja, Klijent _klijent)
        {
            this.BrojNarudzbe = _brojNarudzbe;
            this.VrijemeNarudzbe = _vrijemeNarudzbe;
            this.TipPlacanja = _tipPlacanja;
            this.Kupac = _klijent;
            ObservableCollection<Artikal> _listaArtikala = new ObservableCollection<Artikal>();
            this.listaArtikala = _listaArtikala;
        }
        public void dodajUKorpu(Artikal a)
        {
            ListaArtikala.Add(a);
        }
        public enum NacinPlacanja
        {
            KreditnaKartica,
            Gotovina
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
