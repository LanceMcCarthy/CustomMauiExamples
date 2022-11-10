using DepndInjtnDemo.ViewModels;
using DepndInjtnDemo.Views;

namespace DepndInjtnDemo;

public static class MauiBuilderExtensions
{
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MainViewModel>();

        return builder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<ProductsView>();

        return builder;
    }
}