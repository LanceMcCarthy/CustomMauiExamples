using LantzControls.DemoModels;

namespace LantzControls.Views;

public partial class AsyncTemplateCellDemoPage : ContentPage
{
	public AsyncTemplateCellDemoPage()
	{
		InitializeComponent();
        
        ListView1.ItemsSource = Enumerable.Range(1, 50).Select(i => new MyLiveDataItem
        {
            CreatedBy = $"Creator {i}",
            Recipient = $"Recipient {i}",
            Status = "Not Done"
        });
    }
}