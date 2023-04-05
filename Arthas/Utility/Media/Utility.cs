namespace Arthas.Utility.Media;

/// <summary>
///     实用工具
/// </summary>
class Utility
{
    /// <summary>
    ///     Rgba转Hsba
    /// </summary>
    /// <param name="rgba"></param>
    /// <returns></returns>
    internal static HsbaColor RgbaToHsba(RgbaColor rgba)
    {
        int[] rgb = { rgba.R, rgba.G, rgba.B };
        Array.Sort(rgb);
        var max = rgb[2];
        var min = rgb[0];

        var hsbB = max / 255.0;
        var hsbS = max == 0 ? 0 : (max - min) / (double)max;
        double hsbH = 0;

        if (rgba.R == rgba.G && rgba.R == rgba.B)
        {
        }
        else
        {
            if (max == rgba.R && rgba.G >= rgba.B) hsbH = (rgba.G - rgba.B) * 60.0 / (max - min) + 0.0;
            else if (max == rgba.R && rgba.G < rgba.B) hsbH = (rgba.G - rgba.B) * 60.0 / (max - min) + 360.0;
            else if (max == rgba.G) hsbH = (rgba.B - rgba.R) * 60.0 / (max - min) + 120.0;
            else if (max == rgba.B) hsbH = (rgba.R - rgba.G) * 60.0 / (max - min) + 240.0;
        }

        return new(hsbH, hsbS, hsbB, rgba.A / 255.0);
    }

    /// <summary>
    ///     Hsba转Rgba
    /// </summary>
    /// <param name="hsba"></param>
    /// <returns></returns>
    internal static RgbaColor HsbaToRgba(HsbaColor hsba)
    {
        double r = 0, g = 0, b = 0;
        var i = (int)(hsba.H / 60 % 6);
        var f = hsba.H / 60 - i;
        var p = hsba.B * (1 - hsba.S);
        var q = hsba.B * (1 - f * hsba.S);
        var t = hsba.B * (1 - (1 - f) * hsba.S);
        switch (i)
        {
            case 0:
                r = hsba.B;
                g = t;
                b = p;
                break;

            case 1:
                r = q;
                g = hsba.B;
                b = p;
                break;

            case 2:
                r = p;
                g = hsba.B;
                b = t;
                break;

            case 3:
                r = p;
                g = q;
                b = hsba.B;
                break;

            case 4:
                r = t;
                g = p;
                b = hsba.B;
                break;

            case 5:
                r = hsba.B;
                g = p;
                b = q;
                break;
        }

        return new((int)(255.0 * r), (int)(255.0 * g), (int)(255.0 * b), (int)(255.0 * hsba.A));
    }

    /// <summary>
    ///     获取颜色亮度
    /// </summary>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    internal static int GetBrightness(int r, int g, int b)
    {
        return (int)((0.2126 * r + 0.7152 * g + 0.0722 * b) / 2.55);
    }
}
