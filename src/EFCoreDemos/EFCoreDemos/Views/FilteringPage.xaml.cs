using EFCoreDemos.ViewModels;

namespace EFCoreDemos.Views;

public partial class FilteringPage : ContentPage
{
    private readonly FilteringPageViewModel vm;

	public FilteringPage(FilteringPageViewModel pageViewModel)
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