using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Converters;

namespace jrlgreetings.Native.Droid.AndroidDependentConverters
{
    public class MvxCompletionToTeleportBackgroundConverter : MvxValueConverter<bool, ColorDrawable>
    {
        protected override ColorDrawable Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value
                ? new ColorDrawable(new Color(0x7f, 0xff, 0xd4, 0xff))
                : new ColorDrawable(new Color(0x30, 0x30, 0x30, 0x40));
        }
    }
}