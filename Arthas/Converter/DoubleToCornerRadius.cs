using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Arthas.Converter;

public class DoubleToCornerRadius : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (parameter != null)
            return new CornerRadius((double)value / System.Convert.ToDouble(parameter));
        return new CornerRadius((double)value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (parameter != null)
            return ((CornerRadius)value).TopLeft * System.Convert.ToDouble(parameter);
        return ((CornerRadius)value).TopLeft;
    }
}
