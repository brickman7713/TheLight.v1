using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Firebase.Database;
using Firebase.Database.Query;
using System.Net.Mail;
using System.Xml.Linq;
using System.Linq;
using System.Xml;
using System.IO;
using MediaManager;
using Android.Widget;
using MediaManager.Player;
using System.Threading.Tasks;
using XamarinFirebase.Helper;
using System.Diagnostics;
using XamarinFirebase.Model;

namespace TheLight
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentView
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped_Home(object sender, System.EventArgs e)
        {
            Console.WriteLine("HomeClicked");
            // Navigation.PushModalAsync(new SettingPage());
            MessagingCenter.Send<App, string>((App)App.Current, "OpenHomeView", "");
        }

        private void TapGestureRecognizer_Tapped_Contact(object sender, System.EventArgs e)
        {
            Console.WriteLine("ContactClicked");
            MessagingCenter.Send<App, string>((App)App.Current, "OpenContactView", "");
        }

        private void TapGestureRecognizer_Tapped_Programming(object sender, System.EventArgs e)
        {
            Console.WriteLine("ProgrammingClicked");
            MessagingCenter.Send<App, string>((App)App.Current, "OpenProgrammingView", "");
        }

        private void TapGestureRecognizer_Tapped_Sports(object sender, System.EventArgs e)
        {
            Console.WriteLine("SportsClicked");
            MessagingCenter.Send<App, string>((App)App.Current, "OpenSportsView", "");
        }

        private void TapGestureRecognizer_Tapped_CSER(object sender, System.EventArgs e)
        {
            Console.WriteLine("CSERClicked");
            MessagingCenter.Send<App, string>((App)App.Current, "OpenCSERView", "");
        }

        private void TapGestureRecognizer_Tapped_Prayer(object sender, System.EventArgs e)
        {
            Console.WriteLine("PrayerClicked");
            MessagingCenter.Send<App, string>((App)App.Current, "OpenPrayerView", "");
        }

        [Obsolete]
        void FacebookLink(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://www.facebook.com/909FM"));
        }

        [Obsolete]
        void InstagramLink(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.instagram.com/909thelight/"));
        }

        [Obsolete]
        void TwitterLink(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("http://twitter.com/909TheLight"));
        }

    }


}