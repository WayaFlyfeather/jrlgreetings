using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace jrlgreetings.WPF.WPFConverters
{
    public class AnnoyanceToTranslationYConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double offset = System.Convert.ToDouble(value) / 5.0;

            byte direction = 0;

            try
            {
                direction = System.Convert.ToByte(parameter);
            }
            catch (Exception) { }

            switch (direction)
            {
                case 1: return +offset;
                case 2: return -offset;
                case 3: return +offset;
                case 0:
                default: return -offset;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
