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
        return _key switch
        {
            ThemeKey.Primary => new SolidColorBrush(Color.FromRgb(92, 90, 238)),

            ThemeKey.Background  => new(Color.FromRgb(247, 247, 247)),
            ThemeKey.BorderBrush => new(Color.FromArgb((byte)(255 * 0.1), 38, 38, 38)),
            ThemeKey.Foreground  => new(Color.FromRgb(38, 38, 38)),

            ThemeKey.CaptionBackground => new(Color.FromRgb(92, 90, 238)),
            ThemeKey.CaptionForeground => new(Color.FromRgb(255, 255, 255)),

            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
