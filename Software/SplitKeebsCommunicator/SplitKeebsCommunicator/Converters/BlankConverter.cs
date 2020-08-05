using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SplitKeebsCommunicator.Converters
{
    [Localizability(LocalizationCategory.NeverLocalize)]
    public sealed class BlankConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bValue = false;
            if (value is bool b)
            {
                bValue = b;
            }

            return (bValue) ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                return visibility == Visibility.Visible;
            }

            return false;
        }
    }
}
