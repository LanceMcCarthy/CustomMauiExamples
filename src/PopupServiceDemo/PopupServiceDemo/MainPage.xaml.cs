using PopupServiceDemo.Views;

namespace PopupServiceDemo;

public partial class MainPage : ContentPage
{
    public MainPage(HomeView view, PopupService service)
    {
        InitializeComponent();
        this.Content = view;
        
        service.AttachParent(this);
    }
}