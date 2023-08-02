using Telerik.Maui.Controls;

namespace PopupServiceDemo;

public class PopupService
{
    private RadPopup _popup;

    public PopupService() { }

    public void AttachParent(VisualElement visualElement)
    {
        var popup = GetPopup();
        popup.PlacementTarget = visualElement;
    }

    public void OpenPopup(View content)
    {
        var popup = GetPopup();

        popup.Content = content;
        popup.IsOpen = true;
    }

    public void ClosePopup()
    {
        var popup = GetPopup();
        popup.IsOpen = false;
    }

    // This ensures we wait to instantiate the popup until the first time it is needed
    private RadPopup GetPopup()
    {
        return _popup ??= new RadPopup
        {
            AnimationType = PopupAnimationType.Fade,
            OutsideBackgroundColor = Color.FromArgb("#99000000"),
            Placement = PlacementMode.Center,
            IsModal = true
        };
    }
}