using MuzickiStudioAkord.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace MuzickiStudioAkord.DataModel
{
    public sealed class DataSource
    {
        private static DataSource dataSource = new DataSource();

        private ObservableCollection<Artikal> artikli = new ObservableCollection<Artikal>();
        public ObservableCollection<Artikal> Artikli
        {
            get { return this.artikli; }
        }

        public ObservableCollection<Artikal> Gitare = new ObservableCollection<Artikal>();
        public ObservableCollection<Pojacalo> Pojacala = new ObservableCollection<Pojacalo>();
        public ObservableCollection<Klavijatura> Klavijature = new ObservableCollection<Klavijatura>();

        //private static void popuniData()
        //{
        //    foreach (Artikal item in dataSource.Artikli)
        //    {
        //        if (item is ElektricnaGitara || item is KlasicnaGitara)
        //            dataSource.Gitare.Add(item);
        //        else if (item is Pojacalo)
        //            dataSource.Pojacala.Add(item as Pojacalo);
        //        else
        //            dataSource.Klavijature.Add(item as Klavijatura);
        //    }
        //}

        public static async Task<IEnumerable<Artikal>> GetArtikliAsync()
        {
            await dataSource.getAllDataAsync();

            //DataSource.popuniData();

            return dataSource.Artikli;
        }

        public static async Task<IEnumerable<Artikal>> GetGitareAsync()
        {
            await dataSource.getAllDataAsync();

            //DataSource.popuniData();

            return dataSource.Gitare;
        }

        public static async Task<IEnumerable<Klavijatura>> GetKlavijatureAsync()
        {
            await dataSource.getAllDataAsync();

            //DataSource.popuniData();

            return dataSource.Klavijature;
        }

        public static async Task<IEnumerable<Pojacalo>> GetPojacalaAsync()
        {
            await dataSource.getAllDataAsync();

            //DataSource.popuniData();

            return dataSource.Pojacala;
        }

        public static async Task<Artikal> GetArtikalAsync(string serijski_broj)
        {
            await dataSource.getAllDataAsync();
            // Simple linear search is acceptable for small data sets
            var matches = dataSource.Artikli.Where((item) => item.SerijskiBroj.Equals(serijski_broj));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        private async Task getAllDataAsync()
        {
            if (this.artikli.Count != 0)
                return;
            if (this.Pojacala.Count != 0)
                return;
            if (this.Gitare.Count != 0)
                return;
            if(this.Klavijature.Count != 0)
                return;

            Uri dataUri = new Uri("ms-appx:///DataModel/AllData.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);

            JsonArray jsonArray = jsonObject["Artikli"].GetArray();

            bool elektricneLoaded = false;
            bool klasicneLoaded = false;
            bool pojacalaLoaded = false;
            bool klavijatureLoaded = false;

            foreach (JsonValue groupValue in jsonArray)
            {
                JsonObject groupObject = groupValue.GetObject();



                if (elektricneLoaded == false)
                {
                    foreach (JsonValue itemValue in groupObject["ElektricneGitare"].GetArray())
                    {

                        JsonObject itemObject = itemValue.GetObject();
                        this.Gitare.Add(new ElektricnaGitara(
                                    (int)itemObject["SerijskiBroj"].GetNumber(),
                                    itemObject["Naziv"].GetString(),
                                    itemObject["Cijena"].GetNumber(),
                                    new SpecElektricna(
                                        (int)itemObject["GodinaProizvodnje"].GetNumber(),
                                        itemObject["Proizvodjac"].GetString(),
                                        itemObject["Model"].GetString(),
                                        itemObject["Materijal"].GetString(),
                                        (int)itemObject["BrojZica"].GetNumber(),
                                        itemObject["Masinica"].GetString(),
                                        itemObject["Vrat"].GetString(),
                                        itemObject["Most"].GetString(),
                                        itemObject["PickUp"].GetString(),
                                        itemObject["Elektronika"].GetString()
                                    ),
                                    itemObject["ImagePath"].GetString(),
                                    (itemObject["TipElektronika"].GetString() == "Elektricna" ? TipElektronika.Elektricna : TipElektronika.Bass)
                                ));
                    }
                    elektricneLoaded = true;
                    continue;
                }

                if (klasicneLoaded == false)
                {
                    foreach (JsonValue itemValue in groupObject["KlasicneGitare"].GetArray())
                    {
                        JsonObject itemObject = itemValue.GetObject();
                        this.Gitare.Add(new KlasicnaGitara(
                                (int)itemObject["SerijskiBroj"].GetNumber(),
                                itemObject["Naziv"].GetString(),
                                itemObject["Cijena"].GetNumber(),
                                new SpecKlasicna(
                                    (int)itemObject["GodinaProizvodnje"].GetNumber(),
                                    itemObject["Proizvodjac"].GetString(),
                                    itemObject["Model"].GetString(),
                                    itemObject["Materijal"].GetString(),
                                    (int)itemObject["BrojZica"].GetNumber(),
                                    itemObject["Masinica"].GetString()
                                ),
                                itemObject["ImagePath"].GetString(),
                                (itemObject["TipKlasika"].GetString() == "Klasicna" ? TipKlasicne.Klasicna : TipKlasicne.Akusticna)
                            ));
                    }
                    klasicneLoaded = true;
                    continue;
                }

                if (klavijatureLoaded == false)
                {
                    foreach (JsonValue itemValue in groupObject["Klavijature"].GetArray())
                    {
                        JsonObject itemObject = itemValue.GetObject();
                        this.Klavijature.Add(new Klavijatura(
                                (int)itemObject["SerijskiBroj"].GetNumber(),
                                itemObject["Naziv"].GetString(),
                                itemObject["Cijena"].GetNumber(),
                                new SpecKlavijatura(
                                    (int)itemObject["GodinaProizvodnje"].GetNumber(),
                                    itemObject["Proizvodjac"].GetString(),
                                    itemObject["Model"].GetString(),
                                    itemObject["Materijal"].GetString(),
                                    (int)itemObject["BrojTipki"].GetNumber(),
                                    itemObject["Zvucnik"].GetString(),
                                    itemObject["Tezina"].GetNumber(),
                                    itemObject["Napajanje"].GetString()
                                ),
                                itemObject["ImagePath"].GetString()
                            ));
                    }
                    klavijatureLoaded = true;
                    continue;
                }

                if (pojacalaLoaded == false)
                {
                    foreach (JsonValue itemValue in groupObject["Pojacala"].GetArray())
                    {
                        JsonObject itemObject = itemValue.GetObject();
                        this.Pojacala.Add(new Pojacalo(
                                (int)itemObject["SerijskiBroj"].GetNumber(),
                                itemObject["Naziv"].GetString(),
                                itemObject["Cijena"].GetNumber(),
                                new SpecPojacalo(
                                    (int)itemObject["GodinaProizvodnje"].GetNumber(),
                                    itemObject["Proizvodjac"].GetString(),
                                    itemObject["Model"].GetString(),
                                    itemObject["Materijal"].GetString(),
                                    itemObject["Zvucnik"].GetString(),
                                    (int)itemObject["BrojKanala"].GetNumber(),
                                    itemObject["UlazZaSlusalice"].GetBoolean()
                                ),
                                itemObject["ImagePath"].GetString()
                            ));
                    }
                    pojacalaLoaded = true;
                    continue;
                }
                       
            }
        }
    }
}
