using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheLight
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SportsPage : ContentView
    {
        public SportsPage()
        {
            InitializeComponent();
        }

        public event EventHandler ToggleMenu;

        void OnMenuTapped(object sender, System.EventArgs e)
        {
            ToggleMenu?.Invoke(sender, e);
        }
    }
}