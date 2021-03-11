using Android.App;
using Android.Widget;
using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using TheLight.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
namespace TheLight.Droid
{
    public class MessageAndroid : IMessage
    {
        public IDictionary Properties => throw new NotImplementedException();

        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}