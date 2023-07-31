using Microsoft.Maui.LifecycleEvents;
using Telerik.Maui.Controls.Compatibility;

#if WINDOWS10_0_17763_0_OR_GREATER
using CommonHelpers.Maui.Platforms.Windows;

#elif MACCATALYST
using CommonHelpers.Maui.Platforms.MacCatalyst;
using UIKit;
using CoreGraphics;

#endif

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TabHeaderNotification;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseTelerik()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("telerikfontexamples.ttf", "telerikfontexamples");
            });

        builder.ConfigureLifecycleEvents(events =>
        {

#if WINDOWS10_0_17763_0_OR_GREATER
            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    window.TryMicaOrAcrylic();
                });
            });

#elif MACCATALYST
            events.AddiOS(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.SceneWillConnect((scene, session, options) =>
                {
                    if (scene is UIWindowScene windowScene)
                    {
                        // Can be used for restricting the MacOS window's min, max (or both) size.
                        windowScene.RestrictWindowMinimumSize(new CGSize(600, 400));
                    }
                });
            });
#endif
        });

        return builder.Build();
    }
}