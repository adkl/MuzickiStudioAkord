using MuzickiStudioAkord.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.DAL
{
    public class DataBaseSastanci : DataBase, IDataBase<Sastanak>
    {
        private DataBaseKlijenti dataKlijent;
        public DataBaseSastanci(string password, string server = "db4free.net", string username = "studioakord", string database = "muzickistudio")
            : base(password, server, username, database)
        {
            dataKlijent = new DataBaseKlijenti(password); 
        }

        public ObservableCollection<Sastanak> dajSve()
        {
            ObservableCollection<Sastanak> sastanci = new ObservableCollection<Sastanak>();
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from sastanci";
                 MySqlDataReader r = upit.ExecuteReader();
                 while (r.Read())
                 {       
                     Klijent tempKlijent = dataKlijent.dajPoID((Int32.Parse(r.GetString("JMBG"))));
                     sastanci.Add(new Sastanak(r.GetInt32("id_sastanak"), r.GetString("naziv"), r.GetDateTime("datum"), r.GetString("opis"),tempKlijent));
                 }
            }
            catch(Exception)
            {
                connection.Close();
            }
            connection.Close();
            return sastanci;

        }

        public Sastanak dajPoID(int id)
        {
            Sastanak sastanak = null;
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from sastanci where id_sastanak = @id";
                upit.Parameters.AddWithValue("@id", id.ToString());
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    Klijent tempKlijent = dataKlijent.dajPoID((Int32.Parse(r.GetString("JMBG"))));
                    sastanak = new Sastanak(id, r.GetString("naziv"), r.GetDateTime("datum"), r.GetString("opis"), tempKlijent);
                }
                return sastanak;
            }
            catch(Exception)
            {
                connection.Close();
                return sastanak;
            }
        }

        public bool dodaj(Object o)
        {
            try
            {
                Sastanak objekat = o as Sastanak;
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                dataKlijent.dodaj(objekat.Klijent);
                upit.CommandText = "insert into sastanci(naziv, datum, opis, jmbg_klijent) values(@naziv, @datum, @opis, @jmbg_klijent)";
                upit.Parameters.AddWithValue("@naziv", objekat.Naziv);
                upit.Parameters.AddWithValue("@datum", objekat.Datum);
                upit.Parameters.AddWithValue("@opis", objekat.Opis);
                upit.Parameters.AddWithValue("@jmbg_klijent", objekat.Klijent.Jmbg);
                upit.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch(Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool obrisi(Sastanak objekat)
        {
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "delete from sastanci where id_sastanak = @id";
                upit.Parameters.AddWithValue("@id", objekat.Id_sastanak);
                if (upit.ExecuteNonQuery() == 1)
                {
                    return true;
                }
                connection.Close();
                return false;
            }
            catch(Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool daLiPostoji(Sastanak objekat)
        {
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from sastanci where id_sastanak = @id";
                upit.Parameters.AddWithValue("@id", objekat.Id_sastanak);
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    if (r.GetInt32("id_sastanak") == objekat.Id_sastanak)
                    {
                        connection.Close();
                        return true;
                    }
                }
                connection.Close();
                return false;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }
    }
}
