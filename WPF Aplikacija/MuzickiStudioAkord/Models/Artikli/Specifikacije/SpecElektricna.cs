﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.Models
{
    public class SpecElektricna : SpecGitara
    {
        public string Masinica { get; set; }
        public SpecElektricna(int godinaProizvodnje, string proizvodjac, string model, string materijal, int brojZica, string masinica)
            : base(godinaProizvodnje, proizvodjac, model, materijal, brojZica)
        {
            this.Masinica = masinica;
        }
    }
}
