using System.Windows.Media;

namespace Arthas.Utility.Media;

public class RgbaColor
{
    int _r, _g, _b, _a;

    /// <summary>
    ///     0 - 255
    /// </summary>
    public int R
    {
        get => _r;
        set => _r = value < 0 ? 0 : value > 255 ? 255 : value;
    }

    /// <summary>
    ///     0 - 255
    /// </summary>
    public int G
    {
        get => _g;
        set => _g = value < 0 ? 0 : value > 255 ? 255 : value;
    }

    /// <summary>
    ///     0 - 255
    /// </summary>
    public int B
    {
        get => _b;
        set => _b = value < 0 ? 0 : value > 255 ? 255 : value;
    }

    /// <summary>
    ///     0 - 255
    /// </summary>
    public int A
    {
        get => _a;
        set => _a = value < 0 ? 0 : value > 255 ? 255 : value;
    }

    /// <summary>
    ///     亮度 0 - 100
    /// </summary>
    public int Y => Utility.GetBrightness(R, G, B);

    public RgbaColor()
    {
        R = 255;
        G = 255;
        B = 255;
        A = 255;
    }

    public RgbaColor(int r, int g, int b, int a = 255)
    {
        R = r;
        G = g;
        B = b;
        A = a;
    }

    public RgbaColor(Brush? brush)
    {
        if (brush != null)
        {
            R = ((SolidColorBrush)brush).Color.R;
            G = ((SolidColorBrush)brush).Color.G;
            B = ((SolidColorBrush)brush).Color.B;
            A = ((SolidColorBrush)brush).Color.A;
        }
        else
        {
            R = G = B = A = 255;
        }
    }

    public RgbaColor(double h, double s, double b, double a = 1)
    {
        var rgba = Utility.HsbaToRgba(new(h, s, b, a));
        R = rgba.R;
        G = rgba.G;
        B = rgba.B;
        A = rgba.A;
    }

    public RgbaColor(string hexColor)
    {
        try
        {
            Color color;
            if (hexColor[..1] == "#") color = (Color)ColorConverter.ConvertFromString(hexColor);
            else color = (Color)ColorConverter.ConvertFromString("#" + hexColor);
            R = color.R;
            G = color.G;
            B = color.B;
            A = color.A;
        }
        catch
        {
            // ignored
        }
    }

    public Color Color => Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B);
    public Color OpaqueColor => Color.FromArgb((byte)255.0, (byte)R, (byte)G, (byte)B);
    public SolidColorBrush? SolidColorBrush => new(Color);
    public SolidColorBrush OpaqueSolidColorBrush => new(OpaqueColor);

    public string HexString => Color.ToString();
    public string RgbaString => R + "," + G + "," + B + "," + A;

    public HsbaColor HsbaColor => Utility.RgbaToHsba(this);
}
