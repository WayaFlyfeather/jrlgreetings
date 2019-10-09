using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Converters;
using MvvmCross.UI;

namespace jrlgreetings.Native.Droid.AndroidDependentConverters
{
    public class MvxAnnoyanceToVeilVisibilityConverter : MvxValueConverter<double, ViewStates>
    {
        double[] threshold = new double[] { 5.0, 19.0, 33.0, 47.0, 61.0, 75.0, 89.0 };

        protected override ViewStates Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            byte veilNo = 1;
            try
            {
                veilNo = System.Convert.ToByte(parameter);
            }
            catch (Exception) { }

            if ((double)value < threshold[7 - veilNo])
                return ViewStates.Gone;

            return ViewStates.Visible;
        }
    }
}