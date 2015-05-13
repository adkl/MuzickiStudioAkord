using MuzickiStudioAkord.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MuzickiStudioAkord.DAL
{
    public class DataBaseArtikli : DataBase, IDataBase<Artikal>
    {
        public DataBaseArtikli(string password, string server = "db4free.net", string username = "studioakord", string database = "muzickistudio")
            : base(password, server, username, database)
        {

        }
        public List<Artikal> dajSve()
        {
            List<Artikal> artikli = new List<Artikal>();
            MySqlConnection connection2 = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from artikli";
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    connection2.Open();
                    MySqlCommand upit2 = new MySqlCommand();
                    upit2.Connection = connection2;
                    if (r.GetString("tip_artikla") == "ElektricnaGitara")
                    {
                        upit2.CommandText = "select * from specifikacije sp, spec_gitara sg where sp.id_spec = sg.id_spec and sp.id_spec =" + r.GetString("id_specifikacije");
                        MySqlDataReader r2 = upit2.ExecuteReader();
                        while (r2.Read())
                        {
                            Byte[] slikaTEMP = new Byte[65536];
                            r.GetBytes(4, 0, slikaTEMP, 0, 65536);
                            BitmapImage slika = byteArrayToImage(slikaTEMP);
                            SpecElektricna spec = new SpecElektricna(r2.GetInt32("godina_proizvodnje"), r2.GetString("proizvodjac"), r2.GetString("model"), r2.GetString("materijal"), r2.GetInt32("broj_zica"), r2.GetString("masinica"), r2.GetString("vrat"), r2.GetString("most"), r2.GetString("pickup"), r2.GetString("elektronika"));
                            string tempTip = r.GetString("tip_gitare");
                            TipElektronika tip;
                            if (tempTip == "Elektricna") tip = TipElektronika.Elektricna;
                            else tip = TipElektronika.Bass;
                            artikli.Add(new ElektricnaGitara(r.GetInt32("serijski_broj"), r.GetString("naziv"), r.GetDouble("cijena"), spec, slika, tip));
                        }
                    }
                    else if (r.GetString("tip_artikla") == "KlasicnaGitara")
                    {
                        upit2.CommandText = "select * from specifikacije sp, spec_gitara sg where sp.id_spec = sg.id_spec and sp.id_spec =" + r.GetString("id_specifikacije");
                        MySqlDataReader r2 = upit2.ExecuteReader();
                        while (r2.Read())
                        {
                            Byte[] slikaTEMP = new Byte[65536];
                            r.GetBytes(4, 0, slikaTEMP, 0, 65536);
                            BitmapImage slika = byteArrayToImage(slikaTEMP);
                            SpecKlasicna spec = new SpecKlasicna(r2.GetInt32("godina_proizvodnje"), r2.GetString("proizvodjac"), r2.GetString("model"), r2.GetString("materijal"), r2.GetInt32("broj_zica"), r2.GetString("masinica"));
                            string tempTip = r.GetString("tip_gitare");
                            TipKlasicne tip;
                            if (tempTip == "Akusticna") tip = TipKlasicne.Akusticna;
                            else tip = TipKlasicne.Klasicna;
                            artikli.Add(new KlasicnaGitara(r.GetInt32("serijski_broj"), r.GetString("naziv"), r.GetDouble("cijena"), spec, slika, tip));
                        }
                    }
                    else if (r.GetString("tip_artikla") == "Klavijatura")
                    {
                        upit2.CommandText = "select * from specifikacije sp, spec_klavijature sg where sp.id_spec = sg.id_spec and sp.id_spec =" + r.GetString("id_specifikacije");
                        MySqlDataReader r2 = upit2.ExecuteReader();
                        while (r2.Read())
                        {
                            Byte[] slikaTEMP = new Byte[65536];
                            r.GetBytes(4, 0, slikaTEMP, 0, 65536);
                            BitmapImage slika = byteArrayToImage(slikaTEMP);
                            SpecKlavijatura spec = new SpecKlavijatura(r2.GetInt32("godina_proizvodnje"), r2.GetString("proizvodjac"), r2.GetString("model"), r2.GetString("materijal"), r2.GetInt32("broj_tipki"), r2.GetString("zvucnik"), r2.GetDouble("tezina"), r2.GetString("napajanje"));
                            artikli.Add(new Klavijatura(r.GetInt32("serijski_broj"), r.GetString("naziv"), r.GetDouble("cijena"), spec, slika));
                        }
                    }
                    else if (r.GetString("tip_artikla") == "Pojacalo")
                    {
                        upit2.CommandText = "select * from specifikacije sp, spec_pojacala sg where sp.id_spec = sg.id_spec and sp.id_spec =" + r.GetString("id_specifikacije");
                        MySqlDataReader r2 = upit2.ExecuteReader();
                        while (r2.Read())
                        {
                            Byte[] slikaTEMP = new Byte[65536];
                            r.GetBytes(4, 0, slikaTEMP, 0, 65536);
                            BitmapImage slika = byteArrayToImage(slikaTEMP);
                            SpecPojacalo spec = new SpecPojacalo(r2.GetInt32("godina_proizvodnje"), r2.GetString("proizvodjac"), r2.GetString("model"), r2.GetString("materijal"), r2.GetString("zvucnik"), r2.GetInt32("broj_kanala"), r2.GetBoolean("ulaz_slusalice"));
                            artikli.Add(new Pojacalo(r.GetInt32("serijski_broj"), r.GetString("naziv"), r.GetDouble("cijena"), spec, slika));
                        }
                    }
                    connection2.Close();
                }
                return artikli;
            }
            catch (Exception)
            {
                connection.Close();
                connection2.Close();
                return artikli;
            }
        }

        public Artikal dajPoID(int id)
        {
            Artikal artikal = null;
            MySqlConnection connection2 = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from artikli where serijski_broj =" + id;
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    connection2.Open();
                    MySqlCommand upit2 = new MySqlCommand();
                    upit2.Connection = connection2;
                    if (r.GetString("tip_artikla") == "ElektricnaGitara")
                    {
                        upit2.CommandText = "select * from specifikacije sp, spec_gitara sg where sp.id_spec = sg.id_spec and sp.id_spec =" + r.GetString("id_specifikacije");
                        MySqlDataReader r2 = upit2.ExecuteReader();
                        while (r2.Read())
                        {
                            Byte[] slikaTEMP = new Byte[65536];
                            r.GetBytes(4, 0, slikaTEMP, 0, 65536);
                            BitmapImage slika = byteArrayToImage(slikaTEMP);
                            SpecElektricna spec = new SpecElektricna(r2.GetInt32("godina_proizvodnje"), r2.GetString("proizvodjac"), r2.GetString("model"), r2.GetString("materijal"), r2.GetInt32("broj_zica"), r2.GetString("masinica"), r2.GetString("vrat"), r2.GetString("most"), r2.GetString("pickup"), r2.GetString("elektronika"));
                            string tempTip = r.GetString("tip_gitare");
                            TipElektronika tip;
                            if (tempTip == "Elektricna") tip = TipElektronika.Elektricna;
                            else tip = TipElektronika.Bass;
                            artikal = new ElektricnaGitara(r.GetInt32("serijski_broj"), r.GetString("naziv"), r.GetDouble("cijena"), spec, slika, tip);
                        }
                    }
                    else if (r.GetString("tip_artikla") == "KlasicnaGitara")
                    {
                        upit2.CommandText = "select * from specifikacije sp, spec_gitara sg where sp.id_spec = sg.id_spec and sp.id_spec =" + r.GetString("id_specifikacije");
                        MySqlDataReader r2 = upit2.ExecuteReader();
                        while (r2.Read())
                        {
                            Byte[] slikaTEMP = new Byte[65536];
                            r.GetBytes(4, 0, slikaTEMP, 0, 65536);
                            BitmapImage slika = byteArrayToImage(slikaTEMP);
                            SpecKlasicna spec = new SpecKlasicna(r2.GetInt32("godina_proizvodnje"), r2.GetString("proizvodjac"), r2.GetString("model"), r2.GetString("materijal"), r2.GetInt32("broj_zica"), r2.GetString("masinica"));
                            string tempTip = r.GetString("tip_gitare");
                            TipKlasicne tip;
                            if (tempTip == "Akusticna") tip = TipKlasicne.Akusticna;
                            else tip = TipKlasicne.Klasicna;
                            artikal = new KlasicnaGitara(r.GetInt32("serijski_broj"), r.GetString("naziv"), r.GetDouble("cijena"), spec, slika, tip);
                        }
                    }
                    else if (r.GetString("tip_artikla") == "Klavijatura")
                    {
                        upit2.CommandText = "select * from specifikacije sp, spec_klavijature sg where sp.id_spec = sg.id_spec and sp.id_spec =" + r.GetString("id_specifikacije");
                        MySqlDataReader r2 = upit2.ExecuteReader();
                        while (r2.Read())
                        {
                            Byte[] slikaTEMP = new Byte[65536];
                            r.GetBytes(4, 0, slikaTEMP, 0, 65536);
                            BitmapImage slika = byteArrayToImage(slikaTEMP);
                            SpecKlavijatura spec = new SpecKlavijatura(r2.GetInt32("godina_proizvodnje"), r2.GetString("proizvodjac"), r2.GetString("model"), r2.GetString("materijal"), r2.GetInt32("broj_tipki"), r2.GetString("zvucnik"), r2.GetDouble("tezina"), r2.GetString("napajanje"));
                            artikal = new Klavijatura(r.GetInt32("serijski_broj"), r.GetString("naziv"), r.GetDouble("cijena"), spec, slika);
                        }
                    }
                    else if (r.GetString("tip_artikla") == "Pojacalo")
                    {
                        upit2.CommandText = "select * from specifikacije sp, spec_pojacala sg where sp.id_spec = sg.id_spec and sp.id_spec =" + r.GetString("id_specifikacije");
                        MySqlDataReader r2 = upit2.ExecuteReader();
                        while (r2.Read())
                        {
                            Byte[] slikaTEMP = new Byte[65536];
                            r.GetBytes(4, 0, slikaTEMP, 0, 65536);
                            BitmapImage slika = byteArrayToImage(slikaTEMP);
                            SpecPojacalo spec = new SpecPojacalo(r2.GetInt32("godina_proizvodnje"), r2.GetString("proizvodjac"), r2.GetString("model"), r2.GetString("materijal"), r2.GetString("zvucnik"), r2.GetInt32("broj_kanala"), r2.GetBoolean("ulaz_slusalice"));
                            artikal = new Pojacalo(r.GetInt32("serijski_broj"), r.GetString("naziv"), r.GetDouble("cijena"), spec, slika);
                        }
                    }
                    connection2.Close();
                }
                return artikal;
            }
            catch (Exception)
            {
                connection.Close();
                connection2.Close();
                return artikal;
            }
        }

        public bool dodaj(Artikal objekat)
        {
            MySqlConnection connection2 = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "insert into specifikacije(godina_proizvodnje, proizvodjac, model, materijal) values(@godina_proizvodnje, @proizvodjac, @model, @materijal)";
                upit.Parameters.AddWithValue("@godina_proizvodnje", objekat.Spec.GodinaProizvodnje);
                upit.Parameters.AddWithValue("@proizvodjac", objekat.Spec.Proizvodjac);
                upit.Parameters.AddWithValue("@model", objekat.Spec.Model);
                upit.Parameters.AddWithValue("@materijal", objekat.Spec.Materijal);
                upit.ExecuteNonQuery();
                if (objekat is ElektricnaGitara) {
                    SpecElektricna temp = objekat.Spec as SpecElektricna;
                    upit.CommandText = "insert into spec_gitara values(@id, @masinica, @vrat, @most, @pickup, @elektronika, @broj_zica)";
                    upit.Parameters.AddWithValue("@id", upit.LastInsertedId);
                    upit.Parameters.AddWithValue("@masinica", null);
                    upit.Parameters.AddWithValue("@vrat", temp.Vrat);
                    upit.Parameters.AddWithValue("@most", temp.Most);
                    upit.Parameters.AddWithValue("@pickup", temp.PickUp);
                    upit.Parameters.AddWithValue("@elektronika", temp.Elektronika);
                    upit.Parameters.AddWithValue("@broj_zica", temp.BrojZica);
                    upit.ExecuteNonQuery();
                }
                else if (objekat is KlasicnaGitara) {
                    SpecKlasicna temp = objekat.Spec as SpecKlasicna;
                    upit.CommandText = "insert into spec_gitara values(@id, @masinica, @vrat, @most, @pickup, @elektronika, @broj_zica)";
                    upit.Parameters.AddWithValue("@id", upit.LastInsertedId);
                    upit.Parameters.AddWithValue("@masinica", null);
                    upit.Parameters.AddWithValue("@vrat", temp.Vrat);
                    upit.Parameters.AddWithValue("@most", temp.Most);
                    upit.Parameters.AddWithValue("@pickup", temp.PickUp);
                    upit.Parameters.AddWithValue("@elektronika", temp.Elektronika);
                    upit.Parameters.AddWithValue("@broj_zica", temp.BrojZica);
                    upit.ExecuteNonQuery();
                }
                else if (objekat is Klavijatura) { }
                else if (objekat is Pojacalo) { }
                upit.CommandText = "";

                upit.CommandText = "insert into artikli values(@serijski_broj, @naziv, @cijena, @id_specifikacije, @slika, @tip_artikla, @tip_gitare)";

            }
            catch(Exception)
            {

            }
        }

        public bool obrisi(Artikal objekat)
        {
            throw new NotImplementedException();
        }

        public bool daLiPostoji(Artikal objekat)
        {
            throw new NotImplementedException();
        }


        public BitmapImage byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(byteArrayIn))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
