using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Platforms.Android.Views;
using Xamarin.Forms;

namespace jrlgreetings.Droid
{
    [Activity(
        Label = "jrlgreetings.Droid"
        , MainLauncher = true
        , Icon = "@mipmap/ic_launcher"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxFormsSplashScreenActivity<Setup, jrlgreetings.Core.CoreApp, jrlgreetings.Core.Application>
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }

        protected override void RunAppStart(Bundle bundle)
        {
            System.Diagnostics.Debug.WriteLine("In Run App Start");
//            if (!Forms.IsInitialized)
//            {
////                Forms.SetFlags("FastRenderers_Experimental");
//                Forms.Init(this, bundle);
//            }

            System.Diagnostics.Debug.WriteLine("In Run App Start");
            StartActivity(typeof(MainActivity));
            System.Diagnostics.Debug.WriteLine("Started activty");
            base.RunAppStart(bundle);
        }

        //protected override void OnCreate(Android.OS.Bundle bundle)
        //{
        //    Forms.Init(this, bundle);
        //    // Leverage controls' StyleId attrib. to Xamarin.UITest
        //    Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) =>
        //    {
        //        if (!string.IsNullOrWhiteSpace(e.View.StyleId))
        //        {
        //            e.NativeView.ContentDescription = e.View.StyleId;
        //        }
        //    };

        //    base.OnCreate(bundle);
        //}
    }
}
