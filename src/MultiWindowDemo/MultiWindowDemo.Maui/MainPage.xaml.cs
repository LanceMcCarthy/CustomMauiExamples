using MultiWindowDemo.Maui.Views;
using Telerik.Maui.Controls;

namespace MultiWindowDemo.Maui;

public partial class MainPage : ContentPage
{
    /// <summary>
    /// Creates a new MainWindow with the three default TabView items.
    /// </summary>
    public MainPage()
    {
        InitializeComponent();
        tabView.Items.Add(new TabViewItem { HeaderText = "Home", Content = new HomeView() });
        tabView.Items.Add(new TabViewItem { HeaderText = "Folder", Content = new FolderView() });
        tabView.Items.Add(new TabViewItem { HeaderText = "Help", Content = new HelpView() });
    }
    
    /// <summary>
    /// Creates a new MainWindow instance
    /// </summary>
    /// <param name="breakawayTab">Reference to a TabViewItem that will be placed in the new window's RadTabView</param>
    public MainPage(TabViewItem breakawayTab)
    {
        InitializeComponent();
        tabView.Items.Add(breakawayTab);
    }

    private void OnOpenWindowClicked(object sender, EventArgs e)
    {
        if (sender is Button { BindingContext: TabViewHeaderItem headerItem })
        {
            // Get a reference to the TabViewItem
            var breakawayTab = tabView.Items.First(i => i.HeaderText == headerItem.Text);

            // Create/open a new Window, using the new MainPage and the breakaway TabViewItem
            Application.Current?.OpenWindow(new Window(new MainPage(breakawayTab)));

            // Finally, if all goes well, we can remove the tab from the original window's TabView
            tabView.Items.Remove(breakawayTab);
        }
    }

    private void OnMoveTabLeftClicked(object sender, EventArgs e)
    {
        if (sender is Button { BindingContext: TabViewHeaderItem headerItem })
        {
            var tab = tabView.Items.First(i => i.HeaderText == headerItem.Text);

            var currentIndex = tabView.Items.IndexOf(tab);

            // If it is safe to do so, move the tab to the left
            if (currentIndex > 0)
            {
                tabView.Items.Insert(currentIndex - 1, tab);
            }
        }
    }

    private void OnMoveTabRightClicked(object sender, EventArgs e)
    {
        if (sender is Button { BindingContext: TabViewHeaderItem headerItem })
        {
            var tab = tabView.Items.First(i => i.HeaderText == headerItem.Text);

            var currentIndex = tabView.Items.IndexOf(tab);

            // If it is safe to do so, move the tab to the right
            if (currentIndex < tabView.Items.Count - 1)
            {
                tabView.Items.Insert(currentIndex + 1, tab);
            }
        }
    }

    // Adds new tab
    private void OnAddTabClicked(object sender, EventArgs e)
    {
        tabView.Items.Add(new TabViewItem
        {
            HeaderText = "Added Tab",
            Content = new Label { Text = "I am an added tab" }
        });
    }
}

