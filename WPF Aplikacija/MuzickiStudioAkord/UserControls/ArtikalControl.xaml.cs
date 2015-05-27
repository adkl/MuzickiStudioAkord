using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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

namespace MuzickiStudioAkord
{
    /// <summary>
    /// Interaction logic for ArtikalControl.xaml
    /// </summary>
    public partial class ArtikalControl : UserControl, INotifyPropertyChanged
    {

        private bool markiran;

        public bool Markiran
        {
            get { return markiran; }
            set { markiran = value; OnPropertyChanged("Markiran"); }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ArtikalControl(string nazivArtikla, BitmapImage slikaArtikla, string cijenaArtikla, string opisArtikla)
        {
            InitializeComponent();
            imeArtikla.Content = nazivArtikla;
            Slika.Source = slikaArtikla;
            Cijena.Text = cijenaArtikla;
            Opis.Text = opisArtikla;
            Markiran = false;
        }
        public ArtikalControl()
        {
            Markiran = false;
        }
        private void korpa_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (!Markiran) Markiran = true;
            else Markiran = false;

        }

        public override string ToString()
        {
            return imeArtikla.Content + " " + Cijena.Text;
        }

    }
}
