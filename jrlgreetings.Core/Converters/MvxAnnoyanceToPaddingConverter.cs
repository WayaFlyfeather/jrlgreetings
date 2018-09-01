using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace jrlgreetings.Core.Converters
{
    public class MvxAnnoyanceToPaddingConverter : MvxValueConverter<double, Thickness>
    {
        protected override Thickness Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            double offset = value / 5.0;

            byte direction = 0;

            try
            {
                direction = System.Convert.ToByte(parameter);
            }
            catch (Exception) { }

            switch (direction)
            {
                case 1: return new Thickness(0, offset, 0, 0);
                case 2: return new Thickness(0, 0, offset, 0);
                case 3: return new Thickness(0, 0, 0, offset);
                case 0:
                default: return new Thickness(offset, 0, 0, 0);
            }
        }
    }
}
