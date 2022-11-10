using DepndInjtnDemo.ViewModels;

namespace DepndInjtnDemo;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
    }
}