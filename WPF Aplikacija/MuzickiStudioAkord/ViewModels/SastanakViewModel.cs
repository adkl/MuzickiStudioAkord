using MuzickiStudioAkord.DAL;
using MuzickiStudioAkord.Models;
using MuzickiStudioAkord.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MuzickiStudioAkord.ViewModels
{
    public class SastanakViewModel
    {
        public DataBaseSastanci BazaSastanci { get; set; }
        public ICommand UnosSastanka { get; set; }
        public Sastanak UneseniSastanak { get; set; }
        public Klijent SastanakKlijent { get; set; }
        public KreditnaKartica SastanakKreditnaKartica { get; set; }
        public Action CloseAction { get; set; }

        public SastanakViewModel()
        {
            BazaSastanci = new DataBaseSastanci(Resources.BazaPassword);
            UnosSastanka = new RelayCommand(potvrdi);
            SastanakKlijent = new Klijent();
            UneseniSastanak = new Sastanak();
            SastanakKreditnaKartica = new KreditnaKartica();
            CloseAction = new Action(() => restart());
        }

        private object restart()
        {
            SastanakKlijent = new Klijent();
            UneseniSastanak = new Sastanak();
            SastanakKreditnaKartica = new KreditnaKartica();
            return null;
        }
        public void potvrdi(object parametar)
        {
            if (SastanakKlijent.IsValid && SastanakKreditnaKartica.IsValid)
                {
                    SastanakKlijent.Kartica = SastanakKreditnaKartica;
                    UneseniSastanak.Klijent = SastanakKlijent;
                    UneseniSastanak.Naziv = SastanakKlijent.Ime + " " + SastanakKlijent.Prezime;
                    if (BazaSastanci.dodaj(UneseniSastanak))
                        restart();
                }
        }
    }
}
