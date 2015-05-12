using MuzickiStudioAkord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.DAL
{
    public class DataBaseArtikli : DataBase, IDataBase<Artikal>
    {
        public DataBaseArtikli(string password, string server = "db4free.net", string username = "studioakord", string database = "muzickistudio")
            : base(password, server, username, database)
        {

        }
        public List<Artikal> dajSve()
        {
            throw new NotImplementedException();
        }

        public Artikal dajPoID(int id)
        {
            throw new NotImplementedException();
        }

        public bool dodaj(Artikal objekat)
        {
            throw new NotImplementedException();
        }

        public bool obrisi(Artikal objekat)
        {
            throw new NotImplementedException();
        }

        public bool daLiPostoji(Artikal objekat)
        {
            throw new NotImplementedException();
        }
    }
}
