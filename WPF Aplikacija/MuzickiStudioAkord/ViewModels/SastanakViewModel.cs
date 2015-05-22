﻿using MuzickiStudioAkord.DAL;
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
        public Action CloseAction { get; set; }
        public Sastanak UneseniSastanak { get; set; }
        public Klijent SastanakKlijent { get; set; }

        public SastanakViewModel()
        {
            BazaSastanci = new DataBaseSastanci(Resources.BazaPassword);
            UnosSastanka = new RelayCommand(potvrdi);
            SastanakKlijent = new Klijent();
        }
        public void potvrdi(object parametar)
        {
                if (SastanakKlijent.IsValidBase && SastanakKlijent.Kartica.IsValid && SastanakKlijent.IsValidKlijent)
                {

                    CloseAction();
                }
        }
    }
}
