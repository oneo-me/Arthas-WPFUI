using System.Windows.Markup;
using System.Windows.Media;

namespace Arthas;

public class ThemeBrushExtension : MarkupExtension
{
    readonly ThemeKey _key;

    public ThemeBrushExtension(ThemeKey key)
    {
        _key = key;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        switch (_key)
        {
            case ThemeKey.Primary:
                return new SolidColorBrush(Color.FromArgb((byte)(2.55 * 100), 84, 135, 238));

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
