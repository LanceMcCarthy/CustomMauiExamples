using FlyoutExample.ViewModels;

namespace FlyoutExample.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void LoginClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(UsernameEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
        {
            this.DisplayAlert("Incomplete", "You must enter a value for both username and password.", "ok");
            return;
        }
        
        var success = (Application.Current as App)?.AuthService?.LogIntoSomeApiWithCredentials(UsernameEntry.Text, PasswordEntry.Text);

        ((App.Current.MainPage as MyRootPage).Flyout.BindingContext as MenuPageViewModel).IsUserLoggedIn = success.Value;
        
        if (success == true)
        {
            (App.Current.MainPage as MyRootPage).ShowNormalState();
        }
        else
        {
            this.DisplayAlert("Access Denied", "that was not the correct username and password. try again.", "ok");
        }
    }
}