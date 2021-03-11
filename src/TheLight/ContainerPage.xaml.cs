using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace TheLight
{
    [DesignTimeVisible(false)]
    public partial class ContainerPage : ContentPage
    {
        const float FlyoutCornerRadius = 25f;

        bool _isFlyoutOpen = false;
        double _scale;
        uint _flyoutSpeed = 200;
        double _pagePositionX;
        double _flyoutTranslationX;
        
        public ContainerPage()
        {
            InitializeComponent();

            // Set page scale for both content and flyout
            _scale = MainContent.Scale;
            
            _pagePositionX = MainContent.TranslationX;

            // Add event listeners for SizeChanged - Allows us to capture page values after it is rendered
            MainContent.SizeChanged += OnMainContentSizeChanged;

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ContactPage), typeof(ContactPage));
            Routing.RegisterRoute(nameof(ProgrammingPage), typeof(ProgrammingPage));
            Routing.RegisterRoute(nameof(PrayerPage), typeof(PrayerPage));
        }

        /*void OnMainContentSizeChanged(object sender, EventArgs e)
        {
            MainContent.SizeChanged -= OnMainContentSizeChanged;
            _flyoutTranslationX = MainContent.Width * .75;

            if (Flyout.Children.Count == 1 && Flyout.Children[0] is Layout menuPage)
            {
                var flyoutPadding = Flyout.Width - (Flyout.Width * .8);
                (Flyout.Children[0] as Layout).Padding = new Thickness(0, 0, flyoutPadding, 0);
            }
        }*/

        void OnMainContentSizeChanged(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            ContactPage contactPage = new ContactPage();
            ProgrammingPage programmingPage = new ProgrammingPage();
            CSERPage cserPage = new CSERPage();
            SportsPage sportsPage = new SportsPage();
            PrayerPage prayerPage = new PrayerPage();
            MainContent.Content = mainPage;
            mainPage.ToggleMenu += OnToggleMenu;
            contactPage.ToggleMenu += OnToggleMenu;
            programmingPage.ToggleMenu += OnToggleMenu;
            cserPage.ToggleMenu += OnToggleMenu;
            sportsPage.ToggleMenu += OnToggleMenu;
            prayerPage.ToggleMenu += OnToggleMenu;
            
            MessagingCenter.Subscribe<App, string>(App.Current, "OpenContactView", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {

                    MainContent.Content = contactPage;
                    ToggleFlyout();
                });
            });

            MessagingCenter.Subscribe<App, string>(App.Current, "OpenHomeView", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    MainContent.Content = mainPage;
                    ToggleFlyout();
                });
            });

            MessagingCenter.Subscribe<App, string>(App.Current, "OpenProgrammingView", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {

                    MainContent.Content = programmingPage;
                    ToggleFlyout();
                });
            });

            MessagingCenter.Subscribe<App, string>(App.Current, "OpenCSERView", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {

                    MainContent.Content = cserPage;
                    ToggleFlyout();
                });
            }); 
            
            MessagingCenter.Subscribe<App, string>(App.Current, "OpenSportsView", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {

                    MainContent.Content = sportsPage;
                    ToggleFlyout();
                });
            });
            MessagingCenter.Subscribe<App, string>(App.Current, "OpenPrayerView", (snd, arg) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {

                    MainContent.Content = prayerPage;
                    ToggleFlyout();
                });
            });
            MainContent.SizeChanged -= OnMainContentSizeChanged;
            _flyoutTranslationX = MainContent.Width * .75;
            if (Flyout.Children.Count == 1 && Flyout.Children[0] is Layout menuPage)
            {
                var flyoutPadding = Flyout.Width - (Flyout.Width * .8);
                (Flyout.Children[0] as Layout).Padding = new Thickness(0, 0, flyoutPadding, 0);
            }
        }

        void OnToggleMenu(object sender, EventArgs e)
        {
            ToggleFlyout();
        }

        void FlyoutClose(object sender, SwipedEventArgs e)
        {
            if (_isFlyoutOpen)
                ToggleFlyout();
        }

        void FlyoutOpen(object sender, SwipedEventArgs e)
        {
            if (!_isFlyoutOpen)
                ToggleFlyout();
        }

        void ToggleFlyout()
        {
            if (_isFlyoutOpen)
            {
                MainContent.ScaleTo(_scale, _flyoutSpeed);
                MainContent.TranslateTo(_pagePositionX, Flyout.TranslationY, _flyoutSpeed);
                MainContent.CornerRadius = 0;
            }
            else
            {
                MainContent.ScaleTo(_scale * .9, _flyoutSpeed);
                MainContent.TranslateTo(Flyout.TranslationX + _flyoutTranslationX, Flyout.TranslationY, _flyoutSpeed);
                MainContent.CornerRadius = FlyoutCornerRadius;
            }

            _isFlyoutOpen = !_isFlyoutOpen;
        }
    }
}
