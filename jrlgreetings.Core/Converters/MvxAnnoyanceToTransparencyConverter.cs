using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jrlgreetings.Core.Converters
{
    public class MvxAnnoyanceToTransparencyConverter : MvxValueConverter<double,double>
    {
        protected override double Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            return (100.0 - value) / 100.0;
        }
    }
}
