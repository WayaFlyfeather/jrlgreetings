using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Converters;

namespace jrlgreetings.Native.Droid.AndroidDependentConverters
{
    public class MvxAnnoyanceToBackgroundColorConverter : MvxValueConverter<double, Color>
    {
        protected override Color Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            double annoyanceRemovedSq = Math.Pow(100.0 - value, 2.0) / 10000;
            byte colorPart = (byte)(128 + (127.0 * annoyanceRemovedSq));

            Color res = new Color(colorPart, colorPart, colorPart);
            return res;
        }
    }

}