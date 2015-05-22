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

namespace MuzickiStudioAkord
{
    /// <summary>
    /// Interaction logic for ArtikalControl.xaml
    /// </summary>
    public partial class ArtikalControl : UserControl
    {
        public ArtikalControl()
        {
            InitializeComponent();
        }

        private void korpa_dodaj_Click(object sender, RoutedEventArgs e)
        {
           
            Button b = sender as Button;
            b.Width += 10;
            b.Height += 10;
            MessageBox.Show("Vozdraaa");
            b.Width -= 10;
            b.Height -= 10;
        }

        private void korpa_dodaj_MouseEnter(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.Width += 10;
            b.Height += 10;
        }

        private void korpa_dodaj_MouseLeave(object sender, MouseEventArgs e)
        {
            Button b = sender as Button;
            b.Width -= 10;
            b.Height -= 10;
        }
    }
}
