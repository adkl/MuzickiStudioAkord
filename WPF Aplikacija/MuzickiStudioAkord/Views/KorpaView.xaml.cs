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
    /// Interaction logic for KorpaView.xaml
    /// </summary>
    public partial class KorpaView : Window
    {
        public KorpaView(List<ArtikalControl> korpa)
        {
            InitializeComponent();
            foreach (ArtikalControl ac in korpa)
            {
                if(ac.Markiran == true)
                {
                    listboxFolder.Items.Add(new TextBlock { Text = ac.ToString() });
                }
            }
        }
    }
}
