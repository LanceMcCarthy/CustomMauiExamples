using SignatureEditor.Interfaces;
using SignatureEditor.ViewModels;
using Telerik.Maui.Controls.SignaturePad;

namespace SignatureEditor.Views;

public partial class MainPage : ContentPage, ISignaturePadView
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel{ SignaturePadView = this };
    }

    public void ClearSignature() => SignaturePad1.ClearCommand.Execute(null);

    public Task SaveImageAsync(Stream outputStream) => SignaturePad1.SaveImageAsync(outputStream);

    public Task SaveImageAsync(Stream outputStream, SaveImageSettings settings) => SignaturePad1.SaveImageAsync(outputStream, settings);

    protected override void OnAppearing()
    {
        base.OnAppearing();

        (BindingContext as MainViewModel)?.LoadSignatureCommand.Execute(null);
    }
}