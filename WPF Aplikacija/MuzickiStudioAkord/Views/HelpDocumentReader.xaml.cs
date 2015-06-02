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
using System.Windows.Xps.Packaging;

namespace MuzickiStudioAkord.Views
{
    /// <summary>
    /// Interaction logic for HelpDocumentReader.xaml
    /// </summary>
    public partial class HelpDocumentReader : Window
    {
        public HelpDocumentReader()
        {
            InitializeComponent();
            XpsDocument xps = new XpsDocument("Resources/Muzicki_studio.xps", System.IO.FileAccess.Read);
            docviewer.Document = xps.GetFixedDocumentSequence();
        }
    }
}
