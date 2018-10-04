using MvvmCross.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace jrlgreetings.Core.Converters
{
    public class MvxAnnoyanceToRotationConverter : MvxValueConverter<double, double>
    {
        protected override double Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Device.RuntimePlatform == Device.Android)
                return 1.6 * value;
            else
                return 1.0 * value;
        }
    }
}
