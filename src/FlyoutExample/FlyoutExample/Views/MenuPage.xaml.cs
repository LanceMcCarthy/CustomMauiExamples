using FlyoutExample.ViewModels;

namespace FlyoutExample.Views;

public partial class MenuPage : ContentPage
{
    public ListView MenuListView;

    public MenuPage()
	{
		InitializeComponent();
        BindingContext = new MenuPageViewModel();

        MenuListView = this.MenuItemsListView;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        (BindingContext as PageViewModel)?.OnPageAppearing();
    }

    private void LogoutClicked(object sender, EventArgs e)
    {
        var success = (Application.Current as App)?.AuthService?.LogOut();

        (BindingContext as MenuPageViewModel).IsUserLoggedIn = !success.Value;

        if (success == true)
        {
            (App.Current.MainPage as MyRootPage).ShowLoginState();
        }
    }
}