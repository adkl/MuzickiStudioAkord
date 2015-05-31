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
    /// Interaction logic for ObrisiRadnika.xaml
    /// </summary>
    public partial class ObrisiRadnikaView : Page
    {
        public ObrisiRadnikaView()
        {
            InitializeComponent();
            DataContext = new ObrisiRadnikaViewModel();
        }

        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString(); 
        }
    }
}
