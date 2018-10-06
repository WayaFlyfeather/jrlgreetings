using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace jrlgreetings.FormsUI.FormsDependentConverters
{
    public class TempleCompletionToContentLabelStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Application.Current.Resources["ColorfulRoomContentLabelStyle"] : Application.Current.Resources["RoomContentLabelStyle"];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
