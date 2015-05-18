using MuzickiStudioAkord.Common;
using MuzickiStudioAkord.DataModel;
using MuzickiStudioAkord.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace MuzickiStudioAkord
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly NavigationHelper navigationHelper;
        private readonly ObservableDictionary defaultViewModel = new ObservableDictionary();
        public ObservableDictionary DefaultViewModel
        {
            get { return defaultViewModel; }
        }


        public MainPage()
        {
            this.InitializeComponent();

            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait;

            this.NavigationCacheMode = NavigationCacheMode.Required;

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        private async void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var artikli = await DataSource.GetArtikliAsync();
            this.DefaultViewModel["Artikli"] = artikli;

            var gitare = await DataSource.GetGitareAsync();
            this.DefaultViewModel["Gitare"] = gitare;

            var klavijature = await DataSource.GetKlavijatureAsync();
            this.DefaultViewModel["Klavijature"] = klavijature;

            var pojacala = await DataSource.GetPojacalaAsync();
            this.DefaultViewModel["Pojacala"] = pojacala;
        }
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // TODO: Save the unique state of the page here.
        }
        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var type = ((Artikal)e.ClickedItem);
            var itemId = ((Artikal)e.ClickedItem).SerijskiBroj;

            if (type is ElektricnaGitara)
            {
                //this.Frame.Navigate(typeof(ItemPage), itemId);
            }
            else if (type is KlasicnaGitara)
            {

            }
            else if (type is Klavijatura)
            {

            }
            else if (type is Pojacalo)
            {

            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }
    }
}
