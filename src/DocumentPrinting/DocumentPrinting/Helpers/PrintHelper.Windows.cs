#if WINDOWS
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Printing;
using Microsoft.UI.Xaml;
using System.Globalization;
using Windows.Foundation;
using Windows.Globalization;
using Windows.Graphics.Printing;
using Windows.Storage.Streams;
using Windows.Storage;
using Image = Microsoft.UI.Xaml.Controls.Image;
using VerticalAlignment = Microsoft.UI.Xaml.VerticalAlignment;
using HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment;
using SolidColorBrush = Microsoft.UI.Xaml.Media.SolidColorBrush;
using Color = Windows.UI.Color;
using Thickness = Microsoft.UI.Xaml.Thickness;
using Window = Microsoft.UI.Xaml.Window;

namespace DocumentPrinting.Helpers;

public class PrintHelper
{
    private Window window;
    private nint hWnd;
    internal int pageCount;
    internal Windows.Data.Pdf.PdfDocument pdfDocument;
    private PrintDocument printDocument;
    private IPrintDocumentSource printDocumentSource;
    private string fileName;
    private double marginWidth = 0;
    private double marginHeight = 0;
    private readonly Canvas pdfDocumentPanel = new();
    internal Dictionary<int, UIElement> PrintPreviewPages = new();
    private List<string> imagePaths = new();
    private IRandomAccessStream randomStream;
    private PrintManager printMan;
    private Image imageCtrl = new();
    private PrintTask printTask;

    public async void Print(Stream inputStream, string fName, Microsoft.UI.Xaml.Window nativeWindow)
    {
        this.fileName = fName;

        this.window = nativeWindow;
        hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

        inputStream.Position = 0;
        var ms = new MemoryStream();
        await inputStream.CopyToAsync(ms);
        ms.Position = 0;
        randomStream = await ConvertToRandomAccessStream(ms);
        IAsyncOperation<global::Windows.Data.Pdf.PdfDocument> result = null;
        result = global::Windows.Data.Pdf.PdfDocument.LoadFromStreamAsync(randomStream);

        result.AsTask().Wait();
        pdfDocument = result.GetResults();
        result = null;
        pageCount = (int)pdfDocument.PageCount;
        
        try
        {
            UIDispatcher.Execute(async () =>
            {
                await IncludeCanvas();

                RegisterForPrint();

                await PrintManagerInterop.ShowPrintUIForWindowAsync(hWnd);
            });
        }
        catch
        {
            UIDispatcher.Execute(async () =>
            {
                RegisterForPrint();
                
                await PrintManagerInterop.ShowPrintUIForWindowAsync(hWnd);
            });
        }
    }
    
    public async Task<IRandomAccessStream> ConvertToRandomAccessStream(MemoryStream memoryStream)
    {
        var randomAccessStream = new InMemoryRandomAccessStream();
        var contentStream = new MemoryStream();
        await memoryStream.CopyToAsync(contentStream);
        using var outputStream = randomAccessStream.GetOutputStreamAt(0);
        using var dw = new DataWriter(outputStream);
        var task = new Task(() => dw.WriteBytes(contentStream.ToArray()));
        task.Start();

        await task;
        await dw.StoreAsync();

        await outputStream.FlushAsync();
        await dw.FlushAsync();
        outputStream.Dispose();
        dw.DetachStream();
        dw.Dispose();

        return randomAccessStream;
    }
    
    private void RegisterForPrint()
    {
        printDocument = new PrintDocument();
        printDocumentSource = printDocument.DocumentSource;
        printDocument.Paginate += CreatePrintPreviewPages;
        printDocument.GetPreviewPage += GetPrintPreviewPage;
        printDocument.AddPages += AddPrintPages;
        
        printMan = PrintManagerInterop.GetForWindow(hWnd);
        printMan.PrintTaskRequested += PrintTaskRequested;
    }
    
    private async void AddPrintPages(object sender, AddPagesEventArgs e)
    {
        try
        {
            await PrepareForPrint(0, pageCount);
            var printDoc = (PrintDocument)sender;
            printDoc.AddPagesComplete();
        }
        catch
        {
            var printDoc = (PrintDocument)sender;
            printDoc.InvalidatePreview();
        }
    }
    private async Task<int> PrepareForPrint(int startIndex, int count)
    {
        var tempFolder = ApplicationData.Current.TemporaryFolder;
        var result = await PrepareForPrint(startIndex, count, tempFolder);
        tempFolder = null;
        return result;
    }

    private async Task<int> PrepareForPrint(int p, int count, StorageFolder tempfolder)
    {
        for (var i = p; i < count; i++)
        {
            ApplicationLanguages.PrimaryLanguageOverride = CultureInfo.InvariantCulture.TwoLetterISOLanguageName;
            var pdfPage = pdfDocument.GetPage(uint.Parse(i.ToString()));
            double pdfPagePreferredZoom = pdfPage.PreferredZoom;
            IRandomAccessStream randomStream = new InMemoryRandomAccessStream();
            var pdfPageRenderOptions = new Windows.Data.Pdf.PdfPageRenderOptions();
            var pdfPageSize = pdfPage.Size;
            pdfPageRenderOptions.DestinationHeight = (uint)(pdfPageSize.Height * pdfPagePreferredZoom);
            pdfPageRenderOptions.DestinationWidth = (uint)(pdfPageSize.Width * pdfPagePreferredZoom);
            await pdfPage.RenderToStreamAsync(randomStream, pdfPageRenderOptions);
            imageCtrl = new Image();
            var src = new BitmapImage();
            randomStream.Seek(0);
            src.SetSource(randomStream);
            imageCtrl.Source = src;

            imageCtrl.Height = src.PixelHeight / DeviceDisplay.Current.MainDisplayInfo.Density;
            imageCtrl.Width = src.PixelWidth / DeviceDisplay.Current.MainDisplayInfo.Density;
            randomStream.Dispose();
            pdfPage.Dispose();
            printDocument.AddPage(imageCtrl);
        }
        return 0;
    }

    private void CreatePrintPreviewPages(object sender, PaginateEventArgs e)
    {
        var printingOptions = e.PrintTaskOptions;
        var pageDescription = printingOptions.GetPageDescription((uint)e.CurrentPreviewPageNumber);
        marginWidth = pageDescription.PageSize.Width;
        marginHeight = pageDescription.PageSize.Height;
        AddOnePrintPreviewPage();

        var printDoc = (PrintDocument)sender;
        printDoc.SetPreviewPageCount(pageCount, PreviewPageCountType.Final);
    }

    private void AddOnePrintPreviewPage()
    {
        for (var i = pdfDocumentPanel.Children.Count - 1; i >= 0; i--)
        {
            var print = pdfDocumentPanel.Children[i] as Canvas;
            if (print == null)
                continue;

            print.Width = marginWidth;
            print.Height = marginHeight;
            PrintPreviewPages.Add(i, print);
        }
    }

    private void GetPrintPreviewPage(object sender, GetPreviewPageEventArgs e)
    {
        var printDoc = (PrintDocument)sender;
        pdfDocumentPanel.Children.Remove(PrintPreviewPages[e.PageNumber - 1]);
        printDoc.SetPreviewPage(e.PageNumber, PrintPreviewPages[e.PageNumber - 1]);
    }

    private async Task<int> IncludeCanvas()
    {
        for (var i = 0; i < pageCount; i++)
        {
            var pageIndex = i;
            var pdfPage = pdfDocument.GetPage(uint.Parse(i.ToString()));
            var width = pdfPage.Size.Width;
            var height = pdfPage.Size.Height;
            var page = new Canvas();
            page.Width = width;
            page.Height = height;
            page.VerticalAlignment = VerticalAlignment.Top;
            page.HorizontalAlignment = HorizontalAlignment.Center;

            page.Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            page.Margin = new Thickness(0, 0, 0, 0);

            double pdfPagePreferredZoom = pdfPage.PreferredZoom;
            IRandomAccessStream randomStream = new InMemoryRandomAccessStream();
            var pdfPageRenderOptions = new Windows.Data.Pdf.PdfPageRenderOptions();
            var pdfPageSize = pdfPage.Size;
            pdfPageRenderOptions.DestinationHeight = (uint)(pdfPageSize.Height * pdfPagePreferredZoom);
            pdfPageRenderOptions.DestinationWidth = (uint)(pdfPageSize.Width * pdfPagePreferredZoom);
            await pdfPage.RenderToStreamAsync(randomStream, pdfPageRenderOptions);
            imageCtrl = new Image();
            var src = new BitmapImage();
            randomStream.Seek(0);
            src.SetSource(randomStream);
            imageCtrl.Source = src;
            
            // We can now use the MAUI display info
            imageCtrl.Height = src.PixelHeight / DeviceDisplay.Current.MainDisplayInfo.Density;
            imageCtrl.Width = src.PixelWidth / DeviceDisplay.Current.MainDisplayInfo.Density;
            randomStream.Dispose();
            pdfPage.Dispose();

            page.Children.Add(imageCtrl);
            pdfDocumentPanel.Children.Add(page);
        }
        return 0;
    }

    private void PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs e)
    {
        printTask = e.Request.CreatePrintTask(fileName, sourceRequested => sourceRequested.SetSource(printDocumentSource));
        printTask.Completed += printTask_Completed;
    }
    
    private void printTask_Completed(PrintTask sender, PrintTaskCompletedEventArgs args)
    {
        printTask.Completed -= printTask_Completed;
        printMan.PrintTaskRequested -= PrintTaskRequested;
    }
}

internal class UIDispatcher
{
    //private static CoreDispatcher Dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
    
    internal static void Execute(Action action)
    {
        action.Invoke();

        //if (CoreApplication.MainView.CoreWindow == null
        //    || Dispatcher.HasThreadAccess)
        //    action();
        //else
        //    Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action()).AsTask().Wait();
    }
}

#endif