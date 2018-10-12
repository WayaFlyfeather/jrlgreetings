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
            //bool pTempleCompleted = System.Convert.ToBoolean(parameter);

            double dValue = System.Convert.ToDouble(value);

            //if (pTempleCompleted && dValue < 0.15)
            //    return App.Current.Resources["TempleCompletedContentTextBackgroundColor"];

            double annoyanceRemovedSq = Math.Pow(100.0 - dValue, 2.0);
            float colorParts = (float)(.5 + (.00005 * annoyanceRemovedSq));
            float transparencyPart = (float)(1.0 - (.0001 * annoyanceRemovedSq));
            Color color = Color.FromScRgb(Math.Max(transparencyPart, .25f), colorParts, colorParts, colorParts);

            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
