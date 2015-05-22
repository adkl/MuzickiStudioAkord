﻿using MuzickiStudioAkord.ViewModels;
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
    /// Interaction logic for SastanakView.xaml
    /// </summary>
    public partial class SastanakView : Page
    {
        public SastanakView()
        {
            InitializeComponent();
            DataContext = new SastanakViewModel();
        }

        private void textBoxIme_GotFocus(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
