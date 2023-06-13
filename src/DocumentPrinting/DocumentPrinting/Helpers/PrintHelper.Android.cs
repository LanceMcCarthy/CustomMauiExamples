#if ANDROID
using Android.OS;
using Android.Print;
using Java.IO;
using FileNotFoundException = Java.IO.FileNotFoundException;
using IOException = Java.IO.IOException;

namespace DocumentPrinting.Helpers;

public class PrintHelper : PrintDocumentAdapter
{
    public string FileToPrint { get; set; }
    
    public PrintHelper(string fileDesc)
    {
        FileToPrint = fileDesc;
    }

    public override void OnLayout(PrintAttributes oldAttributes, PrintAttributes newAttributes, CancellationSignal cancellationSignal, LayoutResultCallback callback, Bundle extras)
    {
        if (cancellationSignal.IsCanceled)
        {
            callback.OnLayoutCancelled();
            return;
        }
        
        var pdi = new PrintDocumentInfo.Builder(FileToPrint).SetContentType(Android.Print.PrintContentType.Document).Build();

        callback.OnLayoutFinished(pdi, true);
    }

    public override void OnWrite(PageRange[] pages, ParcelFileDescriptor destination, CancellationSignal cancellationSignal, WriteResultCallback callback)
    {
        InputStream input = null;
        OutputStream output = null;

        try
        {
            input = new FileInputStream(FileToPrint);
            output = new FileOutputStream(destination.FileDescriptor);

            var buf = new byte[1024];
            int bytesRead;

            while ((bytesRead = input.Read(buf)) > 0)
            {
                output.Write(buf, 0, bytesRead);
            }

            callback.OnWriteFinished(new[] { PageRange.AllPages });

        }
        catch (FileNotFoundException ee)
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
            catch (IOException e)
            {
                e.PrintStackTrace();
            }
        }
    }
}
#endif