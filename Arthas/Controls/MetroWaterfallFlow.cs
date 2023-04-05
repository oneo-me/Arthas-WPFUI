using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Arthas.Controls;

public class MetroWaterfallFlow : Panel
{
    public static readonly DependencyProperty SizeProperty =
        DependencyProperty.Register(nameof(Size), typeof(double), typeof(MetroWaterfallFlow),
            new FrameworkPropertyMetadata(double.NaN,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault |
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));

    public double Size
    {
        get => (double)GetValue(SizeProperty);
        set => SetValue(SizeProperty, value);
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        return Layout(this, availableSize, true);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        return Layout(this, finalSize, false);
    }

    IEnumerable<UIElement> GetChildren()
    {
        foreach (UIElement child in InternalChildren)
        {
            if (child is Popup)
                continue;

            if (child.Visibility == Visibility.Collapsed)
                continue;

            yield return child;
        }
    }

    double GetValue(double num, double defVal = 0.0)
    {
        return double.IsNaN(num) || double.IsNegativeInfinity(num) || double.IsPositiveInfinity(num) ? defVal : num;
    }

    void ForEach(int column, Action<int, int, UIElement[]> action)
    {
        var elements = GetChildren().ToList();
        var count = elements.Count;

        var items = new List<UIElement>();
        var row = 0;

        for (var i = 0; i < count; i++)
        {
            var child = elements[i];

            items.Add(child);

            if (items.Count != column)
                continue;

            action(count, row++, items.ToArray());
            items.Clear();
        }

        if (items.Count == 0)
            return;

        action(count, ++row, items.ToArray());
        items.Clear();
    }

    double GetSize()
    {
        return GetValue(Size, 100d);
    }

    int GetColumn(double width)
    {
        var size = GetSize();
        var value = GetValue(width);
        var column = value / size;

        return (int)Math.Max(column, 1);
    }

    static Size Layout(MetroWaterfallFlow layout, Size size, bool isMeasure)
    {
        var result = default(Size);

        var column = layout.GetColumn(size.Width);
        var itemSize = layout.GetValue(size.Width / column);

        var bottoms = new Dictionary<int, double>();

        for (var i = 0; i < column; i++)
            bottoms[i] = 0.0;

        layout.ForEach(column, (_, index, items) =>
        {
            for (var i = 0; i < items.Length; i++)
            {
                var child = items[i];

                if (isMeasure)
                    child.Measure(new(itemSize, double.PositiveInfinity));

                var newIndex = i;

                if (index >= column)
                {
                    var current = bottoms[0];
                    newIndex = 0;

                    for (var n = 1; n < bottoms.Count; n++)
                        if (bottoms[n] < current)
                        {
                            current = bottoms[n];
                            newIndex = n;
                        }
                }

                if (!isMeasure)
                    child.Arrange(new(newIndex * itemSize, bottoms[newIndex], itemSize,
                        child.DesiredSize.Height));

                bottoms[newIndex] += child.DesiredSize.Height;
            }
        });

        result.Width = layout.GetValue(size.Width);

        foreach (var bottom in bottoms)
            result.Height = Math.Max(result.Height, bottom.Value);

        return result;
    }
}
