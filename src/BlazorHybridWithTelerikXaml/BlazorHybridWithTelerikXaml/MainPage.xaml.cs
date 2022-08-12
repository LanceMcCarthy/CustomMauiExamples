namespace BlazorHybridWithTelerikXaml;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    public Task ShowTelerikMauiPopup()
    {
        popup.IsOpen = true;

        return Task.CompletedTask;
    }
    
    public void ClosePopup(object sender, EventArgs e)
    {
        popup.IsOpen = false;
    }
}
