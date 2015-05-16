using MuzickiStudioAkord.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    class Inventory
    {
        private List<Artikal> artikli;
        public List<Artikal> Artikli
        {
            get { return artikli; }
            set { artikli = value; }
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
        public Inventory(List<Artikal> _artikli)
        {
            this.Artikli = _artikli;
        }
        public void osvjeziInventory()
        {
            Artikli.Clear();
            Artikli = baza.dajSve();
        }
        


    }
}
