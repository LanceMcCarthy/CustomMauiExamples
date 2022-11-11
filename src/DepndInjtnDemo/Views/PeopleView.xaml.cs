using DepndInjtnDemo.ViewModels;

namespace DepndInjtnDemo.Views;

public partial class PeopleView : ContentView
{
    public PeopleView() { }

    public PeopleView(PeopleViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}