using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class Sastanak
    {
        private int id_sastanak; 
        public int Id_sastanak 
        {
            get { return id_sastanak; }
            set { id_sastanak = value; }
        }
        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
        private DateTime datum;
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        private string opis;
        public string Opis
        {
            get { return opis; }
            set { opis = value; }
        }
        private Klijent klijent;
        public Klijent Klijent
        {
            get { return klijent; }
            set { klijent = value; }
        }
        public Sastanak(int id, string naziv, DateTime datum, string opis, Klijent klijent)
        {
            this.Id_sastanak = id;
            this.Naziv = naziv;
            this.Datum = datum;
            this.Opis = opis;
            this.Klijent = klijent;
        }
    }
}
