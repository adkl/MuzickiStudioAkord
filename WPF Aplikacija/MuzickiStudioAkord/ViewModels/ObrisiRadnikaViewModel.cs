using MuzickiStudioAkord.DAL;
using System;
using MuzickiStudioAkord.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MuzickiStudioAkord.Properties;

namespace MuzickiStudioAkord.ViewModels
{
    public class ObrisiRadnikaViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public DataBaseUposlenici dbOsobe { get; set; }

        private ObservableCollection<Uposlenik> listaUposlenika;

        public ObservableCollection<Uposlenik> ListaUposlenika
        {
            get { return listaUposlenika; }
            set { listaUposlenika = value; OnPropertyChanged("ListaUposlenika"); }
        }
        private string obrisiJMBG;

        public string ObrisiJMBG
        {
            get { return obrisiJMBG; }
            set { obrisiJMBG = value; OnPropertyChanged("ObrisiJMBG"); }
        }
        
        private string pretragaIme;

        public string PretragaIme
        {
            get { return pretragaIme; }
            set { pretragaIme = value; OnPropertyChanged("PretragaIme"); }
        }
        string IDataErrorInfo.Error
        {
            get { return null; }
        }
        public ICommand PretragaCommand { get; set; }
        public ICommand ObrisiCommand { get; set; }

        public ObrisiRadnikaViewModel()
        {
            PretragaCommand = new RelayCommand(pretrazi);
            ObrisiCommand = new RelayCommand(obrisi);
            ObrisiJMBG = String.Empty;
            PretragaIme = String.Empty;
        }

        private void obrisi(object obj)
        {
            if(ObrisiJMBG != String.Empty)
            {
                dbOsobe = new DataBaseUposlenici(Resources.BazaPassword);
                if (dbOsobe.obrisi(ObrisiJMBG))
                {
                    System.Windows.MessageBox.Show("Uspjesno obrisan uposlenik", "Poruka", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                    ObrisiJMBG = String.Empty;
                }
            }
        }

        private void pretrazi(object obj)
        {
            if(PretragaIme != String.Empty)
            {
                ListaUposlenika = new ObservableCollection<Uposlenik>(new DataBaseUposlenici(Resources.BazaPassword).dajSve(PretragaIme));
            }
        }



        //Ponasa se tako da ako se vrati null nema errora ako se vrati neka vrijednost validacija nije uspjela
        string IDataErrorInfo.this[string propertyName]
        {
            get { return getValidationError(propertyName); }
        }

        private string getValidationError(string propertyName)
        {
            string error = null;
            switch(propertyName){
                case "PretragaIme":
                    if (PretragaIme == String.Empty) error =  "Unesite ime uposlenika";
                    break;
                case "ObrisiJMBG":
                    error = validirajJmbg();
                    break;
            }
            return error;
        }

        private string validirajJmbg()
        {
            string Jmbg = ObrisiJMBG;
            if (String.IsNullOrEmpty(Jmbg))
                return "Unesite JMBG";
            if (Jmbg.Length != 13)
                return "JMBG mora imati 13 cifara";
            return null;
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
