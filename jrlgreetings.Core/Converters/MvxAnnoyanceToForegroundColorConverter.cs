using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace jrlgreetings.Core.Converters
{
    public class MvxAnnoyanceToForegroundColorConverter : MvxValueConverter<double, Color>
    {
        protected override Color Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            double annoyanceRemovedSq = Math.Pow(100.0 - value, 2.0);
            return new Color(.5 - (.00005 * annoyanceRemovedSq));
        }
    }
}
