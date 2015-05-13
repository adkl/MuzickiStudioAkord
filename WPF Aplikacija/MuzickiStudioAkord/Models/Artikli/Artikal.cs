﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        private Specifikacija spec;
        public Specifikacija Spec
        {
            get { return spec; }
            set { spec = value; }
        }

        private Image slika;
        private SpecPojacalo spec1;
        public Image Slika
        {
            get { return slika; }
            set { slika = value; }
        }
        public Artikal(int serijskiBroj, string naziv, double cijena, Specifikacija spec, Image slika)
        {
            this.SerijskiBroj = serijskiBroj;
            this.Naziv = naziv;
            this.Cijena = cijena;
            this.Spec = spec;
            this.Slika = slika;
        }
    }
}
