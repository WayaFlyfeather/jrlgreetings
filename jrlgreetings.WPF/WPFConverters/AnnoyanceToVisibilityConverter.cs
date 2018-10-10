using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace jrlgreetings.WPF.WPFConverters
{
    public class AnnoyanceToVisibilityConverter : IValueConverter
    {
        double[] threshold = new double[] { 5.0, 19.0, 33.0, 47.0, 61.0, 75.0, 89.0 };
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double dValue = System.Convert.ToDouble(value);
            byte veilNo = 1;
            try
            {
                veilNo = System.Convert.ToByte(parameter);
            }
            catch (Exception) { }

            if (dValue < threshold[7 - veilNo])
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
