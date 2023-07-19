using System.Collections.ObjectModel;
using System.Diagnostics;
using Telerik.Maui.Controls.Compatibility.Chart;

namespace ScatterWithLegend;

public partial class MainPage : ContentPage
{
    private readonly ObservableCollection<LegendItem> legendItems = new ();
    private readonly List<CartesianSeries> seriesCache = new();
    
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
                SeriesDisplayName = displayName,
                IsSelected = true
            });

            // Important: SETUP the cache now, this maintains the correct index
            seriesCache.Add(series);
        }
    }

    private void CheckBox_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (((CheckBox)sender).BindingContext is not LegendItem legendItem) 
            return;

        // get a reference to the series in the cache that matches the legend item
        var series = seriesCache.FirstOrDefault(s => s.DisplayName == legendItem.SeriesDisplayName);

        // CONDITION 1 - Add the series back to the chart
        if (legendItem.IsSelected && series != null) 
        {
            // look in the cache for the series
            var seriesIndex = seriesCache.IndexOf(series);

            // CheckChanged is going to fire when the initial value is bound, ignore this cycle
            if (chartTest.Series.Contains(series)) 
                return; 

            // add it back to the chart at the correct index
            chartTest.Series.Insert(seriesIndex, series);
            
            // Set the item's color to match the series's palette item
            SyncPaletteColors();
        }
        // CONDITION 2 - Remove the series from the chart
        else if (!legendItem.IsSelected && series != null)
        {
            // remove the series from the chart (the reference is maintained in memory because it is in the cache)
            chartTest.Series.Remove(series);

            // Unset the color so that the palette-assigned color is not out of sync, then update the other checkboxes colors
            legendItem.SeriesColor = Colors.Gray;
            SyncPaletteColors();
        }
        else
        {
            Debug.WriteLine("Executed too early, nothing to see here... move on.");
        }
    }
    
    private void SyncPaletteColors()
    {
        foreach (var chartSeries in chartTest.Series)
        {
            var matchingLegendItem = legendItems.FirstOrDefault(item => item.SeriesDisplayName == chartSeries.DisplayName);

            var seriesIndex = chartTest.Series.IndexOf(chartSeries);

            if (matchingLegendItem != null)
            {
                matchingLegendItem.SeriesColor = chartTest.Palette.Entries[seriesIndex].FillColor;
            }
        }
    }

    
}