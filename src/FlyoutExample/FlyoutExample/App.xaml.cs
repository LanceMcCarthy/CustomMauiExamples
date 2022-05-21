using FlyoutExample.Services;
using FlyoutExample.Views;

namespace FlyoutExample;

public partial class App : Application
{
    // Note: This would normally be setup as middleware and use DependencyInjection
    public AuthenticationService AuthService { get; } = new ();
    public RouteDataService RouteService { get; } = new();

	public App()
    {
		InitializeComponent();
        MainPage = new MyRootPage();
	}

    protected override async void OnStart()
    {
        base.OnStart();
    }
}
