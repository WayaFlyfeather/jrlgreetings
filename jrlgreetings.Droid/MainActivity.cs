using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmCross.Forms.Presenters;
using MvvmCross.Platforms.Android.Presenters;
using Xamarin.Forms;

namespace jrlgreetings.Droid
{
    [Activity(Label = "MainActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : MvxFormsAppCompatActivity 
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;
            base.OnCreate(bundle);
        }
    }
}


