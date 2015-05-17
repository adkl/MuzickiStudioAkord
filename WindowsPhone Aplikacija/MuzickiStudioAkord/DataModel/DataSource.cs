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

        private ObservableCollection<Artikal> artikli;
        public ObservableCollection<Artikal> Artikli
        {
            get { return artikli; }
        }

        public static async Task<IEnumerable<Artikal>> GetArtikliAsync()
        {
            await dataSource.getAllDataAsync();

            return dataSource.Artikli;
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

            Uri dataUri = new Uri("ms-appx:///DataModel/AllData.json");

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
            string jsonText = await FileIO.ReadTextAsync(file);
            JsonObject jsonObject = JsonObject.Parse(jsonText);

            JsonArray jsonArray = jsonObject["ElektricneGitare"].GetArray();

            if(jsonArray.Count != 0)
                foreach (JsonValue itemValue in jsonArray)
                {
                    JsonObject itemObject = itemValue.GetObject();

                    artikli.Add(new ElektricnaGitara(
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

            jsonArray = jsonObject["KlasicneGitare"].GetArray();
            if (jsonArray.Count != 0)
                foreach (JsonValue itemValue in jsonArray)
                {
                    JsonObject itemObject = itemValue.GetObject();

                    artikli.Add(new KlasicnaGitara(
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

            
            jsonArray = jsonObject["Klavijature"].GetArray();
            if (jsonArray.Count != 0)
                foreach (JsonValue itemValue in jsonArray)
                {
                    JsonObject itemObject = itemValue.GetObject();

                    artikli.Add(new Klavijatura(
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

            jsonArray = jsonObject["Pojacala"].GetArray();
            if (jsonArray.Count != 0)
                foreach (JsonValue itemValue in jsonArray)
                {
                    JsonObject itemObject = itemValue.GetObject();

                    artikli.Add(new Pojacalo(
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

        }

        




    }
}
