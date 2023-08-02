using Telerik.Maui.Controls;

namespace PopupServiceDemo;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        this.MainPage = new AppShell();
    }
}