using EFCoreDemos.ViewModels;

namespace EFCoreDemos;

public partial class MainPage : ContentPage
{
    private MainViewModel vm;

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = vm = viewModel;
    }

    protected override async void OnAppearing()
    {
        await vm.OnAppearing();

        base.OnAppearing();
    }
}