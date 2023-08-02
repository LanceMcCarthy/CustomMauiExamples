namespace PopupServiceDemo.ViewModels;

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
        
        popupService.OpenPopup(popupContent);
    }

    private void ClosePopup()
    {
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
