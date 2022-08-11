using Microsoft.UI.Xaml;

namespace RealtimeDataSystem.Maui.WinUI;

public partial class App : MauiWinUIApplication
{
	public App()
	{
		this.InitializeComponent();
        RequestedTheme = ApplicationTheme.Light;
    }

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

