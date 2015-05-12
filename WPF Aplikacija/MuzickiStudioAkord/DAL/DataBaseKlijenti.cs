using MuzickiStudioAkord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.DAL
{
    public class DataBaseKlijenti : DataBase, IDataBase<Klijent>
    {
        public DataBaseKlijenti(string password, string server = "db4free.net", string username = "studioakord", string database = "muzickistudio")
            : base(password, server, username, database)
        {

        }

        public List<Klijent> dajSve()
        {
            throw new NotImplementedException();
        }

        public Klijent dajPoID(int id)
        {
            throw new NotImplementedException();
        }

        public bool dodaj(Klijent objekat)
        {
            throw new NotImplementedException();
        }

        public bool obrisi(Klijent objekat)
        {
            throw new NotImplementedException();
        }

        public bool daLiPostoji(Klijent objekat)
        {
            throw new NotImplementedException();
        }
    }
}
