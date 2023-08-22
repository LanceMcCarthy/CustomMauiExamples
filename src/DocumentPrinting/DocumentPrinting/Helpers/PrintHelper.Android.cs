#if ANDROID
using Android.Content;
using Android.OS;
using Android.Print;
using Java.IO;

namespace DocumentPrinting.Helpers;

public class PrintHelper
{
    // Credit goes to https://github.com/Cywizz for abstracting this into a more user-friendly manner.

    public Task PrintAsync(Stream fileStream, string fileName)
    {
        if (fileStream.CanSeek)
            fileStream.Position = 0;

        string createdFilePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);

        //Save the stream to the created file
        using (var dest = System.IO.File.OpenWrite(createdFilePath))
        {
            fileStream.CopyTo(dest);
        }

        if (Platform.CurrentActivity == null)
            return Task.FromException<long>(new Exception("The CurrentActivity is null."));

        var printManager = (PrintManager)Platform.CurrentActivity.GetSystemService(Context.PrintService);

        // Now we can use the preexisting print helper class
        var utility = new PrintUtility(createdFilePath);

        printManager?.Print(createdFilePath, utility, null);

        return Task.CompletedTask;
    }
}

public class PrintUtility : PrintDocumentAdapter
{
    public string PrintFileName { get; set; }

    public PrintUtility(string printFileName)
    {
        PrintFileName = printFileName;
    }

    public override void OnLayout(PrintAttributes oldAttributes, PrintAttributes newAttributes, CancellationSignal cancellationSignal, LayoutResultCallback callback, Bundle extras)
    {
        if (cancellationSignal.IsCanceled)
        {
            callback.OnLayoutCancelled();
            return;
        }

        var pdi = new PrintDocumentInfo.Builder(PrintFileName).SetContentType(PrintContentType.Document).Build();

        callback.OnLayoutFinished(pdi, true);
    }

    public override void OnWrite(PageRange[] pages, ParcelFileDescriptor destination, CancellationSignal cancellationSignal, WriteResultCallback callback)
    {
        InputStream input = null;
        OutputStream output = null;

        try
        {
            input = new FileInputStream(PrintFileName);
            output = new FileOutputStream(destination.FileDescriptor);

            var buf = new byte[1024];
            int bytesRead;

            while ((bytesRead = input.Read(buf)) > 0)
            {
                output.Write(buf, 0, bytesRead);
            }

            callback.OnWriteFinished(new[] { PageRange.AllPages });

        }
        catch (Java.IO.FileNotFoundException ee)
        {
            //Catch
        }
        catch (Exception e)
        {
            //Catch
        }
        finally
        {
            try
            {
                input?.Close();
                output?.Close();
            }
            catch (Java.IO.IOException e)
            {
                e.PrintStackTrace();
            }
        }
    }
}
#endif