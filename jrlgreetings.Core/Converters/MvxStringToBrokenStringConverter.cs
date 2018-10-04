using MvvmCross.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace jrlgreetings.Core.Pages
{
    public class MvxStringToBrokenStringConverter : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            byte direction = 0;
            try
            {
                direction = System.Convert.ToByte(parameter);
            }
            catch (Exception) { }

            StringBuilder sb = new StringBuilder();

            int idx = 0;
            foreach (char c in value)
            {
                sb.Append(idx++ % 4 == direction || Char.IsWhiteSpace(c) ? c : '_');
            }
            return sb.ToString();
        }
    }
}
