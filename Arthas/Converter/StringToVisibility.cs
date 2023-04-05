using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Arthas.Converter;

public class StringToVisibility : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value == null || value.ToString() == "" ? Visibility.Hidden : Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}
