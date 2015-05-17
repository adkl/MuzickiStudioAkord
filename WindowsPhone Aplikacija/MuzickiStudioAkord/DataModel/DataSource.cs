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
            JsonArray jsonArray = jsonObject["Artikli"].GetArray();

            foreach (JsonValue itemValue in jsonArray)
            {
                JsonObject itemObject = itemValue.GetObject();

                if (itemObject["TipArtikla"].GetString() == "ElektricnaGitara")
                {
                    //ElektricnaGitara eg = new ElektricnaGitara(
                    //                            itemObject["SerijskiBroj"].GetNumber(),
                    //                            itemObject["Naziv"].GetString(),
                    //                            itemObject["Cijena"].GetNumber,
                    //                            new SpecElektricna(
                                                    
                    //                            )
                    //                      ); nastavljam s ovim, vec je kasno pa idem sleep :D
                }
                else if (itemObject["TipArtikla"].GetString() == "KlasicnaGitara")
                {

                }
                else if (itemObject["TipArtikla"].GetString() == "Klavijatura")
                {

                }
                else if (itemObject["TipArtikla"].GetString() == "Pojacalo")
                {

                }
                
                //this.Artikli.Add();
            }
        }

        




    }
}
