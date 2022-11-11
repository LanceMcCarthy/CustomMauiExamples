using DepndInjtnDemo.ViewModels;
using DepndInjtnDemo.Views;
using Telerik.Maui.Controls;

namespace DepndInjtnDemo;

public partial class MainPage : ContentPage
{
    public MainPage(
        MainViewModel vm, 
        PeopleView peopleView, 
        ProductsView productsView)
    {
		InitializeComponent();
        this.BindingContext = vm;

        MyTabView1.Items.Add(new TabViewItem()
        {
            HeaderText = "People",
            Content = peopleView
        });

        MyTabView1.Items.Add(new TabViewItem()
        {
            HeaderText = "Products",
            Content = productsView
        });

    }
}