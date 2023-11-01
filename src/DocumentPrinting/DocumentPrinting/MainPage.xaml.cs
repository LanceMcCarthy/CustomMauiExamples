
using DocumentPrinting.Helpers;

namespace DocumentPrinting;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void PrintPdf_OnClicked(object sender, EventArgs e)
    {
        (sender as Button).IsEnabled = false;

        var fileName = "pdfviewer-overview.pdf";
        var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
        var helper = new PrintHelper();

#if WINDOWS
        helper.Print(stream, fileName, this.Window.Handler.PlatformView as Microsoft.UI.Xaml.Window);

#elif ANDROID
		await helper.PrintAsync(stream, fileName);

#elif __IOS__ || MACCATALYST
		helper.Print(stream, fileName);

#endif

        (sender as Button).IsEnabled = true;
    }
	
}

