using System.Collections.ObjectModel;

namespace ScatterWithLegend;

public partial class MainPage : ContentPage
{
    private readonly ObservableCollection<LegendItem> legendItems = new ();

    public MainPage()
    {
        InitializeComponent();
        this.LegendItemsControl.ItemsSource = legendItems;
    }

    private void ChartTest_OnLoaded(object sender, EventArgs e)
    {
        foreach (var series in chartTest.Series)
        {
            // Get the DisplayName value
            var displayName = series.DisplayName;

            // Get the color
            // Note: you need to get this color from the custom chart palette using the series index
            var seriesIndex = chartTest.Series.IndexOf(series);
            var paletteColor = chartTest.Palette.Entries[seriesIndex].FillColor;

            // Finally, add the custom legend item
            this.legendItems.Add(new LegendItem
            {
                SeriesColor = paletteColor,
                SeriesDisplayName = displayName
            });
        }
    }
}