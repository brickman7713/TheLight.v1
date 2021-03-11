using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebase.Helper;
using XamarinFirebase.Model;
using Xamarin.Forms.Core;



namespace TheLight
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgrammingPage : ContentView // OnAppearing() is under ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        Page page = new Page();
        public ProgrammingPage()
        {
            // InitializeComponent();
            // TitleValue();
            BindingContext = this;
        }

        /*public async void TitleValue()
        {
            // page.OnAppearing();
            label1.Text = (await firebaseHelper.GetProgramTitle(1)).ToString();
        }*/

        public event EventHandler ToggleMenu;

        void OnMenuTapped(object sender, System.EventArgs e)
        {
            ToggleMenu?.Invoke(sender, e);
        }
        
        /* public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(
            "Title",        // the name of the bindable property
            typeof(string),     // the bindable property type
            typeof(Entry),   // needs to be 
            string.Empty);
        public string EventName
        {
            get { return (string)GetValue (CardTitleProperty); }
            set { SetValue (CardTitleProperty, value); }
        } */
    }
}