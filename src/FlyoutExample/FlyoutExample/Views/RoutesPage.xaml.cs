using FlyoutExample.ViewModels;

namespace FlyoutExample.Views;

public partial class RoutesPage : ContentPage
{
	public RoutesPage()
	{
		InitializeComponent();
        BindingContext = new RoutesPageViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        (BindingContext as PageViewModel)?.OnPageAppearing();
    }
}