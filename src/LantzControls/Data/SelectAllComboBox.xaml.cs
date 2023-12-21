using LantzControls.DemoModels;
using System.Collections.ObjectModel;
using Telerik.Maui.Controls;

namespace LantzControls.Data;

public partial class SelectAllComboBox : ContentView
{
    // This prevents the OnCheckChanged logic from executing, preventing double-action.
    private bool _actionLock;

	public SelectAllComboBox()
	{
		InitializeComponent();
        ComboBox1.ItemsSource = Items;
	}

    private void SelectAllCheckBox_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (_actionLock)
            return;

        if (e.Value)
        {
            SelectAll();
        }
        else
        {
            UnselectAll();
        }
    }

    private void ComboBox1_OnSelectionChanged(object sender, ComboBoxSelectionChangedEventArgs e)
    {
        // If the user somehow selected all the items manually, we can manually check the SelectAll checkbox
        if (e.AddedItems.Any() && ComboBox1.SelectedItems.Count == Items.Count)
        {
            if (!SelectAllCheckBox.IsChecked)
            {
                _actionLock = true;

                SelectAllCheckBox.IsChecked = true;

                _actionLock = false;
            }
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
    {
        if (sender is Label { BindingContext: City item })
        {
            ComboBox1.SelectedItems.Remove(item);

            // A quick check to see if the CheckAll is checked. Uncheck it if the user had removed an item
            if (SelectAllCheckBox.IsChecked)
            {
                _actionLock = true;

                SelectAllCheckBox.IsChecked = false;

                _actionLock = false;
            }
        }
    }

    private void SelectAll()
    {
        ComboBox1.SelectedItems.Clear();

        foreach (var item in Items)
        {
            ComboBox1.SelectedItems.Add(item);
        }
    }

    private void UnselectAll()
    {
        ComboBox1.SelectedItems.Clear();
    }

    public ObservableCollection<City> Items { get; set; } = new()
    {
        new() { Name = "Tokyo", Population = 13929286 },
        new() { Name = "New York", Population = 8623000 },
        new() { Name = "London", Population = 8908081 },
        new() { Name = "Madrid", Population = 3223334 },
        new() { Name = "Los Angeles", Population = 4000000},
        new() { Name = "Paris", Population = 2141000 },
        new() { Name = "Beijing", Population = 21540000 },
        new() { Name = "Singapore", Population = 5612000 },
        new() { Name = "New Delhi", Population = 18980000 },
        new() { Name = "Bangkok", Population = 8305218 },
        new() { Name = "Berlin", Population = 3748000 },
    };
}