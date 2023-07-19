using CommonHelpers.Common;

namespace ScatterWithLegend;

public class LegendItem : BindableBase
{
    private bool isSelected = true;
    private string seriesDisplayName;
    private Color seriesColor;
    
    public Color SeriesColor
    {
        get => seriesColor;
        set => SetProperty(ref seriesColor, value);
    }

    public string SeriesDisplayName
    {
        get => seriesDisplayName;
        set => SetProperty(ref seriesDisplayName, value);
    }

    public bool IsSelected
    {
        get => isSelected;
        set => SetProperty(ref isSelected, value);
    }
}