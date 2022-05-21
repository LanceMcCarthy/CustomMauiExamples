using FlyoutExample.Models;

namespace FlyoutExample.Views;

public partial class MyRootPage : Microsoft.Maui.Controls.FlyoutPage
{
    public MyRootPage()
	{
		InitializeComponent();
        MyMenuPage.MenuListView.ItemSelected += ListView_ItemSelected;

        // Keep the menu flyout hidden until we know if the user is logged in or not
        IsPresented = false;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // You can first check if there are any stored credentials that you can use
        var isUserStillLoggedIn = LoginUserFromStoredAccessToken();

        if (isUserStillLoggedIn)
        {
            ShowNormalState();
        }
        else
        {
            ShowLoginState();
        }
    }

    public void ShowLoginState()
    {
        // replace the Detail with LoginPage
        this.Detail = new LoginPage();

        // hide the menu flyout (this seems to be a bug in MAUI right now, you cant change the value)
        // this.IsPresented = false;

    }

    public void ShowNormalState()
    {
        // replace the Detail with a new NavigationPage that has DashboardPage as its first page
        this.Detail = new NavigationPage(new DashboardPage());

        NavigationPage.SetHasBackButton(Detail, true); // this is handy if you want to be able to drill down into more pages from the DashBoardPage

        MyMenuPage.MenuListView.SelectedItem = null;

        // show the menu flyout (this seems to be a bug in MAUI right now, you cant change the value)
        //this.IsPresented = true;
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is MyMenuItem item)
        {
            var page = (Page)Activator.CreateInstance(item.TargetType);

            if (page != null)
            {
                this.Detail = new NavigationPage(page);

                NavigationPage.SetHasBackButton(Detail, true);


                MyMenuPage.MenuListView.SelectedItem = null;
            }
        }
    }

    private bool LoginUserFromStoredAccessToken()
    {
        // You can first check

        if (Preferences.ContainsKey("UserToken"))
        {
            var userToken = Preferences.Get("UserAccessToken", null);
            
            var success = (Application.Current as App)?.AuthService?.LogIntoSomeApiWithRefreshToken(userToken);

            if (success == true)
            {
                return true;
            }
        }

        // If there are no stored credentials, force a login
        return false;
    }
}