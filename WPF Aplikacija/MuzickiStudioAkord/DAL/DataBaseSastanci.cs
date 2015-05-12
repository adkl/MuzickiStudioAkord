using MuzickiStudioAkord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.DAL
{
    public class DataBaseSastanci : DataBase, IDataBase<Sastanak>
    {
        public DataBaseSastanci(string password, string server = "db4free.net", string username = "studioakord", string database = "muzickistudio")
            : base(password, server, username, database)
        {

        }

        public List<Sastanak> dajSve()
        {
            throw new NotImplementedException();
        }

        public Sastanak dajPoID(int id)
        {
            throw new NotImplementedException();
        }

        public bool dodaj(Sastanak objekat)
        {
            throw new NotImplementedException();
        }

        public bool obrisi(Sastanak objekat)
        {
            throw new NotImplementedException();
        }

        public bool daLiPostoji(Sastanak objekat)
        {
            throw new NotImplementedException();
        }
    }
}
