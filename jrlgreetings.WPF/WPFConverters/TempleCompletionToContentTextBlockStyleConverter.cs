using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace jrlgreetings.WPF.WPFConverters
{
    public class TempleCompletionToContentTextBlockStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (System.Convert.ToBoolean(value))
                return App.Current.Resources["TempleCompletedRoomContentTextBlockStyle"];
            else
                return App.Current.Resources["RoomContentTextBlockStyle"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
