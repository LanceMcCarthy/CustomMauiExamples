namespace LantzControls.Primitives;

public partial class LabeledCheckBox : ContentView
{
    public LabeledCheckBox()
    {
        InitializeComponent();
    }
    
    public bool IsChecked
    {
        get => (bool)GetValue(IsExpandedProperty);
        set => SetValue(IsExpandedProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public static readonly BindableProperty IsExpandedProperty = BindableProperty.Create(
        nameof(IsChecked), 
        typeof(bool), 
        typeof(LabeledCheckBox), 
        false, 
        propertyChanged: OnIsExpandedChanged);

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text), 
        typeof(string), 
        typeof(LabeledCheckBox), 
        string.Empty, 
        propertyChanged: OnTextChanged);
    
    private static void OnIsExpandedChanged (BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is LabeledCheckBox self)
        {
            self.PART_CheckBox.IsChecked = (bool)newValue;
        }
    }
    
    private static void OnTextChanged (BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is LabeledCheckBox self)
        {
            self.PART_Label.Text = (string)newValue;
        }
    }
    
    private void OnLabelTapped(object sender, EventArgs e)
    {
        PART_CheckBox.IsChecked = !PART_CheckBox.IsChecked;
    }
}