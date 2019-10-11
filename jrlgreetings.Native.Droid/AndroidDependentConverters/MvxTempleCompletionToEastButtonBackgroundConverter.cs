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
    public class MvxTempleCompletionToEastButtonBackgroundConverter : MvxValueConverter<bool, Drawable>
    {
        protected override Drawable Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value
                ? Application.Context.Resources.GetDrawable(Resource.Drawable.tb_blue_green_gradient, null)
                : new ColorDrawable(new Color(0x30, 0x30, 0x30, 0x40));
        }
    }
}