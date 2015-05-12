using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class Sastanak
    {
        public int Id_sastanak { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
        public string Opis { get; set; }
        public Klijent Klijent { get; set; }
        public Sastanak(int id, string naziv, DateTime datum, string opis, Klijent klijent)
        {

        }
    }
}
