using MultiWindowDemo.Maui.Views;
using Telerik.Maui.Controls;

namespace MultiWindowDemo.Maui;

public partial class MainPage : ContentPage
{
    // first launch
	public MainPage()
	{
		InitializeComponent();
        tabView.Items.Add(new TabViewItem{ HeaderText = "Home", Content = new HomeView() });
        tabView.Items.Add(new TabViewItem{ HeaderText = "Folder", Content = new FolderView() });
        tabView.Items.Add(new TabViewItem{ HeaderText = "Help", Content = new HelpView() });
	}

    // if this is a new window created by tearing off a tab
    public MainPage(TabViewItem breakawayTab)
    {
        InitializeComponent();
        tabView.Items.Add(breakawayTab);
    }
    
    private void OnOpenWindowClicked(object sender, EventArgs e)
    {
        // Phase 1 - get a reference to the TabViewItem
        var headerText = (sender as Button)?.BindingContext as string;
        var breakawayTab = tabView.Items.First(i => i.HeaderText == headerText);
        
        // Phase 2 - "move" the TabViewItem to a new window
        var startingPage = new MainPage(breakawayTab);
        Application.Current.OpenWindow(new Window(startingPage));
        tabView.Items.Remove(breakawayTab);
    }

    private void OnMoveTabLeftClicked(object sender, EventArgs e)
    {
        var headerText = (sender as Button)?.BindingContext as string;
        var tab = tabView.Items.First(i => i.HeaderText == headerText);

        var currentIndex = tabView.Items.IndexOf(tab);

        // the item is already at the far left
        if(currentIndex == 0)
            return;

        tabView.Items.Insert(currentIndex - 1, tab);
    }

    private void OnMoveTabRightClicked(object sender, EventArgs e)
    {
        var headerText = (sender as Button)?.BindingContext as string;
        var tab = tabView.Items.First(i => i.HeaderText == headerText);

        var currentIndex = tabView.Items.IndexOf(tab);

        // The item is already at the far right
        if(currentIndex == tabView.Items.Count - 1)
            return;

        tabView.Items.Insert(currentIndex + 1, tab);
    }
    
    // ONE BUTTON - Adds new tab
    private void OnAddTabClicked(object sender, EventArgs e)
    {
        tabView.Items.Add(new TabViewItem()
        {
            HeaderText = "Added Tab",
            Content = new Label(){Text = "I am an added tab"}
        });
    }
}

