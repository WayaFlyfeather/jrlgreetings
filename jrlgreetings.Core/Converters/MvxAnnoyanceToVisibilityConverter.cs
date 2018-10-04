using MvvmCross.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jrlgreetings.Core.Converters
{
    public class MvxAnnoyanceToVisibilityConverter : MvxValueConverter<double, bool>
    {
        double[] threshold = new double[] { 5.0, 19.0, 33.0, 47.0, 61.0, 75.0, 89.0 };

        protected override bool Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            byte veilNo = 1;
            try
            {
                veilNo = System.Convert.ToByte(parameter);
            }
            catch (Exception) { }

            if (value < threshold[7 - veilNo])
                return false;

            return true;
        }
    }
}
