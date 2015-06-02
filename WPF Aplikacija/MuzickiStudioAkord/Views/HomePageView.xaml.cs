using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Xml.Linq;

namespace MuzickiStudioAkord.Views
{
    /// <summary>
    /// Interaction logic for HomePageView.xaml
    /// </summary>
    public partial class HomePageView : Page
    {
        string sutra;
        public HomePageView()
        {
            InitializeComponent();
        }

        private void prognozaButton_Click(object sender, RoutedEventArgs e)
        {
            Thread nitp;
            nitp = new Thread(new ThreadStart(weather));
            nitp.Start();
            while (nitp.IsAlive) ;
            var dan = DateTime.Today.AddDays(1).Date.ToString();

            textBlockprognoza.Text = sutra;
        }

        private void weather()
        {
            string xmlDoc = dajIzvorniKod("http://rss.theweathernetwork.com/weather/bkxx0004");
            XDocument prognozaDoc = XDocument.Parse(xmlDoc);

            var prognoze = (from p in prognozaDoc.Descendants() where p.Name == "item" select p).ToArray();

            List<string> weatherDescs = new List<string>();
            foreach (var item in prognoze)
            {
                weatherDescs.Add((from node in item.Nodes()
                                  where node.ToString().StartsWith("<description>")
                                  select node.ToString().Substring(13, node.ToString().Length - 27).Trim()).Single());
            }
            foreach (var desc in weatherDescs)
            {
                sutra = formatiranaPrognoza(weatherDescs[1]);
            }

        }

        String dajIzvorniKod(String url)
        {
            try
            {
                WebClient client = new WebClient();
                Byte[] source = client.DownloadData(url);
                String s = System.Text.Encoding.Default.GetString(source);
                return s;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return e.Message;
            }

        }

        string formatiranaPrognoza(string neformatirana)
        {
            string pneformatirana = new string(neformatirana.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
            pneformatirana = pneformatirana.Replace("&amp;nbsp;&amp;deg;", " °");
            string[] pomocni = pneformatirana.Split(',');
            string novi = pomocni[0] + "\n" + pomocni[1] + "\n" + pomocni[2] + "\n" + pomocni[3];
            return novi;
        }
    }
}
