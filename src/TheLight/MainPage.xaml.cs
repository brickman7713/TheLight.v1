using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MediaManager;
using MediaManager.Notifications;

namespace TheLight
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentView
    {
        public MainPage()
        {
            InitializeComponent();
        }


        public event EventHandler ToggleMenu;

        void OnMenuTapped(object sender, System.EventArgs e)
        {
            ToggleMenu?.Invoke(sender, e);
        }

        private async void Play(object sender, System.EventArgs e)
        {
            loadingImg.IsVisible = (true);
            playBtn.IsVisible = (false);
            await CrossMediaManager.Current.Play("https://ic.liberty.edu:8443/WQLU");
            playBtn.IsVisible = (true);
            loadingImg.IsVisible = (false);
        }

        private async void Stop(object sender, System.EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
        }

        private async void Pause(object sender, System.EventArgs e)
        {
            await CrossMediaManager.Current.Pause();
        }

    }
}