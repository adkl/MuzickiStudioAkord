using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class Klijent : Osoba
    {
        private int potrosackaKarticaID;
        public int PotrosackaKarticaID
        {
            get { return potrosackaKarticaID; }
            set { potrosackaKarticaID = value; }
        }

        private KreditnaKartica kartica;
        internal KreditnaKartica Kartica
        {
            get { return kartica; }
            set { kartica = value; }
        }

        private List<Narudzba> narudzbe;

        internal List<Narudzba> Narudzbe
        {
            get { return narudzbe; }
            set { narudzbe = value; }
        }

        public Klijent(string firstName, string lastName, string jmbg, string adresa, string brTel, int potrosackaID, KreditnaKartica card)
            : base(firstName, lastName, jmbg, adresa, brTel)
        {
            PotrosackaKarticaID = potrosackaID;
            kartica = card;
        }
    }
}
