using CommonHelpers.Collections;
using CommonHelpers.Models;
using CommonHelpers.Services;

namespace ScatterWithLegend;

public class MainPageViewModel
{
    public MainPageViewModel()
    {
        Data1.AddRange(SampleDataService.Current.GenerateScatterPointData(15));
        Data2.AddRange(SampleDataService.Current.GenerateScatterPointData(15));
    }
    
    public ObservableRangeCollection<ChartDataPoint> Data1 { get; set; } = new();

    public ObservableRangeCollection<ChartDataPoint> Data2 { get; set; } = new();
}