namespace CustomPdfViewer;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var filePath = Path.Combine(FileSystem.Current.CacheDirectory, "cache.pdf");

        if (File.Exists(filePath))
            File.Delete(filePath);

        using (var stream = await FileSystem.OpenAppPackageFileAsync("designer_samples.pdf"))
        using (var ms = new MemoryStream())
        {
            await stream.CopyToAsync(ms);

            await File.WriteAllBytesAsync(filePath, ms.ToArray());
        }

        WebView1.Source = new UrlWebViewSource()
        {
            Url = filePath
        };
    }
}

