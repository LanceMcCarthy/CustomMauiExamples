using EFCoreDemos.ViewModels;

namespace EFCoreDemos.Views;

public partial class SortingPage : ContentPage
{
    private readonly SortingPageViewModel vm;

	public SortingPage(SortingPageViewModel pageViewModel)
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