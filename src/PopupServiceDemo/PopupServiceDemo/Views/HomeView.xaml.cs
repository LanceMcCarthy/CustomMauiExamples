using PopupServiceDemo.ViewModels;

namespace PopupServiceDemo.Views;

public partial class HomeView : ContentView
{
    public HomeView(HomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}