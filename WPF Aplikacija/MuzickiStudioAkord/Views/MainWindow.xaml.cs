using MuzickiStudioAkord.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace MuzickiStudioAkord.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InventoryView ArtikliPage { get; set; }
        private DodavanjeArtiklaView DodajArtikal { get; set; }
        private SastanakView SastanakPage { get; set; }
        public HomePageView  HomePage { get; set; }
        private PasswordChangeView ProfilePage { get; set; }
        private ObrisiArtiklaView ObrisiArtikalPage { get; set; }
        private DodajRadnikaView DodajRadnikaPage { get; set; }
        public ObrisiRadnikaView ObrisiRadnikaPage { get; set; }
        public PregledSastanakaView PregledSastanakPage { get; set; }
        private PasswordChangeView PasswordChangePage { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text == "Username")
            {
                tb.Text = String.Empty;
                tb.FontStyle = FontStyles.Normal;
                //Stavi ovdje foreground na black
                Binding b = new Binding("LoginUsername");
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
            if (SastanakPage == null) SastanakPage = new SastanakView();
            mainFrame.NavigationService.Navigate(SastanakPage);
        }

        private void MenuItemShop_Click(object sender, RoutedEventArgs e)
        {
            ArtikliPage = new InventoryView();
            mainFrame.NavigationService.Navigate(ArtikliPage);
        }

        private void mainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            if (HomePage == null) HomePage = new HomePageView();
            mainFrame.Navigate(HomePage);
            
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(DodajArtikal == null) DodajArtikal = new DodavanjeArtiklaView();
            mainFrame.Navigate(DodajArtikal);
        }

        private void MenuItemHome_Click_1(object sender, RoutedEventArgs e)
        {
            if (HomePage == null) HomePage = new HomePageView();
            mainFrame.Navigate(HomePage);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (DodajRadnikaPage == null) DodajRadnikaPage = new DodajRadnikaView();
            mainFrame.Navigate(DodajRadnikaPage);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if(ProfilePage == null) ProfilePage = new PasswordChangeView();
            mainFrame.Navigate(ProfilePage);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            if (ObrisiArtikalPage == null) ObrisiArtikalPage = new ObrisiArtiklaView();
            mainFrame.Navigate(ObrisiArtikalPage);
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            if (ObrisiRadnikaPage == null) ObrisiRadnikaPage = new ObrisiRadnikaView();
            mainFrame.Navigate(ObrisiRadnikaPage);
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            if (PregledSastanakPage == null) PregledSastanakPage = new PregledSastanakaView();
            mainFrame.Navigate(PregledSastanakPage);
        }
       
        private void MenuItemSnimi_Click(object sender, RoutedEventArgs e)
        {
            string direktorij = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(@"Mikrofon");
            Process.Start("VoiceRecorder.exe");
            Directory.SetCurrentDirectory(direktorij); 
        }

        private void helpMenuClick(object sender, RoutedEventArgs e)
        {
            HelpDocumentReader hdr = new HelpDocumentReader();
            hdr.Show();
        } 
    }
}
