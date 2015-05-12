﻿using MuzickiStudioAkord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuzickiStudioAkord.DAL
{
    interface IDataBase<O>
    {
        //Vrati sve iz tabele
        List<O> dajSve();

        //Daj objekat po ID
        O dajPoID(int id);

        //Dodaj jedan objekat, vraca true ako je uspjesno dodao
        bool dodaj(O objekat);

        //Obrisi
        bool obrisi(O objekat);

        //Provjeri da li postoji objekat
        bool daLiPostoji(O objekat);

        

    }
}