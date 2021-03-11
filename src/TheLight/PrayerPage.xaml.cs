using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Net.Mail;
using Android.Widget;
/*using System.Net;
using Android.Widget;
using Android.Media;
using Android.App;
using Android.OS;
using Android.Content;*/

namespace TheLight
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrayerPage : ContentView
    {
        public PrayerPage()
        {
            InitializeComponent();
        }

        public event EventHandler ToggleMenu;

        void OnMenuTapped(object sender, System.EventArgs e)
        {
            ToggleMenu?.Invoke(sender, e);
        }

        void PrayerSubmit(object sender, System.EventArgs e)
        {
            if (prayerMessage.Text != null)
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("90.9thelight@gmail.com");
                    mail.To.Add("cglynch1@liberty.edu");
                    if (email.Text != null)
                    {
                        mail.ReplyTo = new MailAddress(email.Text);
                        mail.Subject = "New prayer request from " + name.Text;
                    } else
                    {
                        mail.ReplyTo = new MailAddress("90.9@liberty.edu");
                        mail.Subject = "New prayer request with NoReply";
                    }
                    
                    mail.Subject = name.Text;
                    mail.Body = prayerMessage.Text;

                    SmtpServer.Port = 587;
                    SmtpServer.Host = "smtp.gmail.com";
                    SmtpServer.EnableSsl = true;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("90.9thelight@gmail.com", "zpkhpzswzldcfygn");

                    SmtpServer.Send(mail);
                }
                catch (Exception)
                {
                    DependencyService.Get<IMessage>().LongAlert("Error, please try again.");
                    //Toast.MakeText(Android.App.Application.Context, "Error, please try again.", ToastLength.Long).Show();
                }

                name.Text = String.Empty;
                email.Text = String.Empty;
                prayerMessage.Text = String.Empty;

            }
            else
            {
                DependencyService.Get<IMessage>().LongAlert("Error, please complete all required fields.");
                //Toast.MakeText(Android.App.Application.Context, "Error, please complete all required fields.", ToastLength.Long).Show();
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
