using Telerik.Maui.Controls.SignaturePad;

namespace SignatureEditor.Interfaces;

public interface ISignaturePadView
{
    void ClearSignature();

    Task SaveImageAsync(Stream outputStream);

    Task SaveImageAsync(Stream outputStream, SaveImageSettings settings);
}