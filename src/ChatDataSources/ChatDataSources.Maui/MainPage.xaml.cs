using ChatDataSources.Maui.ViewModels;

namespace ChatDataSources.Maui;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel vm;

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = vm = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.Initialize();
    }
}