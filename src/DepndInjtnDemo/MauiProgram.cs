using DepndInjtnDemo.ViewModels;
using DepndInjtnDemo.Views;
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

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<ProductsViewModel>();
        builder.Services.AddSingleton<PeopleViewModel>();

        return builder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<ProductsView>();
        builder.Services.AddSingleton<PeopleView>();

        return builder;
    }
}