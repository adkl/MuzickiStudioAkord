using MuzickiStudioAkord.Models;
using MySql.Data.MySqlClient;
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
            List<Uposlenik> uposlenici = new List<Uposlenik>();
            connection.Open();
            try
            {
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from Uposlenici";
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    uposlenici.Add(new Uposlenik(r.GetString("Ime"), r.GetString("Prezime"), r.GetString("JMBG"), r.GetString("Broj_telefona"), r.GetString("Username"), r.GetString("Password")));
                }
               
            }
            catch(Exception)
            {
                connection.Close();
            }
            connection.Close();
            return uposlenici;
        }

        public Uposlenik dajPoID(int id)
        {
            Uposlenik uposlenik = null;
            connection.Open();
            try
            {
                
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from Uposlenici where JMBG = @id";
                upit.Parameters.AddWithValue("@id", id);
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    uposlenik = new Uposlenik(r.GetString("Ime"), r.GetString("Prezime"), r.GetString("JMBG"), r.GetString("Broj_telefona"), r.GetString("Username"), r.GetString("Password"));
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            if (uposlenik == null) uposlenik = new Uposlenik("Unknown", "Unknown", "Unknown", "Unknown", "Unknown", "Unknown");
            return uposlenik;
        }

        public bool dodaj(Uposlenik objekat)
        {
            connection.Open();
            try
            {
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "insert into Uposlenici values(@JMBG, @Ime, @Prezime, @Broj_telefona, @Username, @Password)";
                upit.Parameters.AddWithValue("@Ime", objekat.Ime);
                upit.Parameters.AddWithValue("@Prezime", objekat.Prezime);
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                upit.Parameters.AddWithValue("@Broj_telefona", objekat.BrojTelefona);
                upit.Parameters.AddWithValue("@Username", objekat.Username);
                upit.Parameters.AddWithValue("@Password", objekat.Password);
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

        public bool obrisi(Uposlenik objekat)
        {
            connection.Open();
            try
            {
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "delete from Uposlenici where Ime = @Ime and prezime = @Prezime and JMBG = @JMBG and Broj_telefona = @Broj_telefona and username = @Username and password = @Password";
                upit.Parameters.AddWithValue("@Ime", objekat.Ime);
                upit.Parameters.AddWithValue("@Prezime", objekat.Prezime);
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                upit.Parameters.AddWithValue("@Broj_telefona", objekat.BrojTelefona);
                upit.Parameters.AddWithValue("@Username", objekat.Username);
                upit.Parameters.AddWithValue("@Password", objekat.Password);
                if (upit.ExecuteNonQuery() == 1) {
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

        public bool daLiPostoji(Uposlenik objekat)
        {
            connection.Open();
            try
            {
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from Uposlenici where Ime = @Ime and Prezime = @Prezime and JMBG = @JMBG and Broj_telefona = @Broj_telefona and Username = @Username and Password = @Password";
                upit.Parameters.AddWithValue("@Ime", objekat.Ime);
                upit.Parameters.AddWithValue("@Prezime", objekat.Prezime);
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                upit.Parameters.AddWithValue("@Broj_telefona", objekat.BrojTelefona);
                upit.Parameters.AddWithValue("@Username", objekat.Username);
                upit.Parameters.AddWithValue("@Password", objekat.Password);
                MySqlDataReader r = upit.ExecuteReader();
                while(r.Read())
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
