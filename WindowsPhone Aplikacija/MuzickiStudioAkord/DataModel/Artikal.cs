using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Controls;
//using System.Windows.Media.Imaging;


namespace MuzickiStudioAkord.Models
{
    public abstract class Artikal
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

        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }
        private string opiS;
        public string Opis
        {
            get
            {
                return opiS;
            }
            set
            {
                opiS = value;
            }
        }
        public Artikal(int serijskiBroj, string naziv, double cijena, string imagepath)
        {
            this.SerijskiBroj = serijskiBroj;
            this.Naziv = naziv;
            this.Cijena = cijena;
            this.ImagePath = imagepath;
        }

        public abstract string opis();


    }
}
