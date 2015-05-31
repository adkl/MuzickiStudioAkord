using MuzickiStudioAkord.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for SastanakView.xaml
    /// </summary>
    public partial class SastanakView : Page
    {
        private bool resetuj = false;
        DispatcherTimer dispatcherTimer;
       
        public SastanakView()
        {
            InitializeComponent();
            threadTest.Content = DateTime.UtcNow;
            DataContext = new SastanakViewModel();
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            threadTest.Content = DateTime.UtcNow;
           if(resetuj)
           {
               UcitavamView uc = new UcitavamView();
               uc.Show();
               Thread.Sleep(1000);
               uc.Close();
               DataContext = new SastanakViewModel();
               resetuj = false;
           }
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

        private void buttonPotvrda_Click(object sender, RoutedEventArgs e)
        {
            resetuj = true;
        }
    }
}
