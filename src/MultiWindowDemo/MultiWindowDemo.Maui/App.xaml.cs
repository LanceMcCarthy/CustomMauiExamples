namespace MultiWindowDemo.Maui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        // Manipulate Window object

        return window;
    }
}

public class MyWindow : Window
{
    public MyWindow() : base()
    {
    }

    public MyWindow(Page page) : base(page)
    {
    }

    // Override Window methods

    protected override void OnCreated()
    {
        base.OnCreated();
    }

    protected override void OnActivated()
    {
        base.OnActivated();
    }
}
