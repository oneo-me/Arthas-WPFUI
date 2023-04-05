using System.Windows.Media;

namespace Arthas.Utility.Media;

public class HsbaColor
{
    double _h, _s, _b, _a;

    /// <summary>
    ///     0 - 359，360 = 0
    /// </summary>
    public double H
    {
        get => _h;
        set => _h = value < 0 ? 0 : value >= 360 ? 0 : value;
    }

    /// <summary>
    ///     0 - 1
    /// </summary>
    public double S
    {
        get => _s;
        set => _s = value < 0 ? 0 : value > 1 ? 1 : value;
    }

    /// <summary>
    ///     0 - 1
    /// </summary>
    public double B
    {
        get => _b;
        set => _b = value < 0 ? 0 : value > 1 ? 1 : value;
    }

    /// <summary>
    ///     0 - 1
    /// </summary>
    public double A
    {
        get => _a;
        set => _a = value < 0 ? 0 : value > 1 ? 1 : value;
    }

    /// <summary>
    ///     亮度 0 - 100
    /// </summary>
    public int Y => RgbaColor.Y;

    public HsbaColor()
    {
        H = 0;
        S = 0;
        B = 1;
        A = 1;
    }

    public HsbaColor(double h, double s, double b, double a = 1)
    {
        H = h;
        S = s;
        B = b;
        A = a;
    }

    public HsbaColor(int r, int g, int b, int a = 255)
    {
        var hsba = Utility.RgbaToHsba(new(r, g, b, a));
        H = hsba.H;
        S = hsba.S;
        B = hsba.B;
        A = hsba.A;
    }

    public HsbaColor(Brush? brush)
    {
        var hsba = Utility.RgbaToHsba(new(brush));
        H = hsba.H;
        S = hsba.S;
        B = hsba.B;
        A = hsba.A;
    }

    public HsbaColor(string hexColor)
    {
        var hsba = Utility.RgbaToHsba(new(hexColor));
        H = hsba.H;
        S = hsba.S;
        B = hsba.B;
        A = hsba.A;
    }

    public Color Color => RgbaColor.Color;
    public Color OpaqueColor => RgbaColor.OpaqueColor;
    public SolidColorBrush? SolidColorBrush => RgbaColor.SolidColorBrush;
    public SolidColorBrush OpaqueSolidColorBrush => RgbaColor.OpaqueSolidColorBrush;

    public string HexString => Color.ToString();
    public string RgbaString => RgbaColor.RgbaString;

    public RgbaColor RgbaColor => Utility.HsbaToRgba(this);
}
