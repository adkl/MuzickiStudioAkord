using MuzickiStudioAkord.DAL;
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
    /// Interaction logic for DodajRadnikaView.xaml
    /// </summary>
    public partial class DodajRadnikaView : Page
    {
        private bool resetuj = false;
        UcitavamView cekajProzor;
        DispatcherTimer dispatcherTimer;

        public DodajRadnikaView()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
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
                DataContext = new MainWindowViewModel();
                resetuj = false;
            }
        }

        private void buttonAddRadnika_Click_1(object sender, RoutedEventArgs e)
        {
            resetuj = true;
            cekajProzor = new UcitavamView();
            cekajProzor.Show();
        }
    }
}
