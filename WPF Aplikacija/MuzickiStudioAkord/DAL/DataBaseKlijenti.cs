using MuzickiStudioAkord.Models;
using MySql.Data.MySqlClient;
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
            List<Klijent> klijenti = new List<Klijent>();
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from osobe o, klijenti k, kreditna_kartica kk where k.JMBG = o.JMBG and k.JMBG = kk.JMBG";
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    klijenti.Add(new Klijent(r.GetString("Ime"), r.GetString("Prezime"), r.GetString("JMBG"), r.GetString("Adresa"), r.GetString("Broj_telefona"), r.GetInt32("potrosacka_kartica"), new KreditnaKartica(r.GetInt32("id_kartice"), r.GetInt32("ccv"), r.GetDateTime("datum_isteka"))));
                }
            }
            catch(Exception)
            {
                connection.Close();
            }
            connection.Close();
            return klijenti;
        }

        public Klijent dajPoID(int id)
        {
            Klijent klijent = null;
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from osobe o, klijenti k, kreditna_kartica kk where k.JMBG = o.JMBG and k.JMBG = kk.JMBG and o.JMBG = @JMBG";
                upit.Parameters.AddWithValue("@JMBG", id.ToString());
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    klijent = new Klijent(r.GetString("Ime"), r.GetString("Prezime"), r.GetString("JMBG"), r.GetString("Adresa"), r.GetString("Broj_telefona"), r.GetInt32("potrosacka_kartica"), new KreditnaKartica(r.GetInt32("id_kartice"), r.GetInt32("ccv"), r.GetDateTime("datum_isteka")));
                }
            }
            catch (Exception)
            {
                connection.Close();
            }
            connection.Close();
            return klijent;
        }

        public bool dodaj(Klijent objekat)
        {
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "insert into osobe values(@JMBG, @Ime, @Prezime, @Adresa,@Broj_telefona, @Username, @Password, @Status)";
                upit.Parameters.AddWithValue("@Ime", objekat.Ime);
                upit.Parameters.AddWithValue("@Prezime", objekat.Prezime);
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                upit.Parameters.AddWithValue("@Broj_telefona", objekat.BrojTelefona);
                upit.Parameters.AddWithValue("@Username", "Nema");
                upit.Parameters.AddWithValue("@Password", "Nema");
                upit.Parameters.AddWithValue("@Adresa", objekat.Adresa);
                upit.Parameters.AddWithValue("@Status", 3);
                upit.ExecuteNonQuery();

                upit.CommandText = "insert into klijenti values(@potrosacka_kartica, @JMBG)";
                upit.Parameters.AddWithValue("@potrosacka_kartica", objekat.PotrosackaKarticaID);
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                upit.ExecuteNonQuery();

                upit.CommandText = "insert into kreditna_kartica values(@id_kartice, @ccv, @datum_isteka, @JMBG)";
                upit.Parameters.AddWithValue("@id_kartice", objekat.Kartica.id_kartice);
                upit.Parameters.AddWithValue("@ccv", objekat.Kartica.ccv);
                upit.Parameters.AddWithValue("@datum_isteka", objekat.Kartica.datum_isteka);
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
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

        public bool obrisi(Klijent objekat)
        {
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "delete from kreditna_kartica where JMBG = @JMBG";
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                if (upit.ExecuteNonQuery() == 1)
                {
                    upit.CommandText = "delete from klijenti where JMBG = @JMBG";
                    if (upit.ExecuteNonQuery() == 1)
                    {
                        upit.CommandText = "delete from osobe where JMBG = @JMBG";
                        if (upit.ExecuteNonQuery() == 1) return true;
                    }
                }
                connection.Close();
                return false;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        public bool daLiPostoji(Klijent objekat)
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
