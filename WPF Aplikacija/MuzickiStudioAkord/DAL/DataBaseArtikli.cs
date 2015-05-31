using MuzickiStudioAkord.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Artikal> dajSve()
        {
            ObservableCollection<Artikal> artikli = new ObservableCollection<Artikal>();
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
                            SpecElektricna spec = new SpecElektricna(r2.GetInt32("godina_proizvodnje"), r2.GetString("proizvodjac"), r2.GetString("model"), r2.GetString("materijal"), r2.GetInt32("broj_zica"), r2.GetString("vrat"), r2.GetString("most"), r2.GetString("pickup"), r2.GetString("elektronika"));
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
                connection.Close();
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
                            SpecElektricna spec = new SpecElektricna(r2.GetInt32("godina_proizvodnje"), r2.GetString("proizvodjac"), r2.GetString("model"), r2.GetString("materijal"), r2.GetInt32("broj_zica"), r2.GetString("vrat"), r2.GetString("most"), r2.GetString("pickup"), r2.GetString("elektronika"));
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
                connection.Close();
                return artikal;
            }
            catch (Exception)
            {
                connection.Close();
                connection2.Close();
                return artikal;
            }
        }

        public bool dodaj(Object o)
        {
            MySqlConnection connection2 = new MySqlConnection(connectionString);
            try
            {
                long id_specifikacije = 0;
                Artikal objekat = o as Artikal;
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "insert into specifikacije(godina_proizvodnje, proizvodjac, model, materijal) values(@godina_proizvodnje, @proizvodjac, @model, @materijal)";
                upit.Parameters.AddWithValue("@godina_proizvodnje", objekat.Spec.GodinaProizvodnje);
                upit.Parameters.AddWithValue("@proizvodjac", objekat.Spec.Proizvodjac);
                upit.Parameters.AddWithValue("@model", objekat.Spec.Model);
                upit.Parameters.AddWithValue("@materijal", objekat.Spec.Materijal);
                upit.ExecuteNonQuery();
                id_specifikacije = upit.LastInsertedId;
                if (objekat is ElektricnaGitara)
                {
                    ElektricnaGitara ob = o as ElektricnaGitara;
                    SpecElektricna temp = ob.SpecEl;
                    upit.CommandText = "insert into spec_gitara values(@id, @masinica, @vrat, @most, @pickup, @elektronika, @broj_zica)";
                    upit.Parameters.AddWithValue("@id", upit.LastInsertedId);
                    upit.Parameters.AddWithValue("@masinica", null);
                    upit.Parameters.AddWithValue("@vrat", temp.Vrat);
                    upit.Parameters.AddWithValue("@most", temp.Most);
                    upit.Parameters.AddWithValue("@pickup", temp.PickUp);
                    upit.Parameters.AddWithValue("@elektronika", temp.Elektronika);
                    upit.Parameters.AddWithValue("@broj_zica", temp.BrojZica);
                    upit.ExecuteNonQuery();
                    upit.CommandText = "insert into artikli values(@serijski_broj, @naziv, @cijena, @id_specifikacije, @slika, @tip_artikla, @tip_gitare)";
                    upit.Parameters.AddWithValue("@serijski_broj", ob.SerijskiBroj);
                    upit.Parameters.AddWithValue("@naziv", ob.Naziv);
                    upit.Parameters.AddWithValue("@cijena", ob.Cijena);
                    upit.Parameters.AddWithValue("@id_specifikacije", id_specifikacije);
                    upit.Parameters.AddWithValue("@slika", getJPGFromImageControl(ob.Slika));
                    upit.Parameters.AddWithValue("@tip_artikla", 1);
                    if (((ElektricnaGitara)(ob)).Tip == TipElektronika.Elektricna) upit.Parameters.AddWithValue("@tip_gitare", 3);
                    else upit.Parameters.AddWithValue("@tip_gitare", 4);
                    upit.ExecuteNonQuery();
                }
                else if (objekat is KlasicnaGitara)
                {
                    KlasicnaGitara git = o as KlasicnaGitara;
                    SpecKlasicna temp = git.SpecKL;
                    upit.CommandText = "insert into spec_gitara values(@id, @masinica, @vrat, @most, @pickup, @elektronika, @broj_zica)";
                    upit.Parameters.AddWithValue("@id", upit.LastInsertedId);
                    upit.Parameters.AddWithValue("@masinica", temp.Masinica);
                    upit.Parameters.AddWithValue("@vrat", null);
                    upit.Parameters.AddWithValue("@most", null);
                    upit.Parameters.AddWithValue("@pickup", null);
                    upit.Parameters.AddWithValue("@elektronika", null);
                    upit.Parameters.AddWithValue("@broj_zica", temp.BrojZica);
                    upit.ExecuteNonQuery();
                    upit.CommandText = "insert into artikli values(@serijski_broj, @naziv, @cijena, @id_specifikacije, @slika, @tip_artikla, @tip_gitare)";
                    upit.Parameters.AddWithValue("@serijski_broj", git.SerijskiBroj);
                    upit.Parameters.AddWithValue("@naziv", git.Naziv);
                    upit.Parameters.AddWithValue("@cijena", git.Cijena);
                    upit.Parameters.AddWithValue("@id_specifikacije", id_specifikacije);
                    upit.Parameters.AddWithValue("@slika", getJPGFromImageControl(git.Slika));
                    upit.Parameters.AddWithValue("@tip_artikla", 2);
                    if (((KlasicnaGitara)(git)).Tip == TipKlasicne.Akusticna) upit.Parameters.AddWithValue("@tip_gitare", 2);
                    else upit.Parameters.AddWithValue("@tip_gitare", 1);
                    upit.ExecuteNonQuery();
                }
                else if (objekat is Klavijatura)
                {
                    Klavijatura oo = o as Klavijatura;
                    SpecKlavijatura temp = oo.SpecKl;
                    upit.CommandText = "insert into spec_klavijature values(@id, @broj_tipki, @zvucnik, @tezina, @napajanje)";
                    upit.Parameters.AddWithValue("@id", upit.LastInsertedId);
                    upit.Parameters.AddWithValue("@broj_tipki", temp.BrojTipki);
                    upit.Parameters.AddWithValue("@zvucnik", temp.Zvucnik);
                    upit.Parameters.AddWithValue("@tezina", temp.Tezina);
                    upit.Parameters.AddWithValue("@napajanje", temp.Napajanje);
                    upit.ExecuteNonQuery();
                    upit.CommandText = "insert into artikli values(@serijski_broj, @naziv, @cijena, @id_specifikacije, @slika, @tip_artikla, @tip_gitare)";
                    upit.Parameters.AddWithValue("@serijski_broj", oo.SerijskiBroj);
                    upit.Parameters.AddWithValue("@naziv", oo.Naziv);
                    upit.Parameters.AddWithValue("@cijena", oo.Cijena);
                    upit.Parameters.AddWithValue("@id_specifikacije", id_specifikacije);
                    upit.Parameters.AddWithValue("@slika", getJPGFromImageControl(oo.Slika));
                    upit.Parameters.AddWithValue("@tip_artikla", 3);
                    upit.Parameters.AddWithValue("@tip_gitare", null);
                    upit.ExecuteNonQuery();
                }
                else if (objekat is Pojacalo)
                {
                    Pojacalo oo = o as Pojacalo;
                    SpecPojacalo temp = oo.SpecPo as SpecPojacalo;
                    upit.CommandText = "insert into spec_pojacala values(@id, @zvucnik, @broj_kanala, @ulaz_slusalice)";
                    upit.Parameters.AddWithValue("@id", upit.LastInsertedId);
                    upit.Parameters.AddWithValue("@zvucnik", temp.Zvucnik);
                    upit.Parameters.AddWithValue("@broj_kanala", temp.BrojKanala);
                    upit.Parameters.AddWithValue("@ulaz_slusalice", temp.UlazZaSlusalice);
                    upit.ExecuteNonQuery();
                    upit.CommandText = "insert into artikli values(@serijski_broj, @naziv, @cijena, @id_specifikacije, @slika, @tip_artikla, @tip_gitare)";
                    upit.Parameters.AddWithValue("@serijski_broj", oo.SerijskiBroj);
                    upit.Parameters.AddWithValue("@naziv", oo.Naziv);
                    upit.Parameters.AddWithValue("@cijena", oo.Cijena);
                    upit.Parameters.AddWithValue("@id_specifikacije", id_specifikacije);
                    upit.Parameters.AddWithValue("@slika", getJPGFromImageControl(oo.Slika));
                    upit.Parameters.AddWithValue("@tip_artikla", 4);
                    upit.Parameters.AddWithValue("@tip_gitare", null);
                    upit.ExecuteNonQuery();
                }
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                connection2.Close();
                return false;
            }
        }

        public bool obrisi(Artikal objekat)
        {
            try
            {
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "delete from artikli where serijski_broj = @sBroj";
                upit.Parameters.AddWithValue("@sBroj", objekat.SerijskiBroj);
                upit.ExecuteNonQuery();
                return true;
            }
            catch(Exception)
            {
                connection.Close();
                return false;
            }
        }
        public bool obrisi(int sBroj)
        {
            try
            {
                connection.Open();
                uint  id_spec = 0;
                string tipArtikla = String.Empty;
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from artikli where serijski_broj = @sBroj";
                upit.Parameters.AddWithValue("@sBroj", sBroj);
                MySqlDataReader r = upit.ExecuteReader();
                r.Read();
                id_spec = r.GetUInt32("id_specifikacije");
                tipArtikla = r.GetString("tip_artikla");

                r.Close();

                upit.CommandText = "delete from artikli where serijski_broj = @sBroj";
                //upit.Parameters.AddWithValue("@sBroj", sBroj);
                upit.ExecuteNonQuery();

                //klavijature
                if(tipArtikla == "Klavijatura")
                {
                    upit.CommandText = "delete from spec_klavijature where id_spec = @specBroj";
                    upit.Parameters.AddWithValue("@specBroj", id_spec);
                    upit.ExecuteNonQuery();
                }
                else if (tipArtikla == "KlasicnaGitara" || tipArtikla == "ElektricnaGitara")
                {
                    upit.CommandText = "delete from spec_gitara where id_spec = @specBroj";
                    upit.Parameters.AddWithValue("@specBroj", id_spec);
                    upit.ExecuteNonQuery();
                }
                else if(tipArtikla == "Pojacalo")
                {
                    upit.CommandText = "delete from spec_gitara where id_spec = @specBroj";
                    upit.Parameters.AddWithValue("@specBroj", id_spec);
                    upit.ExecuteNonQuery();
                }
                upit.CommandText = "delete from specifikacije where id_spec = @specBroj";
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
        public bool daLiPostoji(Artikal objekat)
        {
            try
            {
                connection.Open();
                MySqlCommand upit = new MySqlCommand();
                upit.Connection = connection;
                upit.CommandText = "select * from artikli where serijski_broj = @sBroj";
                upit.Parameters.AddWithValue("@sBroj", objekat.SerijskiBroj);
                MySqlDataReader r = upit.ExecuteReader();
                while (r.Read())
                {
                    if (r.GetInt32("serijski_broj") == objekat.SerijskiBroj)
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
        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.GetBuffer();
        }
    }
}
