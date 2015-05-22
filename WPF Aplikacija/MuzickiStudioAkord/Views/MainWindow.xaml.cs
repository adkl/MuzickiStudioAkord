using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MuzickiStudioAkord.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workingRectangle =
            Screen.PrimaryScreen.WorkingArea;

            // Set the size of the form slightly less than size of  
            // working rectangle. 
            this.Height = workingRectangle.Height * 0.9;
            this.Width = workingRectangle.Width * 0.7;
        }
    }
}
