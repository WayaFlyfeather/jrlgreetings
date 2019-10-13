using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using jrlgreetings.Native.Droid.Views;
using MvvmCross.Platforms.Android.Views;

namespace jrlgreetings.Native.Droid
{
    [Activity(
        Label = "Greetings from JRL (native)"
        , MainLauncher = true
        , Icon = "@mipmap/ic_launcher"
        , Theme = "@style/SplashTheme"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }

        protected override Task RunAppStartAsync(Bundle bundle)
        {
            StartActivity(typeof(EntranceView));
            return Task.CompletedTask;
        }
    }
}