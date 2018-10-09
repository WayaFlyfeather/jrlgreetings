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
    public class ZeroToVisibilityConverter : IValueConverter
    {
        public bool Reversed { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double dValue = System.Convert.ToDouble(value);
            if (Reversed)
                return dValue == 0.0 ? Visibility.Collapsed : Visibility.Visible;
            else
                return dValue != 0.0 ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
