﻿using MuzickiStudioAkord.Models;
using MuzickiStudioAkord.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MuzickiStudioAkord.Views
{
    /// <summary>
    /// Interaction logic for KatalogView.xaml
    /// </summary>
    public partial class InventoryView : Page
    {
        public InventoryView()
        {
            InitializeComponent();
            InventoryViewModel artikli  = new InventoryViewModel();
            foreach(Artikal item in artikli.ArtikliInventory.Artikli)
            {
                string opis = item.Spec.GodinaProizvodnje + Environment.NewLine + item.Spec.Materijal + Environment.NewLine + item.Spec.Model + Environment.NewLine + item.Spec.Proizvodjac;
                stackpanelArtikli.Children.Add(new ArtikalControl(item.Naziv, item.Slika, item.Cijena.ToString(), opis));
                stackpanelArtikli.Children.Add(new ArtikalControl(item.Naziv, item.Slika, item.Cijena.ToString(), opis));
                stackpanelArtikli.Children.Add(new ArtikalControl(item.Naziv, item.Slika, item.Cijena.ToString(), opis));
                stackpanelArtikli.Children.Add(new ArtikalControl(item.Naziv, item.Slika, item.Cijena.ToString(), opis));
                stackpanelArtikli.Children.Add(new ArtikalControl(item.Naziv, item.Slika, item.Cijena.ToString(), opis));
                stackpanelArtikli.Children.Add(new ArtikalControl(item.Naziv, item.Slika, item.Cijena.ToString(), opis));
                stackpanelArtikli.Children.Add(new ArtikalControl(item.Naziv, item.Slika, item.Cijena.ToString(), opis));
                stackpanelArtikli.Children.Add(new ArtikalControl(item.Naziv, item.Slika, item.Cijena.ToString(), opis));
            }
        }
    }
}
