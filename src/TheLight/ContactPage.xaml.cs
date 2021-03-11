using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Net.Mail;
using Android.Widget;

namespace TheLight
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentView
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        public event EventHandler ToggleMenu;

        void OnMenuTapped(object sender, System.EventArgs e)
        {
            ToggleMenu?.Invoke(sender, e);
        }

        void ContactSubmit(object sender, System.EventArgs e)
        {
            if (name.Text != null
                && email.Text != null
                && contactMessage.Text != null)
            {
                try
                {
                    
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("90.9thelight@gmail.com");
                    mail.To.Add("cglynch1@liberty.edu");
                    mail.ReplyTo = new MailAddress(email.Text);
                    mail.Subject = name.Text;
                    mail.Body = contactMessage.Text;

                    SmtpServer.Port = 587;
                    SmtpServer.Host = "smtp.gmail.com";
                    SmtpServer.EnableSsl = true;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("90.9thelight@gmail.com", "zpkhpzswzldcfygn");

                    SmtpServer.Send(mail);
                    DependencyService.Get<IMessage>().LongAlert("Thank you for contact us.");
                    //Toast.MakeText(Android.App.Application.Context, "Thank you for contact us.", ToastLength.Long).Show();
                }
                catch (Exception)
                {
                    DependencyService.Get<IMessage>().LongAlert("Error, please try again or call us below.");
                    //Toast.MakeText(Android.App.Application.Context, "Error, please try again or call us below.", ToastLength.Long).Show();
                }

                name.Text = String.Empty;
                email.Text = String.Empty;
                contactMessage.Text = String.Empty;

            }
            else
            {
                DependencyService.Get<IMessage>().LongAlert("Error, please complete all required fields.");
                //Toast.MakeText(Android.App.Application.Context, "Error, please complete all fields.", ToastLength.Long).Show();
            }

            //IFirebaseAnalyticsService service = DependencyService.Get<IFirebaseAnalyticsService>(); 
            //service?.LogEvent("contactSubmission");
        }

        private void Call_Office(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("tel://4345927791"));
        }

        private void Call_Studio(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("tel://4345822909"));
        }
    }
    }
