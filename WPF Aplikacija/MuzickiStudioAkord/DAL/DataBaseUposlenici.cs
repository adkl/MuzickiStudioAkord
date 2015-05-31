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
    public class DataBaseUposlenici : DataBase, IDataBase<Uposlenik>
    {
        public DataBaseUposlenici(string password, string server = "db4free.net", string username = "studioakord", string database = "muzickistudio")
            : base(password, server, username, database)
        {

        }
        public ObservableCollection<Uposlenik> dajSve()
        {
            ObservableCollection<Uposlenik> uposlenici = new ObservableCollection<Uposlenik>();  
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from osobe where status = @Status";
                upit.Parameters.AddWithValue("@Status", 1);
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    uposlenici.Add(new Uposlenik(r.GetString("Ime"), r.GetString("Prezime"), r.GetString("JMBG"), r.GetString("Adresa"),r.GetString("Broj_telefona"), r.GetString("Username"), r.GetString("Password")));
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
                    uposlenik = new Uposlenik(r.GetString("Ime"), r.GetString("Prezime"), r.GetString("JMBG"), r.GetString("Adresa"),r.GetString("Broj_telefona"), r.GetString("Username"), r.GetString("Password"));
                }
                connection.Close();
                return uposlenik;
            }
            catch (Exception)
            {
                connection.Close();
                return null;
            }
        }

        public bool dodaj(Object o)
        {
           
            try
            {
                Uposlenik objekat = o as Uposlenik;
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "insert into osobe values(@JMBG, @Ime, @Prezime, @Adresa, @Broj_telefona, @Username, @Password, @Uposlenik)";
                upit.Parameters.AddWithValue("@Ime", objekat.Ime);
                upit.Parameters.AddWithValue("@Prezime", objekat.Prezime);
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                upit.Parameters.AddWithValue("@Broj_telefona", objekat.BrojTelefona);
                upit.Parameters.AddWithValue("@Username", objekat.Username);
                upit.Parameters.AddWithValue("@Password", objekat.Password);
                upit.Parameters.AddWithValue("@Adresa", objekat.Adresa);
                upit.Parameters.AddWithValue("@Uposlenik", 1);
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
          
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "delete from osobe where JMBG = @JMBG";
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                if (upit.ExecuteNonQuery() == 1) {
                    connection.Close();
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
            
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from osobe where JMBG = @JMBG";
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
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
