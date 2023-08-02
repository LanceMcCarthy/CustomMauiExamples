# Popup Service Demo

This example uses .NET MAUI's new DependencyInjection system to register a popup service that can be used anywhere is the app.

```csharp
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseTelerik()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<HomeView>();

         // ***** IMPORTANT ***** //
        // PopupService registration
        builder.Services.AddSingleton<PopupService>();

        return builder.Build();
    }
}
```

The key takeaway is the PlacementTarget root is attached to the root view once that root page is ready:

```csharp
public partial class MainPage : ContentPage
{
    public MainPage(HomeView view, PopupService service)
    {
        InitializeComponent();
        this.Content = view;
        
        // ***** IMPORTANT ***** //
        // The popup services uses this root as the target placement for the popup
        service.AttachParent(this);
    }
}
```

Now, anywhere the Popupservice is available, the popup can be invoked with whatever content you want:

```csharp
public class HomeViewModel
{
    private readonly PopupService popupService;

    public HomeViewModel(PopupService service)
    {
        this.popupService = service;
        
        OpenPopupCommand = new Command(OpenPopup);
        ClosePopupCommand = new Command(ClosePopup);
    }

    public Command OpenPopupCommand { get; set; }

    public Command ClosePopupCommand { get; set; }

    private void OpenPopup()
    {
        var popupContent = CreatePopupContent();
        
        // ***** IMPORTANT ***** //
        // Open the popup
        popupService.OpenPopup(popupContent);
    }

    private void ClosePopup()
    {
        // ***** IMPORTANT ***** //
        // Close the popup
        popupService.ClosePopup();
    }

    private View CreatePopupContent()
    {
        var stackLayout = new VerticalStackLayout
        {
            Spacing = 10,
            Padding = 10, 
            HorizontalOptions = LayoutOptions.Center, 
            VerticalOptions = LayoutOptions.Center, 
            BackgroundColor = Colors.Wheat
        };

        var lbl = new Label
        {
            Text = "This is a popup.", 
            HorizontalOptions = LayoutOptions.Center
        };
        stackLayout.Children.Add(lbl);

        var btn1 = new Button { Text = "close via command", Command = this.ClosePopupCommand };
        stackLayout.Children.Add(btn1);

        var btn2 = new Button { Text = "close via click" };
        btn2.Clicked += (s,e) => popupService.ClosePopup();
        stackLayout.Children.Add(btn2);

        return stackLayout;
    }
}
```