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

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Name == "textBoxIme")
            {
                Binding b = new Binding("SastanakKlijent.Ime");
                b.ValidatesOnDataErrors = true;
                b.NotifyOnValidationError = true;
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                b.Mode = BindingMode.TwoWay;

                tb.SetBinding(TextBox.TextProperty, b);
            }
            else if (tb.Name == "textBoxPrezime")
            {
                Binding b = new Binding("SastanakKlijent.Prezime");
                b.ValidatesOnDataErrors = true;
                b.NotifyOnValidationError = true;
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                b.Mode = BindingMode.TwoWay;

                tb.SetBinding(TextBox.TextProperty, b);
            }
            else if (tb.Name == "textBoxJMBG")
            {
                Binding b = new Binding("SastanakKlijent.Jmbg");
                b.ValidatesOnDataErrors = true;
                b.NotifyOnValidationError = true;
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                b.Mode = BindingMode.TwoWay;

                tb.SetBinding(TextBox.TextProperty, b);
            }
            else if (tb.Name == "textBoxAdresa")
            {
                Binding b = new Binding("SastanakKlijent.Adresa");
                b.ValidatesOnDataErrors = true;
                b.NotifyOnValidationError = true;
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                b.Mode = BindingMode.TwoWay;

                tb.SetBinding(TextBox.TextProperty, b);
            }
            else if (tb.Name == "textBoxBrojTelefona")
            {
                Binding b = new Binding("SastanakKlijent.BrojTelefona");
                b.ValidatesOnDataErrors = true;
                b.NotifyOnValidationError = true;
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                b.Mode = BindingMode.TwoWay;

                tb.SetBinding(TextBox.TextProperty, b);
            }
            else if (tb.Name == "textBoxEmail")
            {
                Binding b = new Binding("SastanakKlijent.Email");
                b.ValidatesOnDataErrors = true;
                b.NotifyOnValidationError = true;
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                b.Mode = BindingMode.TwoWay;

                tb.SetBinding(TextBox.TextProperty, b);
            }
            else if (tb.Name == "textBoxPotrosackaID")
            {
                Binding b = new Binding("SastanakKlijent.PotrosackaKarticaID");
                b.ValidatesOnDataErrors = true;
                b.NotifyOnValidationError = true;
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                b.Mode = BindingMode.TwoWay;

                tb.SetBinding(TextBox.TextProperty, b);
            }
            else if (tb.Name == "textBoxBrojKartice")
            {
                Binding b = new Binding("SastanakKreditnaKartica.Id_kartice");
                b.ValidatesOnDataErrors = true;
                b.NotifyOnValidationError = true;
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                b.Mode = BindingMode.TwoWay;

                tb.SetBinding(TextBox.TextProperty, b);
            }
            else if (tb.Name == "textBoxCCV")
            {
                Binding b = new Binding("SastanakKreditnaKartica.Ccv");
                b.ValidatesOnDataErrors = true;
                b.NotifyOnValidationError = true;
                b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                b.Mode = BindingMode.TwoWay;

                tb.SetBinding(TextBox.TextProperty, b);
            }
        }
    }
}
