using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Arthas;

public static class Resource
{
    public static BitmapImage? AsBitmapImage(Uri uri)
    {
        using var stream = AsStream(uri);

        return Stream2BitmapImage(stream);
    }

    public static BitmapImage? AsBitmapImage(string path, Assembly? assembly = null)
    {
        var callingAssembly = assembly ?? Assembly.GetCallingAssembly();

        return AsBitmapImage(AsUri(path, callingAssembly));
    }

    public static Stream? AsStream(Uri uri)
    {
        return Application.GetResourceStream(uri)?.Stream;
    }

    public static Stream? AsStream(string path, Assembly? assembly = null)
    {
        var callingAssembly = assembly ?? Assembly.GetCallingAssembly();

        return AsStream(AsUri(path, callingAssembly));
    }

    public static Uri AsUri(string path, Assembly? assembly = null)
    {
        var callingAssembly = assembly ?? Assembly.GetCallingAssembly();

        return new($"pack://application:,,,/{callingAssembly.GetName().Name};component/{path}");
    }

    static BitmapImage? Stream2BitmapImage(Stream? stream)
    {
        if (stream is null)
            return null;

        var bitmapImage = new BitmapImage
        {
            CacheOption = BitmapCacheOption.OnLoad
        };

        bitmapImage.BeginInit();
        bitmapImage.StreamSource = stream;
        bitmapImage.EndInit();
        bitmapImage.Freeze();

        return bitmapImage;
    }
}
