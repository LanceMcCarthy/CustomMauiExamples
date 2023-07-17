using CommonHelpers.Common;
using SignatureEditor.Interfaces;

namespace SignatureEditor.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly string signatureFilePath = Path.Join(FileSystem.Current.AppDataDirectory, "signature.jpg");
    private ImageSource capturedSignatureImageSource;
    private bool hasSignature;

    public MainViewModel()
    {
        LoadSignatureCommand = new Command(LoadSignature);
        EditSignatureCommand = new Command(EditSignature);
        SaveSignatureCommand = new Command(SaveSignature);
        ClearSignatureCommand = new Command(ClearSignature);
    }

    public bool HasSignature
    {
        get => hasSignature;
        set => SetProperty(ref hasSignature, value);
    }

    public ImageSource CapturedSignatureImageSource
    {
        get => capturedSignatureImageSource;
        set => SetProperty(ref capturedSignatureImageSource, value);
    }

    public Command LoadSignatureCommand { get; set; }

    public Command EditSignatureCommand { get; set; }

    public Command SaveSignatureCommand { get; set; }

    public Command ClearSignatureCommand { get; set; }

    public ISignaturePadView SignaturePadView { get; set; }

    #region Methods

    private void LoadSignature()
    {
        // Lets check if there was a previously saved signature
        HasSignature = File.Exists(signatureFilePath);

        // If there was, then load it into the Image
        if (HasSignature)
        {
            CapturedSignatureImageSource = ImageSource.FromFile(signatureFilePath);
        }
    }

    private void EditSignature()
    {
        // Make sure the old signature is gone
        SignaturePadView.ClearSignature();

        // hide the overlay panel to expose the SignaturePad
        HasSignature = false;
    }
    
    private async void SaveSignature()
    {
        using var stream = new MemoryStream();

        await this.SignaturePadView.SaveImageAsync(stream);
        
        var array = stream.ToArray();
        
        await File.WriteAllBytesAsync(signatureFilePath, array);

        CapturedSignatureImageSource = ImageSource.FromStream(() => new MemoryStream(array));

        // show the overlay panel one we're done
        HasSignature = true;
    }

    private void ClearSignature()
    {
        SignaturePadView.ClearSignature();
    }

    #endregion
}