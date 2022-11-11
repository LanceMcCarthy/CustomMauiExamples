using DepndInjtnDemo.ViewModels;

namespace DepndInjtnDemo.Views;

public partial class ProductsView : ContentView
{
    public ProductsView(){}

    public ProductsView(ProductsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}