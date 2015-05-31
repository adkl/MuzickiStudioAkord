using MuzickiStudioAkord.DAL;
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
    public class ObrisiArtikalViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public DataBaseArtikli dbaseArtikli { get; set; }
        public ICommand Brisanje { get; set; }
        private int serijskiBroj;

        public int SerijskiBroj
        {
            get { return serijskiBroj; }
            set { serijskiBroj = value; OnPropertyChanged("SerijskiBroj"); }
        }
        
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged("Status"); }
        }

        public ObrisiArtikalViewModel()
        {
            dbaseArtikli = new DataBaseArtikli(Resources.BazaPassword);
            Brisanje = new RelayCommand(obrisiArtikal);
            SerijskiBroj = 0;
        }

        public void obrisiArtikal(object obj)
        {
            if (SerijskiBroj != 0)
            {
                if (dbaseArtikli.obrisi(SerijskiBroj))
                {
                    Status = "Artikal uspjesno obrisan";
                    SerijskiBroj = 0;
                }
                else Status = "Artikal nije pronadjen!";
            }
        }

        string IDataErrorInfo.Error
        {
            get { return null; }
        }
        //Ponasa se tako da ako se vrati null nema errora ako se vrati neka vrijednost validacija nije uspjela
        string IDataErrorInfo.this[string propertyName]
        {
            get { return getValidationError(propertyName); }
        }

        private string getValidationError(string propertyName)
        {
            if (SerijskiBroj != 0) return null;
            return "Unesite serijski broj artikla";
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
