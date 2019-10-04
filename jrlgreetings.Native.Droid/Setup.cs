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
using jrlgreetings.Core;
using jrlgreetings.Core.Services;
using jrlgreetings.Native.Droid.ServiceImpl;
using MvvmCross;
using MvvmCross.Platforms.Android.Core;

namespace jrlgreetings.Native.Droid
{
    public class Setup : MvxAndroidSetup<CoreApp>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<ISoundPlayerService>(new AndroidSoundPlayerService());
        }
    }
}