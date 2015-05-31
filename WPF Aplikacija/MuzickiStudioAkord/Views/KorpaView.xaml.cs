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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MuzickiStudioAkord.Views
{
    /// <summary>
    /// Interaction logic for KorpaView.xaml
    /// </summary>
    public partial class KorpaView : Window
    {
        int total = 0;
        KorpaViewModel kvm = new KorpaViewModel();
        DispatcherTimer dispatcherTimer;
        public KorpaView(List<ArtikalControl> korpa)
        {
            InitializeComponent();
            DataContext = kvm;
            stackpanelPodaci.Visibility = System.Windows.Visibility.Hidden;
            stackPanelNovi.Visibility = System.Windows.Visibility.Hidden;
            stackpanelLogin.Visibility = System.Windows.Visibility.Hidden;
            stackPanelStari.Visibility = System.Windows.Visibility.Hidden;
            foreach (ArtikalControl ac in korpa)
            {
                if(ac.Markiran == true)
                {
                    listboxFolder.Items.Add(new TextBlock { Text = ac.ToString() + " KM" });
                    total += Int32.Parse(ac.Cijena.Text);
                }
            }
            textBlockTotal.Text = "Total: " + total.ToString() + " KM";
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (kvm.Zavrsio)
            {
                kvm = new KorpaViewModel();
                DataContext = kvm;
                this.Close();
            }
        }

        private void tipKlijenta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            stackpanelPodaci.Visibility = System.Windows.Visibility.Hidden;
            stackPanelNovi.Visibility = System.Windows.Visibility.Hidden;
            stackpanelLogin.Visibility = System.Windows.Visibility.Hidden;
            stackPanelStari.Visibility = System.Windows.Visibility.Hidden;
            buttonKupiNovi.Visibility = System.Windows.Visibility.Hidden;
            buttonKupiStari.Visibility = System.Windows.Visibility.Hidden;
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedIndex==0)
            {
                stackpanelPodaci.Visibility = System.Windows.Visibility.Visible;
                stackPanelNovi.Visibility = System.Windows.Visibility.Visible;
                buttonKupiNovi.Visibility = System.Windows.Visibility.Visible;
            }
            else if(cb.SelectedIndex == 1)
            {
                stackpanelLogin.Visibility = System.Windows.Visibility.Visible;
                stackPanelStari.Visibility = System.Windows.Visibility.Visible;
                buttonKupiStari.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
