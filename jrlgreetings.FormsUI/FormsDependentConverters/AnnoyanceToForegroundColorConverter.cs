using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace jrlgreetings.FormsUI.FormsDependentConverters
{
    public class AnnoyanceToForegroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double dValue = System.Convert.ToDouble(value);

            double annoyanceRemovedSq = Math.Pow(100.0 - dValue, 2.0);
            return new Color(.5 - (.00005 * annoyanceRemovedSq));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
