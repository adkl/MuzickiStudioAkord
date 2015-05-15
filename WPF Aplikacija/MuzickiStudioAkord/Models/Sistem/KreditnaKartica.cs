using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuzickiStudioAkord.Models.Sistem.Pomocna;

namespace MuzickiStudioAkord.Models
{
    public class KreditnaKartica: INotifyPropertyChanged, IDataErrorInfo
    {
        private int Id_kartice; //mada bi trebalo string, ali vec je povezano sa bazom kao int tako da ne znam
        public int id_kartice   //obrnuto je veliko slovo jer je s bazom povezano na malo, pa da se ne bi mijenjalo
        {
            get { return Id_kartice; }
            set { Id_kartice = value; OnPropertyChanged("id_kartice"); }
        }
        //public int id_kartice { get; set; }
        private DateTime DatumIsteka;
        public DateTime datum_isteka
        {
            get { return DatumIsteka; }
            set { DatumIsteka = value; OnPropertyChanged("datum_isteka"); }
        }
        private int Ccv;
        public int ccv
        {
            get { return Ccv; }
            set { Ccv = value; OnPropertyChanged("ccv"); }
        }
        //public int ccv { get; set; }
        //public DateTime datum_isteka { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //IsValid testira sve moguce validacije
        public bool IsValid
        {
            get
            {
                foreach (string property in validateProperties)
                {
                    if (getValidationError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        //lista validacija kroz koje IsValid treba proci
        static readonly string[] validateProperties = { "id_kartice", "datum_isteka", "ccv" };
        //Mora se implemntirati
        string IDataErrorInfo.Error
        {
            get { return null; }
        }
        //Ponasa se tako da ako se vrati null nema errora ako se vrati neka vrijednost validacija nije uspjela
        string IDataErrorInfo.this[string propertyName]
        {
            get { return getValidationError(propertyName); }
        }
        //Ovisno o tome koji property se mijenja
        string getValidationError(string propertyName){
            string error = null;
            switch (propertyName)
            {
                case "id_kartice":
                    error = validirajBroj();
                break;
                case "datum_isteka":
                    error = validirajDatum();
                break;
                case "ccv":
                    error = validrajCcv();
                break;
            }
            return error;
        }
        private string validirajBroj()
        {
            string BrojKreditneKartice = id_kartice.ToString();
            //Prvo gleda jel vrijednost uopste popunjena
            if (String.IsNullOrWhiteSpace(BrojKreditneKartice))
            {
                return "Id kreditne kartice mora bit unesen!";
            }
            //510510510510510 mastercard testna kartica ispravna
            //Provjerava custom da li je ispravan broj kartice koristeci luhn algoritam
            if (!BrojKreditneKartice.LuhnCheck() || BrojKreditneKartice.Length>19 || BrojKreditneKartice.Length<1)
            {
                return "Broj kreditne kartice ne postoji!";
            }
            return null;
        }
        //Validacija jel input ok
        private string validrajCcv()
        {
            //test za integer
            if (Ccv < 1000 || Ccv > 9999) return "CCV mora bit cetverocifren broj!";
            return null;
        }
        private string validirajDatum()
        {
            //Test za datum
            if (DatumIsteka <= DateTime.Now)
            {
                return "Unesite datum u budcnosti!";
            }
            return null;
        }


        public KreditnaKartica(int id_karticee, int _ccv, DateTime datum_istekaa)
        {
            this.id_kartice = id_karticee;
            this.ccv = _ccv;
            this.datum_isteka = datum_istekaa;
        }
        public KreditnaKartica ()
        {

        }


    }
}
