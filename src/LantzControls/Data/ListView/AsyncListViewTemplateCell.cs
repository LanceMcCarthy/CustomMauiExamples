using LantzControls.DemoModels;
using Telerik.Maui.Controls.Compatibility.DataControls.ListView;

namespace LantzControls.Data.ListView;

public class AsyncListViewTemplateCell : ListViewTemplateCell
{
    protected override async void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        if (this.BindingContext is MyLiveDataItem item)
        {
            item.IsFetchingData = true;

            await GetLongRunningData(item);
            
            item.IsFetchingData = false;
        }
    }

    // DO YOUR LONG RUNNING, NON-BLOCKING WORK OFF THE UI THREAD HERE
    private static async Task GetLongRunningData(MyLiveDataItem item)
    {
        await Task.Delay(1500);

        // Remember to dispatch back to UI thread if you need to update values that are data bound in the UI
        App.Current.MainPage.Dispatcher.Dispatch(() =>
        {
            item.Description = $"Completed at {DateTime.Now:h:mm:ss tt}.";
        });
    }
}