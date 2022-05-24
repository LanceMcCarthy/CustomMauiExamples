using FlyoutExample.Controls;
using Telerik.Maui.Controls;

namespace FlyoutExample.Views;

public partial class DashboardPage : ContentPage
{
    private Random rand = new ();

	public DashboardPage()
	{
		InitializeComponent();
	}

    private async void AddTabButton_Clicked(object sender, EventArgs e)
    {
        var pilot = await (Application.Current as App).RouteService.GetPilot(rand.Next(0,43));

        var content = new PilotDetails
        {
            BindingContext = pilot
        };
        
        var tvi = new TabViewItem
        {
            HeaderText = pilot.Name,
            Content = content
        };

        TabView1.Items.Add(tvi);
        
        TabView1.SelectedItem = tvi;
    }

    private void RemoveTabButton_Clicked(object sender, EventArgs e)
    {
        TabView1.Items.RemoveAt(0);
    }
}

