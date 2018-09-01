using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace jrlgreetings.Core.Converters
{
    public class MvxCompletionToButtonBackgroundColorConverter : MvxValueConverter<bool, Color>
    {
        protected override Color Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value)
                return Color.Aquamarine;
            else
                return Color.Gray;
        }
    }
}
