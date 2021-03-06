﻿using MuzickiStudioAkord.Models;
using MuzickiStudioAkord.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace MuzickiStudioAkord.Views
{
    /// <summary>
    /// Interaction logic for DodavanjeArtiklaView.xaml
    /// </summary>
    public partial class DodavanjeArtiklaView : Page
    {
        bool resetuj = false;
        UcitavamView cekajProzor;
        DispatcherTimer dispatcherTimer;
        public DodavanjeArtiklaView()
        {
            InitializeComponent();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (resetuj)
            {
                Thread.Sleep(1000);
                cekajProzor.Close();
                DataContext = new InventoryViewModel();
                stackPanelKlasicnaGitra.Visibility = Visibility.Hidden;
                stackPanelElektricnaGitra.Visibility = Visibility.Hidden;
                stackPanelKlavijature.Visibility = Visibility.Hidden;
                stackPanelPojacalo.Visibility = Visibility.Hidden;
                slikaArtikla.Source = null;
                resetuj = false;
            }
        }
        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "All Image Files | *.*";
            if (dlg.ShowDialog() == true)
            {
                slikaArtikla.Source = new BitmapImage(new Uri(dlg.FileName, UriKind.Absolute));
                (DataContext as InventoryViewModel).noviArtikal.Slika = slikaArtikla.Source as BitmapImage;
            }
        }

        private void comboBoxTipArtikla_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBox cb = sender as ComboBox;
            stackPanelKlasicnaGitra.Visibility = Visibility.Hidden;
            stackPanelElektricnaGitra.Visibility = Visibility.Hidden;
            stackPanelKlavijature.Visibility = Visibility.Hidden;
            stackPanelPojacalo.Visibility = Visibility.Hidden;
            //Elektricna gitara
            if(cb.SelectedIndex == 0)
            {
                stackPanelElektricnaGitra.Visibility = Visibility.Visible;
                DataContext = new InventoryViewModel("Elektricna gitara");
            }
            //Klasicna gitara
            if (cb.SelectedIndex == 1)
            {
                stackPanelKlasicnaGitra.Visibility = Visibility.Visible;
                DataContext = new InventoryViewModel("Klasicna gitara");
            }
            //Klavijature
            if (cb.SelectedIndex == 2)
            {
                stackPanelKlavijature.Visibility = Visibility.Visible;
                DataContext = new InventoryViewModel("Klavijature");
            }
            //Pojacalo
            if (cb.SelectedIndex == 3)
            {
                stackPanelPojacalo.Visibility = Visibility.Visible;
                DataContext = new InventoryViewModel("Pojacalo");
            }
        }

        private void comboBoxTipElektricneGitare_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedIndex == 0)
            {
               ((DataContext as InventoryViewModel).noviArtikal as ElektricnaGitara).Tip = TipElektronika.Elektricna;
            }
            else ((DataContext as InventoryViewModel).noviArtikal as ElektricnaGitara).Tip = TipElektronika.Bass;
        }

        private void comboBoxTipKlasicneGitare_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedIndex == 0)
            {
                ((DataContext as InventoryViewModel).noviArtikal as KlasicnaGitara).Tip = TipKlasicne.Klasicna;
            }
            else ((DataContext as InventoryViewModel).noviArtikal as KlasicnaGitara).Tip = TipKlasicne.Akusticna;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            resetuj = true;
            cekajProzor = new UcitavamView();
            cekajProzor.Show();
        }
    }
}
