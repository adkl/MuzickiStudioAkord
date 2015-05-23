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
using System.Windows.Shapes;

namespace MuzickiStudioAkord.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SastanakView SastanakPage { get; set; }
        private KatalogView MainPage { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            SastanakPage = null;
            MainPage = new KatalogView();
            
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "Username")
            {
                tb.Text = String.Empty;
                tb.FontStyle = FontStyles.Normal;
                //Stavi ovdje foreground na black
                Binding b = new Binding("Admin.Username");
                b.ValidatesOnDataErrors = true;
                b.NotifyOnValidationError = true;
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                b.Mode = BindingMode.TwoWay;

                tb.SetBinding(TextBox.TextProperty, b);
            }
            else if(tb.Text == "Password")
            {
                tb.Text = String.Empty;
                Binding b = new Binding("Admin.Password");
                b.ValidatesOnDataErrors = true;
                b.NotifyOnValidationError = true;
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                b.Mode = BindingMode.TwoWay;

                tb.SetBinding(TextBox.TextProperty, b);
                
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == string.Empty)
            {
                tb.Text = "Username";
                tb.FontStyle = FontStyles.Italic;
            }

        }

        private void TextBox_LostFocusPassword(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == string.Empty)
            {
                tb.Text = "Password";
                tb.FontStyle = FontStyles.Italic;
            }
        }

        private void MenuItemUsluge_Click(object sender, RoutedEventArgs e)
        {

            if (SastanakPage == null)
            {
                SastanakPage = new SastanakView();
            }
                mainFrame.Navigate(SastanakPage);

        }

        private void MenuItemHome_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage == null) MainPage = new KatalogView();
            mainFrame.Navigate(MainPage);
        }

        private void mainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(MainPage);
        }

    }
}
