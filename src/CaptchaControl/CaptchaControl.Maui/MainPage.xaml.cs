namespace CaptchaControl.Maui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void DrawButton_Clicked(object sender, EventArgs e)
    {
        CaptchaGraphicsView.Invalidate();
    }
}