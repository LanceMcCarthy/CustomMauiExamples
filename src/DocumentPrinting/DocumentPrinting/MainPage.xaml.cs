
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
        var stream = await FileSystem.OpenAppPackageFileAsync("pdfviewer-overview.pdf");

        var helper = new PrintHelper();

#if WINDOWS
        
        helper.Print(stream, "pdfviewer-overview.pdf", this.Window.Handler.PlatformView as Microsoft.UI.Xaml.Window);

#elif __IOS__ || MACCATALYST || ANDROID

		helper.Print(stream, "pdfviewer-overview.pdf");
#endif
    }
	
}

