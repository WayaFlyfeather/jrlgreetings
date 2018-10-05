using MvvmCross.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jrlgreetings.Core.Converters
{
    public class MvxAnnoyanceToTranslationYConverter : MvxValueConverter<double, double>
    {
        protected override Double Convert(double value, Type targetType, object parameter, CultureInfo culture)
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
                case 1: return offset;
                case 2: return -offset;
                case 3: return offset;
                case 0:
                default: return -offset;
            }
        }
    }
}
