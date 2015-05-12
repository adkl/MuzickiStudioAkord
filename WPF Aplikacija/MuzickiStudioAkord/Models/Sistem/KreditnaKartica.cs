using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class KreditnaKartica
    {
        public int id_kartice { get; set; }
        public int ccv { get; set; }
        public DateTime datum_isteka { get; set; }
        public KreditnaKartica(int id_kartice, int ccv, DateTime datum_isteka)
        {

        }
    }
}
