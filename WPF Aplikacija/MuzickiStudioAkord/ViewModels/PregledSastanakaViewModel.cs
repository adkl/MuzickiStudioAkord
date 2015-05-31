using MuzickiStudioAkord.DAL;
using MuzickiStudioAkord.Models;
using MuzickiStudioAkord.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.ViewModels
{
    public class PregledSastanakaViewModel : INotifyPropertyChanged
    {
        public DataBaseSastanci dbSastanci { get; set; }
        private ObservableCollection<Sastanak> listaSastanaka;

        public ObservableCollection<Sastanak> ListaSastanaka
        {
            get { return listaSastanaka; }
            set { listaSastanaka = value; OnPropertyChanged("ListaSastanaka"); }
        }
        public PregledSastanakaViewModel()
        {
            ListaSastanaka = new ObservableCollection<Sastanak>(new DataBaseSastanci(Resources.BazaPassword).dajSve());
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
