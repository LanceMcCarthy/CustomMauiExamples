#if WINDOWS
using System.Diagnostics;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Printing;
using Microsoft.UI.Xaml;
using System.Globalization;
using Windows.Data.Pdf;
using Windows.Globalization;
using Windows.Graphics.Printing;
using Windows.Storage.Streams;
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
    private readonly Dictionary<int, UIElement> printPreviewPages = new();
    private readonly Canvas pdfDocumentPanel = new();
    private PrintManager printMan;
    private PrintTask printTask;
    private PdfDocument sourcePdfDocument;
    private PrintDocument printDocument;
    private IPrintDocumentSource printDocumentSource;
    private Window window;
    private string fileName;
    private double marginWidth;
    private double marginHeight;
    private int pageCount;
    private nint hWnd;

    public async void Print(Stream inputStream, string fName, Window nativeWindow)
    {
        this.fileName = fName;
        this.window = nativeWindow;
        this.hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

        inputStream.Position = 0;

        using var ms = new MemoryStream();
        await inputStream.CopyToAsync(ms);
        ms.Position = 0;

        var ras = await ConvertToRandomAccessStream(ms);

        this.sourcePdfDocument = await PdfDocument.LoadFromStreamAsync(ras);

        this.pageCount = (int)this.sourcePdfDocument.PageCount;

        // If we have UI thread access, we will use a Canvas
        // If there is no UI thread access, and exception will be thrown and we instead print without a canvas
        try
        {
            
            await PrintWithCanvas();
        }
        catch
        {
            Debug.WriteLine("No UI thread available, printing without Canvas.");

            await PrintWithoutCanvas();
        }
    }

    private async Task PrintWithCanvas()
    {
        await this.IncludeCanvas();

        this.RegisterForPrint();

        await PrintManagerInterop.ShowPrintUIForWindowAsync(hWnd);
    }

    private async Task PrintWithoutCanvas()
    {
        this.RegisterForPrint();

        await PrintManagerInterop.ShowPrintUIForWindowAsync(hWnd);
    }
    
    private void RegisterForPrint()
    {
        printDocument = new PrintDocument();
        printDocumentSource = printDocument.DocumentSource;
        printDocument.Paginate += PrintDoc_Paginate;
        printDocument.GetPreviewPage += PrintDoc_GetPreviewPage;
        printDocument.AddPages += AddPrintPages;
        
        printMan = PrintManagerInterop.GetForWindow(hWnd);
        printMan.PrintTaskRequested += PrintTask_Requested;
    }
    
    private async void AddPrintPages(object sender, AddPagesEventArgs e)
    {
        try
        {
            await this.PrepareForPrint(0, pageCount);

            ((PrintDocument)sender).AddPagesComplete();
        }
        catch
        {
            ((PrintDocument)sender).InvalidatePreview();
        }
    }

    private async Task PrepareForPrint(int p, int count)
    {
        for (var i = p; i < count; i++)
        {
            ApplicationLanguages.PrimaryLanguageOverride = CultureInfo.InvariantCulture.TwoLetterISOLanguageName;

            using var pdfPage = this.sourcePdfDocument.GetPage(uint.Parse(i.ToString()));

            using var ras = new InMemoryRandomAccessStream();

            await pdfPage.RenderToStreamAsync(ras, new PdfPageRenderOptions
            {
                DestinationWidth = (uint)(pdfPage.Size.Width * pdfPage.PreferredZoom),
                DestinationHeight = (uint)(pdfPage.Size.Height * pdfPage.PreferredZoom)
            });

            var imageCtrl = new Image();
            var src = new BitmapImage();
            ras.Seek(0);
            src.SetSource(ras);
            imageCtrl.Source = src;

            // ***** Option 1 ***** //
            // Use Bitmap's pixel dimensions
            imageCtrl.Height = src.PixelHeight / DeviceDisplay.Current.MainDisplayInfo.Density; 
            imageCtrl.Width = src.PixelWidth / DeviceDisplay.Current.MainDisplayInfo.Density; 

            // ***** Option 2 ***** //
            // Use the PDF's dimensions to size the page contents
            // Note, this may be smaller, so further tweaking to PdfPageRenderOptions may be needed
            //imageCtrl.Height = pdfPage.Size.Width;
            //imageCtrl.Width = pdfPage.Size.Height;

            printDocument.AddPage(imageCtrl);
        }
    }

    private async Task IncludeCanvas()
    {
        for (var i = 0; i < pageCount; i++)
        {
            using var pdfPage = this.sourcePdfDocument.GetPage(uint.Parse(i.ToString()));

            using var ras = new InMemoryRandomAccessStream();

            await pdfPage.RenderToStreamAsync(ras, new PdfPageRenderOptions
            {
                DestinationWidth = (uint)(pdfPage.Size.Width * pdfPage.PreferredZoom),
                DestinationHeight = (uint)(pdfPage.Size.Height * pdfPage.PreferredZoom)
            });

            var imageCtrl = new Image();
            var src = new BitmapImage();
            ras.Seek(0);
            src.SetSource(ras);
            imageCtrl.Source = src;

            // ***** Option 1 ***** //
            // Use Bitmap's pixel dimensions
            imageCtrl.Height = src.PixelHeight / DeviceDisplay.Current.MainDisplayInfo.Density; 
            imageCtrl.Width = src.PixelWidth / DeviceDisplay.Current.MainDisplayInfo.Density; 

            // ***** Option 2 ***** //
            // Use the PDF's dimensions to size the page contents
            // Note, this may be smaller, so further tweaking to PdfPageRenderOptions may be needed
            //imageCtrl.Height = pdfPage.Size.Width;
            //imageCtrl.Width = pdfPage.Size.Height;

            // Use a canvas behind the image control
            var pageCanvas = new Canvas
            {
                Width = pdfPage.Size.Width,
                Height = pdfPage.Size.Height,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
                Margin = new Thickness(0, 0, 0, 0)
            };

            pageCanvas.Children.Add(imageCtrl);

            pdfDocumentPanel.Children.Add(pageCanvas);
        }
    }

    #region Event handlers

    private void PrintTask_Requested(PrintManager sender, PrintTaskRequestedEventArgs e)
    {
        printTask = e.Request.CreatePrintTask(fileName, sourceRequested => sourceRequested.SetSource(printDocumentSource));
        printTask.Completed += PrintTask_Completed;
    }
    
    private void PrintTask_Completed(PrintTask sender, PrintTaskCompletedEventArgs args)
    {
        printTask.Completed -= PrintTask_Completed;
        printMan.PrintTaskRequested -= PrintTask_Requested;
    }

    private void PrintDoc_Paginate(object sender, PaginateEventArgs e)
    {
        var pageDescription = e.PrintTaskOptions.GetPageDescription((uint)e.CurrentPreviewPageNumber);

        marginWidth = pageDescription.PageSize.Width;
        marginHeight = pageDescription.PageSize.Height;

        for (var i = pdfDocumentPanel.Children.Count - 1; i >= 0; i--)
        {
            var print = pdfDocumentPanel.Children[i] as Canvas;

            if (print == null)
                continue;

            print.Width = marginWidth;
            print.Height = marginHeight;

            this.printPreviewPages.TryAdd(i, print);
        }

        ((PrintDocument)sender).SetPreviewPageCount(pageCount, PreviewPageCountType.Final);
    }

    private void PrintDoc_GetPreviewPage(object sender, GetPreviewPageEventArgs e)
    {
        pdfDocumentPanel.Children.Remove(this.printPreviewPages[e.PageNumber - 1]);
        ((PrintDocument)sender).SetPreviewPage(e.PageNumber, this.printPreviewPages[e.PageNumber - 1]);
    }

    #endregion

    #region Static Helpers

    private static async Task<IRandomAccessStream> ConvertToRandomAccessStream(Stream memoryStream)
    {
        var randomAccessStream = new InMemoryRandomAccessStream();

        using var contentStream = new MemoryStream();

        await memoryStream.CopyToAsync(contentStream);

        using var outputStream = randomAccessStream.GetOutputStreamAt(0);
        using var dw = new DataWriter(outputStream);

        dw.WriteBytes(contentStream.ToArray());

        await dw.StoreAsync();
        await outputStream.FlushAsync();
        await dw.FlushAsync();

        outputStream.Dispose();
        dw.DetachStream();

        return randomAccessStream;
    }

    #endregion
}

#endif