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
            //popraviLayout();    
        }
        void popraviLayout()
        {
            System.Drawing.Rectangle workingRectangle =
            Screen.PrimaryScreen.WorkingArea;
            this.Height = workingRectangle.Height * 0.7;
            this.Width = workingRectangle.Width * 0.7;
        }
    }
}
