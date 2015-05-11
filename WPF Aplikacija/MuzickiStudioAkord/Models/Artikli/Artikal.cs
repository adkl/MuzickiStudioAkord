using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    [Serializable]
    public class Artikal
    {
        private int serijskiBroj;
        public int SerijskiBroj
        {
            get { return serijskiBroj; }
            set { serijskiBroj = value; }
        }

        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private double cijena;
        public double Cijena
        {
            get { return cijena; }
            set { cijena = value; }
        }

        private Specifikacija spec;
        internal Specifikacija Spec
        {
            get { return spec; }
            set { spec = value; }
        }

        private string slikaPath;

        public string SlikaPath
        {
            get { return slikaPath; }
            set { slikaPath = value; }
        }


    }
}
