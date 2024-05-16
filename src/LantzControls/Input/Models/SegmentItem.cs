using CommonHelpers.Common;

namespace LantzControls.Input.Models;

public class SegmentItem : BindableBase
{
    private string text;
    private ImageSource imageSource;
    private ImageSource backgroundImageSource;

    public string Text
    {
        get => text;
        set => SetProperty(ref text, value);
    }

    public ImageSource ImageSource
    {
        get => imageSource;
        set => SetProperty(ref imageSource, value);
    }

    public ImageSource BackgroundImageSource
    {
        get => backgroundImageSource;
        set => SetProperty(ref backgroundImageSource, value);
    }
}