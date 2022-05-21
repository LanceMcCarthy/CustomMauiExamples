using FlyoutExample.Models;
using FlyoutExample.Views;
using System.Collections.ObjectModel;

namespace FlyoutExample.ViewModels;

public class MenuPageViewModel : PageViewModel
{
    private bool isUserLoggedIn;

    public MenuPageViewModel()
    {
        MenuItems = new ObservableCollection<MyMenuItem>
        {
            new() { Id = 0, Title = "Dashboard", TargetType = typeof(DashboardPage), IconPath = "dashboard_icon.png"},
            new() { Id = 1, Title = "Routes", TargetType = typeof(RoutesPage), IconPath = "routes_icon.png" },
            new() { Id = 2, Title = "Settings", TargetType = typeof(SettingsPage), IconPath = "settings_icon.png" }
        };
    }

    public ObservableCollection<MyMenuItem> MenuItems { get; set; }

    public bool IsUserLoggedIn
    {
        get => isUserLoggedIn;
        set => SetProperty(ref isUserLoggedIn, value);
    }

    public override void OnPageAppearing()
    {
    }
}
