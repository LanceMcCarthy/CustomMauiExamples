using CommonHelpers.Common;
using System.Collections.ObjectModel;
using Telerik.Maui.Controls;
using Telerik.Maui.Controls.DataGrid;

namespace LantzControls.Data.DataGrid;

public partial class ColumnChooser : ContentView
{
    private readonly ObservableCollection<ChooserDataItem> chooserItems = new();

    public ColumnChooser()
    {
        InitializeComponent();

        PART_Chooser.ItemsSource = chooserItems;
    }

    private void RadCheckBox_OnIsCheckedChanged(object sender, IsCheckedChangedEventArgs e)
    {
        if (AssociatedDataGrid == null)
            return;

        if (sender is RadCheckBox { BindingContext: ChooserDataItem dataItem })
        {
            var column = AssociatedDataGrid.Columns.FirstOrDefault(col => col.HeaderText == dataItem.ColumnHeaderText);

            // If the column exists, update the IsVisible value to match the IsChecked value
            if (column != null)
            {
                column.IsVisible = dataItem.IsChecked;
            }
        }
    }

    public static readonly BindableProperty AssociatedDataGridProperty = BindableProperty.Create(
        nameof(AssociatedDataGrid),
        typeof(RadDataGrid),
        typeof(ColumnChooser),
        null,
        propertyChanged: OnAssociatedDataGridChanged);

    public RadDataGrid AssociatedDataGrid
    {
        get => (RadDataGrid)GetValue(AssociatedDataGridProperty);
        set => SetValue(AssociatedDataGridProperty, value);
    }

    private static void OnAssociatedDataGridChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ColumnChooser self)
        {
            if (newValue is RadDataGrid newDataGrid)
            {
                // STEP 1 - Setup initial chooser items based on the existing columns
                foreach (var column in newDataGrid.Columns)
                {
                    self.chooserItems.Add(new ChooserDataItem(column.IsVisible, column.HeaderText));
                }


                // STEP 2 - Subscribe to collection changed to update the chooser items if the columns change
                newDataGrid.Columns.CollectionChanged += (s, e) =>
                {
                    if (e.NewItems?.Count > 0)
                    {
                        foreach (var item in e.NewItems)
                        {
                            if (item is DataGridColumn newColumn)
                            {
                                var matchingItem = self.chooserItems.FirstOrDefault(x => x.ColumnHeaderText == newColumn.HeaderText);

                                if (matchingItem == null)
                                {
                                    self.chooserItems.Add(new ChooserDataItem(true, newColumn.HeaderText));
                                }
                            }
                        }
                    }

                    if (e.OldItems?.Count > 0)
                    {
                        foreach (var item in e.OldItems)
                        {
                            if (item is DataGridColumn oldColumn)
                            {
                                var matchingItem = self.chooserItems.FirstOrDefault(x => x.ColumnHeaderText == oldColumn.HeaderText);

                                if (matchingItem != null)
                                {
                                    self.chooserItems.Remove(matchingItem);
                                }
                            }
                        }
                    }
                };
            }
        }
    }
    
    private class ChooserDataItem : BindableBase
    {
        private bool isChecked;
        private string columnHeaderText;

        public ChooserDataItem() { }

        public ChooserDataItem(bool isCheck, string colText)
        {
            this.isChecked = isCheck;
            this.columnHeaderText = colText;
        }

        public bool IsChecked
        {
            get => isChecked;
            set => SetProperty(ref isChecked, value);
        }

        public string ColumnHeaderText
        {
            get => columnHeaderText;
            set => SetProperty(ref columnHeaderText, value);
        }
    }
}