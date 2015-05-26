﻿using MuzickiStudioAkord.DAL;
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
    /// Interaction logic for DodajRadnikaView.xaml
    /// </summary>
    public partial class DodajRadnikaView : Page
    {
        public DataBaseUposlenici dbUposlenici { get; set; }
        public DodajRadnikaView()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
