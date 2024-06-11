using EFCoreDemos.ViewModels;

namespace EFCoreDemos.Views;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel vm;

    public MainPage(MainPageViewModel pageViewModel)
    {
        InitializeComponent();
        BindingContext = vm = pageViewModel;
    }

    protected override async void OnAppearing()
    {
        await vm.OnAppearing();

        base.OnAppearing();
    }
}