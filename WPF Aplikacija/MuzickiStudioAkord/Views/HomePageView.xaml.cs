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
    /// Interaction logic for HomePageView.xaml
    /// </summary>
    public partial class HomePageView : Page
    {
        private Frame mainFrame;
        private SastanakView SastanakPage;

        public HomePageView()
        {
            InitializeComponent();
            SastanakPage = new SastanakView();
        }

        public HomePageView(Frame mainFrame)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            SastanakPage = new SastanakView();
            this.mainFrame = mainFrame;
        }

        public HomePageView(Frame mainFrame, SastanakView SastanakPage)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.mainFrame = mainFrame;
            this.SastanakPage = SastanakPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(SastanakPage);
        }
    }
}
