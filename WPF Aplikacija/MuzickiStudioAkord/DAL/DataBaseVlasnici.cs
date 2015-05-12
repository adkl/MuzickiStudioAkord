using MuzickiStudioAkord.Models;
using MySql.Data.MySqlClient;
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
            List<Vlasnik> vlasnici = new List<Vlasnik>();
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from osobe where status = @Status";
                upit.Parameters.AddWithValue("@Status", 2);
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    vlasnici.Add(new Vlasnik(r.GetString("Ime"), r.GetString("Prezime"), r.GetString("JMBG"), r.GetString("Adresa"), r.GetString("Broj_telefona"), r.GetString("Username"), r.GetString("Password")));
                }

            }
            catch (Exception)
            {
                connection.Close();
            }
            connection.Close();
            return vlasnici;
        }

        public Vlasnik dajPoID(int id)
        {
            Vlasnik vlasnik = null;

            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from osobe where JMBG = @id";
                upit.Parameters.AddWithValue("@id", id.ToString());
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    vlasnik = new Vlasnik(r.GetString("Ime"), r.GetString("Prezime"), r.GetString("JMBG"), r.GetString("Adresa"), r.GetString("Broj_telefona"), r.GetString("Username"), r.GetString("Password"));
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            if (vlasnik == null) vlasnik = new Vlasnik("Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown");
            return vlasnik;
        }

        public bool dodaj(Vlasnik objekat)
        {
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "insert into osobe values(@JMBG, @Ime, @Prezime, @Adresa, @Broj_telefona, @Username, @Password, @Vlasnik)";
                upit.Parameters.AddWithValue("@Ime", objekat.Ime);
                upit.Parameters.AddWithValue("@Prezime", objekat.Prezime);
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                upit.Parameters.AddWithValue("@Broj_telefona", objekat.BrojTelefona);
                upit.Parameters.AddWithValue("@Username", objekat.Username);
                upit.Parameters.AddWithValue("@Password", objekat.Password);
                upit.Parameters.AddWithValue("@Adresa", objekat.Adresa);
                upit.Parameters.AddWithValue("@Vlasnik", 2);
                upit.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool obrisi(Vlasnik objekat)
        {
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "delete from osobe where JMBG = @JMBG";
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                if (upit.ExecuteNonQuery() == 1)
                {
                    return true;
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

        public bool daLiPostoji(Vlasnik objekat)
        {
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from osobe where JMBG = @JMBG";
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    if (r.GetString("JMBG") == objekat.Jmbg)
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
