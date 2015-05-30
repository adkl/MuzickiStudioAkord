using MuzickiStudioAkord.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            catch (Exception)
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

        public bool dodaj(Object o)
        {
            try
            {
                Klijent objekat = o as Klijent;
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "insert into osobe values(@JMBG, @Ime, @Prezime, @Adresa,@Broj_telefona, @Username, @Password, @Status)";
                upit.Parameters.AddWithValue("@Ime", objekat.Ime);
                upit.Parameters.AddWithValue("@Prezime", objekat.Prezime);
                upit.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                upit.Parameters.AddWithValue("@Broj_telefona", objekat.BrojTelefona);
                upit.Parameters.AddWithValue("@Username", objekat.Ime);
                upit.Parameters.AddWithValue("@Password", objekat.Prezime);
                upit.Parameters.AddWithValue("@Adresa", objekat.Adresa);
                upit.Parameters.AddWithValue("@Status", 3);
                upit.ExecuteNonQuery();

                MySqlCommand upit2 = new MySqlCommand();
                upit2.Connection = connection;

                upit2.CommandText = "insert into klijenti values(@potrosacka_kartica, @JMBG)";
                upit2.Parameters.AddWithValue("@potrosacka_kartica", objekat.PotrosackaKarticaID);
                upit2.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                upit2.ExecuteNonQuery();

                MySqlCommand upit3 = new MySqlCommand();
                upit3.Connection = connection;

                upit3.CommandText = "insert into kreditna_kartica values(@id_kartice, @ccv, @datum_isteka, @JMBG)";
                upit3.Parameters.AddWithValue("@id_kartice", objekat.Kartica.Id_kartice);
                upit3.Parameters.AddWithValue("@ccv", objekat.Kartica.Ccv);
                upit3.Parameters.AddWithValue("@datum_isteka", objekat.Kartica.Datum_isteka);
                upit3.Parameters.AddWithValue("@JMBG", objekat.Jmbg);
                upit3.ExecuteNonQuery();

                connection.Close();
                return true;

            }
            catch (Exception)
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
