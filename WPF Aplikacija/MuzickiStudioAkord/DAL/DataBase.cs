using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.DAL
{
    public abstract class DataBase
    {
        private string server;
        private string username;
        private string password;
        private string db;
        public readonly string connectionString;

        public DataBase(string password, string server = "db4free.net", string username = "studioakord", string database = "muzickistudio")
        {
            this.server = server;
            this.username = username;
            this.password = password;
            this.db = database;
            connectionString = "server=" + server + ";user=" + username + ";pwd=" + password + ";database=" + database;

            validirajKorisnika();
        }

        private void validirajKorisnika()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                con.Close();
            }
            catch(MySqlException e)
            {
                throw new Exception("Konekcija na bazu nije moguca!");
            }
        }
    }
}
