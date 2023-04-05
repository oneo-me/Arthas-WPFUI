using System.Globalization;
using System.Windows.Data;

namespace Arthas.Converter;

public class DoubleFactor : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return 0.0;
        if (parameter == null)
            return System.Convert.ToDouble(value);
        return System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return 0.0;
        if (parameter == null)
            return System.Convert.ToDouble(value);
        return System.Convert.ToDouble(value) / System.Convert.ToDouble(parameter);
    }
}
