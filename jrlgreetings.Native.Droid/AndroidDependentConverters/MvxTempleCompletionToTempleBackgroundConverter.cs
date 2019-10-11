using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content.Res;
using Android.Views;
using Android.Widget;
using MvvmCross.Converters;

namespace jrlgreetings.Native.Droid.AndroidDependentConverters
{
    public class MvxTempleCompletionToTempleBackgroundConverter : MvxValueConverter<bool, Drawable>
    {
        protected override Drawable Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value
                ? Application.Context.Resources.GetDrawable(Resource.Drawable.tlbr_red_green_gradient, null)
                : new ColorDrawable(new Color(0xd0, 0xd0, 0xd0, 0xff));
        }
    }
}