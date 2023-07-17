using SignatureEditor.Views;

namespace SignatureEditor;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
