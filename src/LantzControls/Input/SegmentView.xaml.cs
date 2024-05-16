using System.Diagnostics;
using LantzControls.Input.Models;
using Telerik.Maui.Controls;

namespace LantzControls.Input;

public partial class SegmentView : ContentView
{
    public SegmentView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty ItemsSourceProperty =
        BindableProperty.Create("ItemsSource", typeof(IList<SegmentItem>), typeof(SegmentView), null, propertyChanged: OnItemsSourceChanged);

    public static readonly BindableProperty SelectedIndexProperty =
        BindableProperty.Create("SelectedIndex", typeof(int), typeof(SegmentView), null, propertyChanged: OnSelectedIndexChanged);

    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create("CornerRadius", typeof(int), typeof(SegmentView), null, propertyChanged: OnCornerRadiusChanged);

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create("FontSize", typeof(int), typeof(SegmentView), null);

    public static readonly BindableProperty SelectedSegmentBackgroundColorProperty =
        BindableProperty.Create("SelectedSegmentBackgroundColor", typeof(Color), typeof(SegmentView));

    public static readonly BindableProperty SelectedSegmentTextColorProperty =
        BindableProperty.Create("SelectedSegmentTextColor", typeof(Color), typeof(SegmentView));

    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create("BorderColor", typeof(Color), typeof(SegmentView), null, propertyChanged: OnBorderColorChanged);

    public IList<SegmentItem> ItemsSource
    {
        get => (IList<SegmentItem>)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public int SelectedIndex
    {
        get => (int)GetValue(SelectedIndexProperty);
        set => SetValue(SelectedIndexProperty, value);
    }

    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public int FontSize
    {
        get => (int)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public Color SelectedSegmentBackgroundColor
    {
        get => (Color)GetValue(SelectedSegmentBackgroundColorProperty);
        set => SetValue(SelectedSegmentBackgroundColorProperty, value);
    }

    public Color SelectedSegmentTextColor
    {
        get => (Color)GetValue(SelectedSegmentTextColorProperty);
        set => SetValue(SelectedSegmentTextColorProperty, value);
    }

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    // Bindable PropertyChanged Handlers

    private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is SegmentView self && newValue is IList<SegmentItem>)
        {
            self.CreateButtons();
        }
    }

    private static void OnSelectedIndexChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is SegmentView self)
        {
            if ((int)newValue > self.ItemsSource.Count - 1)
            {
                throw new ArgumentOutOfRangeException($"The SelectedIndex {(int)newValue} is out of range");
            }

            self.SetSelectedButtonColor();

            self.SelectedItemChanged?.Invoke(self, new SelectedItemChangedEventArgs(self.ItemsSource[(int)newValue], (int)newValue));
        }
    }

    private static void OnCornerRadiusChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is SegmentView self)
        {
            self.RootBorder.CornerRadius = (int)newValue;
        }
    }

    private static void OnBorderColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is SegmentView self)
        {
            self.RootBorder.BorderColor = (Color)newValue;
        }
    }

    public event EventHandler<SelectedItemChangedEventArgs> SelectedItemChanged;

    #region Internal Methods

    private void CreateButtons()
    {
        // ensuring no abandoned event handlers
        if (ButtonsGrid.Children.Any())
        {
            foreach (var child in ButtonsGrid.Children)
            {
                if (child is RadButton childButton)
                {
                    childButton.Clicked -= Button_Clicked;
                }
            }
        }

        // remove previous buttons
        ButtonsGrid.Children.Clear();

        if (ItemsSource == null)
            return;

        // Create new buttons
        foreach (var item in ItemsSource)
        {
            var index = ItemsSource.IndexOf(item);

            ButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition());

            var button = new RadButton();

            // Pass down the properties to the RadButton
            button.Text = item.Text;
            button.ImageSource = item.ImageSource;
            button.BackgroundImage = item.BackgroundImageSource;

            // From BindableProperties
            button.FontSize = this.FontSize;

            // do not customize these, they're used 
            button.BorderThickness = 0;
            button.BorderColor = Colors.Transparent;

            Grid.SetColumn(button, index);

            // Important: this adds the "walls" between segments
            if (index > 0)
            {
                button.BorderThickness = new Thickness(2, 0, 0, 0);
                button.BorderColor = BorderColor;
            }

            button.Clicked += Button_Clicked;

            ButtonsGrid.Children.Add(button);
        }

        SetSelectedButtonColor();
    }

    // Changes the SelectedIndex
    private void Button_Clicked(object sender, System.EventArgs e)
    {
        if (sender is not RadButton clickedButton)
            return;

        try
        {
            this.SelectedIndex = ButtonsGrid.Children.IndexOf(clickedButton);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"SegmentView Exception: {ex.Message}");
        }
    }

    // This will change the segment color according to the selected index.
    private void SetSelectedButtonColor()
    {
        foreach (var child in ButtonsGrid.Children)
        {
            if (child is not RadButton childButton)
                continue;

            if (childButton.Text == ItemsSource[SelectedIndex].Text)
            {
                childButton.BackgroundColor = SelectedSegmentBackgroundColor;
                childButton.TextColor = SelectedSegmentTextColor;
            }
            else
            {
                childButton.BackgroundColor = Colors.White;
                childButton.TextColor = Colors.Black;
            }
        }
    }

    #endregion
}