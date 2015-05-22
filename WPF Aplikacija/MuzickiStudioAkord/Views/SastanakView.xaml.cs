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
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Ime")
            {
                tb.Text = string.Empty;
                tb.FontStyle = FontStyles.Normal;
            }
        }

        private void textBoxIme_LostFocus(object sender, RoutedEventArgs e)
        {

            TextBox tb = (TextBox)sender;
            if (tb.Text == String.Empty)
            {
                tb.Text = "Ime";
                tb.FontStyle = FontStyles.Italic;
            }
        }
        private void textBoxPrezime_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Prezime")
            {
                tb.Text = string.Empty;
                tb.FontStyle = FontStyles.Normal;
            }
        }

        private void textBoxPrezime_LostFocus(object sender, RoutedEventArgs e)
        {
            
            TextBox tb = (TextBox)sender;
            if (tb.Text == String.Empty)
            {
                tb.Text = "Prezime";
                tb.FontStyle = FontStyles.Italic;
            }
        }

        private void textBoxJMBG_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "JMBG")
            {
                tb.Text = string.Empty;
                tb.FontStyle = FontStyles.Normal;
            }
        }

        private void textBoxJMBG_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == String.Empty)
            {
                tb.Text = "JMBG";
                tb.FontStyle = FontStyles.Italic;
            }
        }

        private void textBoxAdresa_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Adresa")
            {
                tb.Text = string.Empty;
                tb.FontStyle = FontStyles.Normal;
            }
        }

        private void textBoxAdresa_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == String.Empty)
            {
                tb.Text = "Adresa";
                tb.FontStyle = FontStyles.Italic;
            }
        }

        private void textBoxBrojTelefona_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == String.Empty)
            {
                tb.Text = "Broj telefona";
                tb.FontStyle = FontStyles.Italic;
            }
        }

        private void textBoxBrojTelefona_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Broj telefona")
            {
                tb.Text = string.Empty;
                tb.FontStyle = FontStyles.Normal;
            }
        }

        private void textBoxPotrosackaID_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Potrosacka kartica")
            {
                tb.Text = string.Empty;
                tb.FontStyle = FontStyles.Normal;
            }
        }

        private void textBoxPotrosackaID_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == String.Empty)
            {
                tb.Text = "Potrosacka kartica";
                tb.FontStyle = FontStyles.Italic;
            }
        }

        private void textBoxBrojKartice_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Broj kreditne kartice")
            {
                tb.Text = string.Empty;
                tb.FontStyle = FontStyles.Normal;
            }
        }

        private void textBoxBrojKartice_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == String.Empty)
            {
                tb.Text = "Broj kreditne kartice";
                tb.FontStyle = FontStyles.Italic;
            }
        }
    }
}
