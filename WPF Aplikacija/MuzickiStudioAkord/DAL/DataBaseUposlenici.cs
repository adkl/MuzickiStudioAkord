using MuzickiStudioAkord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.DAL
{
    public class DataBaseUposlenici : DataBase, IDataBase<Uposlenik>
    {
        public DataBaseUposlenici(string password, string server = "db4free.net", string username = "studioakord", string database = "muzickistudio")
            : base(password, server, username, database)
        {

        }

        public List<Uposlenik> dajSve()
        {
            throw new NotImplementedException();
        }

        public Uposlenik dajPoID(int id)
        {
            throw new NotImplementedException();
        }

        public bool dodaj(Uposlenik objekat)
        {
            throw new NotImplementedException();
        }

        public bool obrisi(Uposlenik objekat)
        {
            throw new NotImplementedException();
        }

        public bool daLiPostoji(Uposlenik objekat)
        {
            throw new NotImplementedException();
        }
    }
}
