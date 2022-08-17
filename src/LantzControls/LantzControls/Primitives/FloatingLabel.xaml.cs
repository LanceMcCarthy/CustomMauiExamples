using Telerik.Maui.Controls;

namespace LantzControls.Primitives;

public partial class FloatingLabel : ContentView
{
	public FloatingLabel()
	{
		InitializeComponent();
    }
    
    // *** INSTANCE EVENT HANDLERS *** //

    private string placeholderCache = "";

    private void Presenter_OnFocused(object sender, FocusEventArgs e)
    {
        OverlayGrid.IsVisible = true;
        e.VisualElement.Focus();

        // You can take further action if the InnerContent is a certain type
        if (Presenter.Content is RadEntry entry)
        {
            placeholderCache = entry.Placeholder;
        }
    }

    private void Presenter_OnUnfocused(object sender, FocusEventArgs e)
    {
        OverlayGrid.IsVisible = false;
        e.VisualElement.Unfocus();

        // You can take further action if the InnerContent is a certain type
        if (Presenter.Content is RadEntry entry)
        {
            entry.Placeholder = placeholderCache;
        }
    }

    // *** Bindable Properties *** //
    // Add as many as you need for your requirements (e.g., BorderColor, BorderThickness, etc.)
    
    public View InnerContent
    {
        get => (View)GetValue(InnerContentProperty);
        set => SetValue(InnerContentProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public int FontSize
    {
        get => (int)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public Thickness CornerRadius
    {
        get => (Thickness)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
    
    public static readonly BindableProperty InnerContentProperty = BindableProperty.Create(
        nameof(InnerContent),
        typeof(View),
        typeof(FloatingLabel),
        default(View),
        defaultBindingMode:BindingMode.OneWay);

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(FloatingLabel),
        "Label",
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        nameof(TextColor),
        typeof(Color),
        typeof(FloatingLabel),
        Color.FromArgb("#0000fa"),
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
        nameof(FontSize),
        typeof(int),
        typeof(FloatingLabel),
        8,
        defaultBindingMode: BindingMode.OneWay);

    public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
        nameof(CornerRadius),
        typeof(Thickness),
        typeof(FloatingLabel),
        new Thickness(10),
        defaultBindingMode: BindingMode.OneWay);
}