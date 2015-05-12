using MuzickiStudioAkord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.DAL
{
    public class DataBaseVlasnici : DataBase, IDataBase<Vlasnik>
    {
        public DataBaseVlasnici(string password, string server = "db4free.net", string username = "studioakord", string database = "muzickistudio")
            : base(password, server, username, database)
        {

        }

        public List<Vlasnik> dajSve()
        {
            throw new NotImplementedException();
        }

        public Vlasnik dajPoID(int id)
        {
            throw new NotImplementedException();
        }

        public bool dodaj(Vlasnik objekat)
        {
            throw new NotImplementedException();
        }

        public bool obrisi(Vlasnik objekat)
        {
            throw new NotImplementedException();
        }

        public bool daLiPostoji(Vlasnik objekat)
        {
            throw new NotImplementedException();
        }
    }
}
