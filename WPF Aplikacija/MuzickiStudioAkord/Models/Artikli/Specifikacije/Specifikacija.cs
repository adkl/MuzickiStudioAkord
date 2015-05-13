using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public abstract class Specifikacija
    {
        private int godinaProizvodnje;

        public int GodinaProizvodnje
        {
            get { return godinaProizvodnje; }
            set { godinaProizvodnje = value; }
        }

        private string proizvodjac;

        public string Proizvodjac
        {
            get { return proizvodjac; }
            set { proizvodjac = value; }
        }

        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private string materijal;

        public string Materijal
        {
            get { return materijal; }
            set { materijal = value; }
        }
        
        public Specifikacija(int godinaProizvodnje, string proizvodjac, string model, string materijal)
        {
            this.GodinaProizvodnje = godinaProizvodnje;
            this.Proizvodjac = proizvodjac;
            this.Model = model;
            this.Materijal = materijal;
        }
    }
}
