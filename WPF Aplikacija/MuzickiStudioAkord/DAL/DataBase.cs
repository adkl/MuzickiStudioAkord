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
        public MySqlConnection connection;
        public DataBase(string password, string server = "db4free.net", string username = "studioakord", string database = "muzickistudio")
        {
            this.server = server;
            this.username = username;
            this.password = password;
            this.db = database;
            connectionString = "server=localhost;user=root;pwd=;database=muzickistudio";
            //connectionString = "server=mysql3.com.ba;user=studio;pwd=Studio1;database=seta_am_studioakord";
            //connectionString = "server=" + this.server + ";user=" + this.username + ";pwd=" + this.password + ";database=" + database;
            validirajKorisnika();
            connection = new MySqlConnection(connectionString);
        }

        private void validirajKorisnika()
        {
            try
            {
                MySqlConnection test = new MySqlConnection(connectionString);
                test.Open();
                test.Close();
            }
            catch(MySqlException e)
            {
                System.Windows.MessageBox.Show("Konekcija na bazu nije moguca!\nPoruka : " + e.Message, "Greska pri konekciji", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Error);
            }
        }
    }
}
