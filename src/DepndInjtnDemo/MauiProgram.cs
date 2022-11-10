using Telerik.Maui.Controls.Compatibility;

namespace DepndInjtnDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseTelerik()
            .UseMauiApp<App>()
            .RegisterViewModels()  // registering view model types
            .RegisterViews()       // registering the view types 
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}