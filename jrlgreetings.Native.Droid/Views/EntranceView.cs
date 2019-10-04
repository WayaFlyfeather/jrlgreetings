using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using jrlgreetings.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace jrlgreetings.Native.Droid.Views
{
    [Activity(Label = "Temple Entrance", MainLauncher = true)]
    public class EntranceView : MvxActivity<EntranceViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.EntranceView);
        }
    }
}