using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace jrlgreetings.WPF.WPFConverters
{
    public class AnnoyanceToBackgroundBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double dValue = System.Convert.ToDouble(value);
            double annoyanceRemovedSq = Math.Pow(100.0 - dValue, 2.0);
            float colorParts = (float)(.5 + (.00005 * annoyanceRemovedSq));
            Color color = Color.FromScRgb(1.0f, colorParts, colorParts, colorParts);

            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
