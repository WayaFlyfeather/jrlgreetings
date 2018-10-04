using MvvmCross.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jrlgreetings.Core.Converters
{
    public class MvxIfZeroConverter : IMvxValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double)
            {
                return (double)value == 0.0 ? true : false;
            }

            long lval = 0;
            try
            {
                lval = System.Convert.ToInt64(value);
            }
            catch (Exception) { }

            return lval == 0 ? true : false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
