using Telerik.Maui.Controls;

namespace RealtimeDataSystem.Maui;

public partial class App : Application
{
	public App()
    {
        object _;
        _ = new RadComboBox();
        _ = new RadEntry();
        _ = new RadNumericInput();
        _ = new RadButton();

        InitializeComponent();

		MainPage = new AppShell();
	}
}
