using Telerik.Maui.Controls;

namespace BlazorHybridWithTelerikXaml;

public partial class App : Application
{
	public App()
    {
		// Workaround to known issue with XamlC
        var _ = new RadPopup();

		InitializeComponent();

		MainPage = new MainPage();
	}
}
