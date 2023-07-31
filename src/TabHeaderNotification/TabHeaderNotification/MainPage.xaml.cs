using System.ComponentModel;
using Telerik.Maui.Controls;

namespace TabHeaderNotification;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

    private void NotificationLabel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // We only run this logic if the Text property's value changes
        if (e.PropertyName != nameof(Label.Text))
            return;

        // Get a reference to the Notification Label that has the notification count

        if (((Label)sender).BindingContext == null)
            return;
        
        // EXECUTION - We only show the label if:
        // 1. This is for the "folder" tab
        // 2. The value is larger than 0
        if ((((Label)sender).BindingContext as TabViewHeaderItem)?.Text == "Folder")
        {
            // show the Label only if the value is larger 
            ((Label)sender).IsVisible = Convert.ToInt32(((Label)sender).Text) > 0;
        }
    }
}