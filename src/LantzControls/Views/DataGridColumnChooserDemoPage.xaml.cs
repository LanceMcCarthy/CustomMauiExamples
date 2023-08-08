using CommonHelpers.Services;

namespace LantzControls.Views;

public partial class DataGridColumnChooserDemoPage : ContentPage
{
	public DataGridColumnChooserDemoPage()
	{
		InitializeComponent();
        MyDataGrid.ItemsSource = SampleDataService.Current.GeneratePeopleData(true);
	}
}