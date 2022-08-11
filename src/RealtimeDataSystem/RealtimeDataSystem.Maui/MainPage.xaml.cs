using RealtimeDataSystem.Maui.ViewModels;

namespace RealtimeDataSystem.Maui;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        (BindingContext as MainPageViewModel).ConnectToGrpcServices();
    }
}

